using Dahua.Api.Struct;
using Dahua.Api.Struct.Video;
using System;

namespace Dahua.Api.Data
{
    /// <summary>
    /// Remote File
    /// </summary>
    /// <seealso cref="IRemoteFile" />
    public class RemoteFile: IRemoteFile
    {
        internal readonly NET_RECORDFILE_INFO Original;

        /// <summary>
        /// Initializes a new instance of the <see cref="RemoteFile"/> class.
        /// </summary>
        /// <param name="name">The name.</param>
        /// <param name="date">The date.</param>
        /// <param name="duration">The duration.</param>
        /// <param name="size">The size.</param>
        public RemoteFile(string name, DateTime date, int duration, uint size)
        {
            var nameArr = System.Text.Encoding.UTF8.GetBytes(name);
            Array.Resize<byte>(ref nameArr, 128);

            Original = new NET_RECORDFILE_INFO()
            {
                starttime = NET_TIME.FromDateTime(date),
                endtime = NET_TIME.FromDateTime(date.AddSeconds(duration)),
                filename = nameArr,
                size = size / 1024,
            };
        }

        internal RemoteFile(NET_RECORDFILE_INFO findData)
        {
            Original = findData;
        }

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name => System.Text.Encoding.UTF8.GetString(Original.filename).TrimEnd('\0');

        /// <summary>
        /// Gets or sets the date.
        /// </summary>
        /// <value>
        /// The date.
        /// </value>
        public DateTime Date => Original.starttime.ToDateTime();

        /// <summary>
        /// Gets or sets the duration.
        /// </summary>
        /// <value>
        /// The duration.
        /// </value>
        public int Duration => (int)(Original.endtime.ToDateTime() - Original.starttime.ToDateTime()).TotalSeconds;

        /// <summary>
        /// Gets or sets the size.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public uint Size => Original.size * 1024;
    }
}
