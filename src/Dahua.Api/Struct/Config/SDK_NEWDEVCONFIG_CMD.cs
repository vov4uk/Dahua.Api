namespace Dahua.Api.Struct.Config
{
    /**************************************************************************************************
    Configuration command corresponding CLIENT_GetNewDevConfig and CLIENT_SetNewDevConfig interface
    ***************************************************************************************************/
    /// <summary>
    /// Configuration command CLIENT_GetNewDevConfig/CLIENT_SetNewDevConfig
    /// </summary>
    internal static class SDK_NEWDEVCONFIG_CMD
    {
        /// <summary>
        /// Channel name (corresponding to AV CFG Channel Name)
        /// </summary>
        public const string CFG_CMD_CHANNELTITLE = "ChannelTitle";
        /// <summary>
        /// RTSP configuration (correspond CFG_RTSP_INFO_IN and CFG_RTSP_INFO_OUT)
        /// </summary>
        public const string CFG_CMD_RTSP = "RTSP";
        /// <summary>
        /// encoding storage point mapping configuration (corresponding to NET_A_CFG_RECORDTOSTORAGEPOINT_INFO)
        /// </summary>
        public const string CFG_CMD_RECORD_STORAGEPOINT = "RecordStoragePoint";
        /// <summary>
        /// Video storage point mapping configuration extension (corresponding to NET_A_CFG_RECORDTOSTORAGEPOINT_EX_INFO)
        /// </summary>
        public const string CFG_CMD_RECORD_STORAGEPOINT_EX = "RecordStoragePoint";
        /// <summary>
        /// UPnP configuration extension (corresponding to NET_A_CFG_UPNP_INFO)
        /// </summary>
        public const string CFG_CMD_UPNP = "UPnP";
        /// <summary>
        /// Timed Recording Configuration (corresponding to NET_CFG_RECORD_INFO)
        /// </summary>
        public const string CFG_CMD_RECORD = "Record";
        /// <summary>
        /// Fish eye details configuration (corresponding to NET_A_CFG_FISHEYE_DETAIL_INFO)
        /// </summary>
        public const string CFG_CMD_FISHEYE_INFO = "FishEye";
        /// <summary>
        /// Login Failure Alarm Configuration (corresponding to NET_A_CFG_LOGIN_FAILURE_ALARM)
        /// </summary>
        public const string CFG_CMD_LOGIN_FAILURE_ALARM = "LoginFailureAlarm";
        /// <summary>
        /// Fog penetration setting configuration (corresponding to NET_A_CFG_VIDEOINDEFOG_LIST)
        /// </summary>
        public const string CFG_CMD_VIDEOINDEFOG = "VideoInDefog";
    }
}