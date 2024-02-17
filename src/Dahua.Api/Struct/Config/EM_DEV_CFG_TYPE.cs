namespace Dahua.Api.Struct.Config
{
    /// <summary>
    /// Configuration type
    /// </summary>
    internal enum EM_DEV_CFG_TYPE
    {
        /// <summary>
        /// Device property setup
        /// </summary>
        DEVICECFG = 0x0001,
        /// <summary>
        /// Network setup 
        /// </summary>
        NETCFG = 0x0002,
        /// <summary>
        /// Video channel setup
        /// </summary>
        CHANNELCFG = 0x0003,
        /// <summary>
        /// Preview parameter setup
        /// </summary>
        PREVIEWCFG = 0x0004,
        /// <summary>
        /// Record setup
        /// </summary>
        RECORDCFG = 0x0005,
        /// <summary>
        /// COM property setup
        /// </summary>
        COMMCFG = 0x0006,
        /// <summary>
        /// Alarm property setup
        /// </summary>
        ALARMCFG = 0x0007,
        /// <summary>
        /// DVR time setup
        /// </summary>
        TIMECFG = 0x0008,
        /// <summary>
        /// Audio talk parameter setup 
        /// </summary>
        TALKCFG = 0x0009,
        /// <summary>
        /// Auto matrix setup， corresponding to NET_DEV_AUTOMT_CFG
        /// </summary>
        AUTOMTCFG = 0x000A,
        /// <summary>
        /// Local matrix control strategy setup
        /// </summary>
        VEDIO_MARTIX = 0x000B,
        /// <summary>
        /// Multiple DDNS setup
        /// </summary>
        MULTI_DDNS = 0x000C,
        /// <summary>
        /// Snapshot corresponding setup 
        /// </summary>
        SNAP_CFG = 0x000D,
        /// <summary>
        /// HTTP path setup 
        /// </summary>
        WEB_URL_CFG = 0x000E,
        /// <summary>
        /// FTP upload setup
        /// </summary>
        FTP_PROTO_CFG = 0x000F,
        /// <summary>
        /// Platform embedded setup. Now the channel parameter represents the platform type. channel=4:Bell alcoate;channel=10: Net view;channel=11:U CNC channel = 51 AMP
        /// </summary>
        INTERVIDEO_CFG = 0x0010,
        /// <summary>
        /// Privacy mask setup
        /// </summary>
        VIDEO_COVER = 0x0011,
        /// <summary>
        /// Transmission strategy. Video quality\Fluency
        /// </summary>
        TRANS_STRATEGY = 0x0012,
        /// <summary>
        /// Record download strategy setup:high-speed\general download
        /// </summary>
        DOWNLOAD_STRATEGY = 0x0013,
        /// <summary>
        /// Video watermark setup
        /// </summary>
        WATERMAKE_CFG = 0x0014,
        /// <summary>
        /// Wireless network setup
        /// </summary>
        WLAN_CFG = 0x0015,
        /// <summary>
        /// Search wireless device setup
        /// </summary>
        WLAN_DEVICE_CFG = 0x0016,
        /// <summary>
        /// Auto register parameter setup, NET_DEV_REGISTER_SERVER
        /// </summary>
        REGISTER_CFG = 0x0017,
        /// <summary>
        /// Camera property setup
        /// </summary>
        CAMERA_CFG = 0x0018,
        /// <summary>
        /// IR alarm setup
        /// </summary>
        INFRARED_CFG = 0x0019,
        /// <summary>
        /// Sniffer setup
        /// </summary>
        SNIFFER_CFG = 0x001A,
        /// <summary>
        /// Mail setup
        /// </summary>
        MAIL_CFG = 0x001B,
        /// <summary>
        /// DNS setup
        /// </summary>
        DNS_CFG = 0x001C,
        /// <summary>
        /// NTP setup
        /// </summary>
        NTP_CFG = 0x001D,
        /// <summary>
        /// Audio detection setup
        /// </summary>
        AUDIO_DETECT_CFG = 0x001E,
        /// <summary>
        /// Storage position setup
        /// </summary>
        STORAGE_STATION_CFG = 0x001F,
        /// <summary>
        /// PTZ operation property(It is invalid now. Please use CLIENT_GetPtzOptAttr to get PTZ operation property.)
        /// </summary>
        PTZ_OPT_CFG = 0x0020,
        /// <summary>
        /// Daylight Saving Time (DST)setup
        /// </summary>
        DST_CFG = 0x0021,
        /// <summary>
        /// Alarm center setup
        /// </summary>
        ALARM_CENTER_CFG = 0x0022,
        /// <summary>
        /// Video OSD setup
        /// </summary>
        VIDEO_OSD_CFG = 0x0023,
        /// <summary>
        /// CDMA\GPRS configuration
        /// </summary>
        CDMAGPRS_CFG = 0x0024,
        /// <summary>
        /// IP Filter configuration
        /// </summary>
        IPFILTER_CFG = 0x0025,
        /// <summary>
        /// Talk encode configuration
        /// </summary>
        TALK_ENCODE_CFG = 0x0026,
        /// <summary>
        /// The length of the video package configuration
        /// </summary>
        RECORD_PACKET_CFG = 0x0027,
        /// <summary>
        /// SMS MMS configuration
        /// </summary>
        MMS_CFG = 0x0028,
        /// <summary>
        /// SMS to activate the wireless connection configuration
        /// </summary>
        SMSACTIVATION_CFG = 0x0029,
        /// <summary>
        /// Dial-up activation of a wireless connection configuration
        /// </summary>
        DIALINACTIVATION_CFG = 0x002A,
        /// <summary>
        /// Capture network configuration
        /// </summary>
        SNIFFER_CFG_EX = 0x0030,
        /// <summary>
        /// Download speed limit
        /// </summary>
        DOWNLOAD_RATE_CFG = 0x0031,
        /// <summary>
        /// Panorama switch alarm configuration
        /// </summary>
        PANORAMA_SWITCH_CFG = 0x0032,
        /// <summary>
        /// Lose focus alarm configuration
        /// </summary>
        LOST_FOCUS_CFG = 0x0033,
        /// <summary>
        /// Alarm decoder configuration
        /// </summary>
        ALARM_DECODE_CFG = 0x0034,
        /// <summary>
        /// Video output configuration
        /// </summary>
        VIDEOOUT_CFG = 0x0035,
        /// <summary>
        /// Preset enable configuration
        /// </summary>
        POINT_CFG = 0x0036,
        /// <summary>
        /// IP COLLISION configuration
        /// </summary>
        IP_COLLISION_CFG = 0x0037,
        /// <summary>
        /// OSD overlay enable configuration
        /// </summary>
        OSD_ENABLE_CFG = 0x0038,
        /// <summary>
        /// Local alarm configuration(Structure NET_ALARMIN_CFG_EX)
        /// </summary>
        LOCALALARM_CFG = 0x0039,
        /// <summary>
        /// Network alarm configuration(Structure NET_ALARMIN_CFG_EX)
        /// </summary>
        NETALARM_CFG = 0x003A,
        /// <summary>
        /// Motion detection configuration(Structure NET_MOTION_DETECT_CFG_EX)
        /// </summary>
        MOTIONALARM_CFG = 0x003B,
        /// <summary>
        /// Video loss configuration(Structure NET_VIDEO_LOST_CFG_EX)
        /// </summary>
        VIDEOLOSTALARM_CFG = 0x003C,
        /// <summary>
        /// Camera masking configuration(Structure NET_BLIND_CFG_EX)
        /// </summary>
        BLINDALARM_CFG = 0x003D,
        /// <summary>
        /// HDD alarm configuration(Structure NET_DISK_ALARM_CFG_EX)
        /// </summary>
        DISKALARM_CFG = 0x003E,
        /// <summary>
        /// Network disconnection alarm configuration(Structure NET_NETBROKEN_ALARM_CFG_EX)
        /// </summary>
        NETBROKENALARM_CFG = 0x003F,
        /// <summary>
        /// Digital channel info of front encoders(Hybrid DVR use,Structure DEV_ENCODER_CFG)
        /// </summary>
        ENCODER_CFG = 0x0040,
        /// <summary>
        /// TV adjust configuration(Now the channel parameter represents the TV number (from 0), Structure DHDEV_TVADJUST_CFG)
        /// </summary>
        TV_ADJUST_CFG = 0x0041,
        /// <summary>
        /// about vehicle configuration
        /// </summary>
        ABOUT_VEHICLE_CFG = 0x0042,
        /// <summary>
        /// ATM ability information
        /// </summary>
        ATM_OVERLAY_ABILITY = 0x0043,
        /// <summary>
        /// ATM overlay configuration
        /// </summary>
        ATM_OVERLAY_CFG = 0x0044,
        /// <summary>
        /// Decoder tour configuration
        /// </summary>
        DECODER_TOUR_CFG = 0x0045,
        /// <summary>
        /// SIP configuration
        /// </summary>
        SIP_CFG = 0x0046,
        /// <summary>
        /// WIFI ap configuration
        /// </summary>
        VICHILE_WIFI_AP_CFG = 0x0047,
        /// <summary>
        /// Static
        /// </summary>
        STATICALARM_CFG = 0x0048,
        /// <summary>
        /// decode policy configuration(Structure DHDEV_DECODEPOLICY_CFG,channel start with 0)
        /// </summary>
        DECODE_POLICY_CFG = 0x0049,
        /// <summary>
        /// Device relative config (Structure DHDEV_MACHINE_CFG)
        /// </summary>
        MACHINE_CFG = 0x004A,
        /// <summary>
        /// MAC COLLISIONs configuration(Structure ALARM_MAC_COLLISION_CFG)
        /// </summary>
        MAC_COLLISION_CFG = 0x004B,
        /// <summary>
        /// RTSP configuration(structure DHDEV_RTSP_CFG)
        /// </summary>
        RTSP_CFG = 0x004C,
        /// <summary>
        /// 232 com card signal event configuration(structure COM_CARD_SIGNAL_LINK_CFG)
        /// </summary>
        NET_232_COM_CARD_CFG = 0x004E,
        /// <summary>
        /// 485 com card signal event configuration(structure COM_CARD_SIGNAL_LINK_CFG)
        /// </summary>
        NET_485_COM_CARD_CFG = 0x004F,
        /// <summary>
        /// extend FTP upload setup(Structure DHDEV_FTP_PROTO_CFG_EX)
        /// </summary>
        FTP_PROTO_CFG_EX = 0x0050,
        /// <summary>
        /// SYSLOG remote server config (Structure DHDEV_SYSLOG_REMOTE_SERVER)
        /// </summary>
        SYSLOG_REMOTE_SERVER = 0x0051,
        /// <summary>
        /// Extended com configuration(structure DHDEV_COMM_CFG_EX)
        /// </summary>
        COMMCFG_EX = 0x0052,
        /// <summary>
        /// net card configuration(structure DHDEV_NETCARD_CFG)
        /// </summary>
        NETCARD_CFG = 0x0053,
        /// <summary>
        /// Video backup format(structure DHDEV_BACKUP_VIDEO_FORMAT)
        /// </summary>
        BACKUP_VIDEO_FORMAT = 0x0054,
        /// <summary>
        /// stream encrypt configuration(structure DHEDV_STREAM_ENCRYPT)
        /// </summary>
        STREAM_ENCRYPT_CFG = 0x0055,
        /// <summary>
        /// IP filter extended configuration(structure DHDEV_IPIFILTER_CFG_EX)
        /// </summary>
        IPFILTER_CFG_EX = 0x0056,
        /// <summary>
        /// custom configuration(structure DHDEV_CUSTOM_CFG)
        /// </summary>
        CUSTOM_CFG = 0x0057,
        /// <summary>
        /// Search wireless device extended setup(structure DHDEV_WLAN_DEVICE_LIST_EX)
        /// </summary>
        WLAN_DEVICE_CFG_EX = 0x0058,
        /// <summary>
        /// ACC power off configuration(structure DHDEV_ACC_POWEROFF_CFG)
        /// </summary>
        ACC_POWEROFF_CFG = 0x0059,
        /// <summary>
        /// explosion proof alarm configuration(structure DHDEV_EXPLOSION_PROOF_CFG)
        /// </summary>
        EXPLOSION_PROOF_CFG = 0x005a,
        /// <summary>
        /// Network extended setup(struct DHDEV_NET_CFG_EX)
        /// </summary>
        NETCFG_EX = 0x005b,
        /// <summary>
        /// light control config(struct DHDEV_LIGHTCONTROL_CFG)
        /// </summary>
        LIGHTCONTROL_CFG = 0x005c,
        /// <summary>
        /// 3G flow info config(struct DHDEV_3GFLOW_INFO_CFG)
        /// </summary>
        NET_3GFLOW_CFG = 0x005d,
        /// <summary>
        /// IPv6 config(struct DHDEV_IPV6_CFG)
        /// </summary>
        IPV6_CFG = 0x005e,
        /// <summary>
        /// SNMP config(struct DHDEV_NET_SNMP_CFG)
        /// </summary>
        SNMP_CFG = 0x005f,
        /// <summary>
        /// snap control config(struct DHDEV_SNAP_CONTROL_CFG)
        /// </summary>
        SNAP_CONTROL_CFG = 0x0060,
        /// <summary>
        /// GPS mode config(struct DHDEV_GPS_MODE_CFG)
        /// </summary>
        GPS_MODE_CFG = 0x0061,
        /// <summary>
        /// Snap upload config(struct DHDEV_SNAP_UPLOAD_CFG)
        /// </summary>
        SNAP_UPLOAD_CFG = 0x0062,
        /// <summary>
        /// Speed limit config(struct DHDEV_SPEED_LIMIT_CFG)
        /// </summary>
        SPEED_LIMIT_CFG = 0x0063,
        /// <summary>
        /// iSCSI config(struct DHDEV_ISCSI_CFG), need reboot
        /// </summary>
        ISCSI_CFG = 0x0064,
        /// <summary>
        /// WIFI config(struct DHDEV_WIRELESS_ROUTING_CFG)
        /// </summary>
        WIRELESS_ROUTING_CFG = 0x0065,
        /// <summary>
        /// enclosure config(struct DHDEV_ENCLOSURE_CFG)
        /// </summary>
        ENCLOSURE_CFG = 0x0066,
        /// <summary>
        /// enclosure version config(struct DHDEV_ENCLOSURE_VERSION_CFG)
        /// </summary>
        ENCLOSURE_VERSION_CFG = 0x0067,
        /// <summary>
        /// Raid event config(struct DHDEV_RAID_EVENT_CFG)
        /// </summary>
        RIAD_EVENT_CFG = 0x0068,
        /// <summary>
        /// fire alarm config(struct DHDEV_FIRE_ALARM_CFG)
        /// </summary>
        FIRE_ALARM_CFG = 0x0069,
        /// <summary>
        /// local alarm name config(string like "Name1&amp;name2&amp;name3...")
        /// </summary>
        LOCALALARM_NAME_CFG = 0x006a,
        /// <summary>
        /// urgency storage config(struct DHDEV_URGENCY_RECORD_CFG)
        /// </summary>
        URGENCY_RECORD_CFG = 0x0070,
        /// <summary>
        /// elevator parameter config(struct DHDEV_ELEVATOR_ATTRI_CFG)
        /// </summary>
        ELEVATOR_ATTRI_CFG = 0x0071,
        /// <summary>
        /// TM overlay function. For latest ATM series product only.  Support devices of 32-channel or higher.( struct DHDEV_ATM_OVERLAY_CONFIG_EX)
        /// </summary>
        ATM_OVERLAY_CFG_EX = 0x0072,
        /// <summary>
        /// MAC filter config(struct DHDEV_MACFILTER_CFG)
        /// </summary>
        MACFILTER_CFG = 0x0073,
        /// <summary>
        /// MAC,IP filter config(need ip,mac one to one corresponding)(struct DHDEV_MACIPFILTER_CFG)
        /// </summary>
        MACIPFILTER_CFG = 0x0074,
        /// <summary>
        /// stream encrypt(encrypt plan)(struct DHEDV_STREAM_ENCRYPT)
        /// </summary>
        STREAM_ENCRYPT_TIME_CFG = 0x0075,
        /// <summary>
        /// limit bit rate config(struct DHDEV_LIMIT_BIT_RATE)
        /// </summary>
        LIMIT_BIT_RATE_CFG = 0x0076,
        /// <summary>
        /// snap extern config(struct DHDEV_SNAP_CFG_EX)
        /// </summary>
        SNAP_CFG_EX = 0x0077,
        /// <summary>
        /// decoder url config(struct DHDEV_DECODER_URL_CFG)
        /// </summary>
        DECODER_URL_CFG = 0x0078,
        /// <summary>
        /// tour enable config(struct DHDEV_TOUR_ENABLE_CFG)
        /// </summary>
        TOUR_ENABLE_CFG = 0x0079,
        /// <summary>
        /// WIFI ap extern config(struct DHDEV_VEHICLE_WIFI_AP_CFG_EX)
        /// </summary>
        VICHILE_WIFI_AP_CFG_EX = 0x007a,
        /// <summary>
        /// encoder extern config(struct DEV_ENCODER_CFG_EX)
        /// </summary>
        ENCODER_CFG_EX = 0x007b,
        /// <summary>
        /// encoder extern config(struct DEV_ENCODER_CFG_EX2)
        /// </summary>
        ENCODER_CFG_EX2 = 0x007c,
    }
}