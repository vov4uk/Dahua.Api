using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Dahua.Api.Abstractions;
using Dahua.Api.Data;
using Dahua.Api.Helpers;
using Dahua.Api.Struct;
using Dahua.Api.Struct.Video;
using static Dahua.Api.DHConsts;

namespace Dahua.Api.Service
{
    /// <summary>
    /// Video Service
    /// </summary>
    public class VideoService : IVideoService
    {
        /// <summary>
        /// Progress callback function
        /// </summary>
        /// <param name="lPlayHandle">Play handle: return value</param>
        /// <param name="dwTotalSize">Refers to the total size of this playback, the unit is KB</param>
        /// <param name="dwDownLoadSize">Refers to the size that has been played, the unit is KB, when the value is -1 indicates that the end of the defense is over</param>
        /// <param name="dwUser">User data</param>
        private delegate void fDownLoadPosCallBack(long lPlayHandle, uint dwTotalSize, uint dwDownLoadSize, IntPtr dwUser);

        /// <summary>
        /// Most query files
        /// </summary>
        private const int intFilesMaxCount = 1024;

        /// <summary>
        /// Download back adjustment
        /// </summary>
        private readonly fDownLoadPosCallBack downLoadFun;

        /// <summary>
        /// The session
        /// </summary>
        private readonly IDahuaApi session;

        /// <summary>
        /// Initializes a new instance of the <see cref="VideoService"/> class.
        /// </summary>
        /// <param name="session">The session.</param>
        public VideoService(IDahuaApi session)
        {
            this.session = session;
            downLoadFun = new fDownLoadPosCallBack(DownLoadPosFun);
        }

        /// <summary>
        /// Gets the videos.
        /// </summary>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time.</param>
        /// <returns></returns>
        public IReadOnlyCollection<IRemoteFile> FindFiles(DateTime startTime, DateTime endTime)
        {
            return FindFiles(startTime, endTime, 0);
        }

        /// <summary>
        /// Gets the videos.
        /// </summary>
        /// <param name="channelId">The channel identifier.</param>
        /// <param name="startTime">The start time.</param>
        /// <param name="endTime">The end time.</param>
        /// <returns></returns>
        public IReadOnlyCollection<IRemoteFile> FindFiles(DateTime startTime, DateTime endTime, int channelId)
        {
            var nriFileInfo = new NET_RECORDFILE_INFO[intFilesMaxCount];

            int maxlen = intFilesMaxCount * Marshal.SizeOf(typeof(NET_RECORDFILE_INFO));

            int fileCount = 0;
            IntPtr pBoxInfo = IntPtr.Zero;
            try
            {
                NET_TIME timeStart = NET_TIME.FromDateTime(startTime);
                NET_TIME timeEnd = NET_TIME.FromDateTime(endTime);
                pBoxInfo = Marshal.AllocHGlobal(maxlen);//Allocate a fixed -specified memory space
                ulong fileCountMin = 0;
                if (pBoxInfo != IntPtr.Zero)
                {
                    SdkHelper.InvokeSDK(() => CLIENT_QueryRecordFile(session.UserId, channelId, (int)RECORD_FILE_TYPE.ALLRECORDFILE, ref timeStart, ref timeEnd, null, pBoxInfo, maxlen, ref fileCount, session.CommandTimeout, false));
                    fileCountMin = (ulong)(fileCount <= nriFileInfo.Length ? fileCount : nriFileInfo.Length);
                    for (ulong dwLoop = 0; dwLoop < fileCountMin; dwLoop++)
                    {
                        //Copy the data of the specified memory space in the specified format to the destination array
                        nriFileInfo[dwLoop] = (NET_RECORDFILE_INFO)Marshal.PtrToStructure((IntPtr)((ulong)pBoxInfo + (ulong)Marshal.SizeOf(typeof(NET_RECORDFILE_INFO)) * dwLoop), typeof(NET_RECORDFILE_INFO));
                    }
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                Marshal.FreeHGlobal(pBoxInfo);//Release fixed memory allocation
                pBoxInfo = IntPtr.Zero;
            }

            return nriFileInfo
                .Where(x => x.filename?.Length > 0)
                .Select(x=> new RemoteFile(x))
                .Where(y => y.Duration > 0) // if Duration == 0; invalid file, stuck while downloading
                .ToList();
        }

        /// <summary>
        /// Downloads the by record file.
        /// </summary>
        /// <param name="file">The file.</param>
        /// <param name="destinationPath">The path.</param>
        /// <returns></returns>
        public long StartDownloadFile(IRemoteFile file, string destinationPath)
        {
            NET_RECORDFILE_INFO fileInfo = default;
            var strFileName = destinationPath.ToLower();
            if (!strFileName.EndsWith(".mp4"))
            {
                strFileName += ".mp4";
            }

            if (file is RemoteFile remoteFile)
            {
                fileInfo = remoteFile.Original;
            }
            else
            {
                fileInfo = new NET_RECORDFILE_INFO()
                {
                    starttime = NET_TIME.FromDateTime(file.Date),
                    endtime = NET_TIME.FromDateTime(file.Date.AddSeconds(file.Duration)),
                    filename = System.Text.Encoding.UTF8.GetBytes(file.Name),
                    size = file.Size,
                };
            }

            return SdkHelper.InvokeSDK(() => CLIENT_DownloadByRecordFile(session.UserId, ref fileInfo, strFileName, downLoadFun, IntPtr.Zero));
        }

        /// <summary>
        /// Gets the download position.
        /// </summary>
        /// <param name="fileHandler">The file handler.</param>
        /// <returns></returns>
        public (bool success, int totalSize, int downloadSize) GetDownloadPosition(long fileHandler)
        {
            int totalSize = 0;
            int downloadSize = 0;
            bool success = SdkHelper.InvokeSDK(() => CLIENT_GetDownloadPos(fileHandler, out totalSize, out downloadSize), throwException: false);
            return (success, totalSize, downloadSize);
        }

        /// <summary>
        /// Stops the download.
        /// </summary>
        /// <param name="fileHandler">The file handler.</param>
        /// <returns></returns>
        public bool StopDownloadFile(long fileHandler)
        {
            return SdkHelper.InvokeSDK(() => CLIENT_StopDownload(fileHandler), throwException: false);
        }

        /// <summary>
        /// Download callback
        /// </summary>
        /// <param name="playHandler">Play handle</param>
        /// <param name="dwTotalSize">Total size</param>
        /// <param name="dwDownLoadSize">Download Size</param>
        /// <param name="dwUser">User data</param>
        private void DownLoadPosFun(long playHandler, uint dwTotalSize, uint dwDownLoadSize, IntPtr dwUser)
        {
            if (playHandler > 0)
            {
                if (0xFFFFFFFF == dwDownLoadSize || 0xFFFFFFFE == dwDownLoadSize)
                {
                    StopDownloadFile(playHandler);
                }
            }
        }

        /// <summary>
        /// Query video file
        /// </summary>
        /// <param name="lLoginID">Device user login handle</param>
        /// <param name="nChannelId">Channel ID</param>
        /// <param name="nRecordFileType">Video file type</param>
        /// <param name="tmStart">Video start time</param>
        /// <param name="tmEnd">End of the video</param>
        /// <param name="pchCardid">Card number is valid for the card number query, you can fill in NULL in other cases</param>
        /// <param name="nriFileinfo">The backing video file information is a NET_RECORDFILE_INFO Array</param>
        /// <param name="maxlen">nriFileinfo The maximum length of the buffer; (unit byte, recommended to be between 100-200*sizeof(NET RECORDFILE INFO))</param>
        /// <param name="filecount">The number of files returned is the maximum output parameter that can only be found that the recording records that are buffered up to be full</param>
        /// <param name="waittime">waiting time</param>
        /// <param name="bTime">Check it by time (currently invalid)</param>
        /// <returns>
        /// true: Success; False: Failure
        /// </returns>
        [DllImport(LIBRARYNETSDK)]
        private static extern bool CLIENT_QueryRecordFile(long lLoginID, int nChannelId, int nRecordFileType, ref NET_TIME tmStart, ref NET_TIME tmEnd, string pchCardid, IntPtr nriFileinfo, int maxlen, ref int filecount, int waittime, bool bTime);

        /// <summary>
        /// Download video files by file, download by queried file information
        /// </summary>
        /// <param name="lLoginID">CLIENT_Login The return value</param>
        /// <param name="lpRecordFile">Video file information</param>
        /// <param name="sSavedFileName">The video name of the video to be preserved, the whole path</param>
        /// <param name="cbDownLoadPos">Download the progress return function</param>
        /// <param name="dwUserData">Download progress recovery user custom data</param>
        /// <returns>Successfully return to download ID, fail to return 0</returns>
        [DllImport(LIBRARYNETSDK)]
        private static extern long CLIENT_DownloadByRecordFile(long lLoginID, ref NET_RECORDFILE_INFO lpRecordFile, string sSavedFileName, fDownLoadPosCallBack cbDownLoadPos, IntPtr dwUserData);

        /// <summary>
        /// Obtain the current position of the downloaded video, which can be used for interfaces that do not need to display the download progress in real time. It has a similar function to the download callback function.
        /// </summary>
        /// <param name="lFileHandle">Return value of CLIENT Download By Record File</param>
        /// <param name="nTotalSize">Total length of download, unit KB</param>
        /// <param name="nDownLoadSize">Downloaded length, unit KB</param>
        /// <returns>true: success; false: failure</returns>
        [DllImport(LIBRARYNETSDK)]
        private static extern bool CLIENT_GetDownloadPos(long lFileHandle, out int nTotalSize, out int nDownLoadSize);

        /// <summary>
        /// Stop downloading video files
        /// </summary>
        /// <param name="lFileHandle">Return value of CLIENT Download By Record File</param>
        /// <returns>true: success; false: failure</returns>
        [DllImport(LIBRARYNETSDK)]
        private static extern bool CLIENT_StopDownload(long lFileHandle);

    }
}
