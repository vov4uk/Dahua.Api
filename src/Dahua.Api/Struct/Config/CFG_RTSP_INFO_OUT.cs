namespace Dahua.Api.Struct.Config
{
    /// <summary>
    /// CFG_RTSP_INFO_OUT
    /// </summary>
    internal struct CFG_RTSP_INFO_OUT
    {
        /// <summary>
        /// The structure size
        /// </summary>
        public int nStructSize;
        /// <summary>
        ///Is the entire function enabled?
        /// </summary>
        public bool bEnable;
        /// <summary>
        /// RTSP service port
        /// </summary>
        public int nPort;
        /// <summary>
        /// RTP starting port
        /// </summary>
        public int nRtpStartPort;
        /// <summary>
        /// RTP Ending port
        /// </summary>
        public int nRtpEndPort;
        /// <summary>
        /// RTSP Over Http enabled
        /// </summary>
        public bool bHttpEnable;
        /// <summary>
        /// RTSP OverHttp port
        /// </summary>
        public int nHttpPort;
    }
}