# Dahua.Api
* Available as [nuget](https://www.nuget.org/packages/Dahua.Api/) 
* `dotnet add package Dahua.Api --version 1.0.1`

* [![NuGet Downloads](https://img.shields.io/nuget/dt/Dahua.Api.svg)](https://www.nuget.org/packages/Dahua.Api/)

* Wrapper over Dahua SDK. It allows login, fetch videos list, download videos, get config list and more.

* Or just run console app [sample](https://raw.githubusercontent.com/vov4uk/Dahua.Api/main/src/Dahua.Api.Example/Program.cs)

Initialization
```cs
DahuaApi.Init();
```

Login. Returns [DahuaApi](https://github.com/vov4uk/Dahua.Api/blob/main/src/Dahua.Api/DahuaApi.cs)
```cs
var session = DahuaApi.Login("192.168.1.63", 37777, "admin", "pass");
```

Logout
```cs
session.Logout();
DahuaApi.Cleanup();
```

Print list of IP channels for NVR (IP Camera use hikapi.DefaultIpChannel)
```cs
Console.WriteLine("Channel:" + string.Join(",", session.AllChannels.Select(t => $"Channel{t.Id}_{t.Name}")));
```

Get machine name.
```cs
session.ConfigService.GetMachineName();
```

Get device serial number.
```cs
session.ConfigService.GetDeviceSerialNumber();
```

Get device type.
```cs
session.ConfigService.GetDeviceType();
```

Get device current time
```cs
session.ConfigService.GetTime();
```

Set device time
```cs
var currentTime = DateTime.Now;
session.ConfigService.SetTime(currentTime);
```

# Video service
Get videos list from IP Camera (default IP channel). Returns IReadOnlyCollection<[RemoteFile](https://github.com/vov4uk/Dahua.Api/blob/main/src/Dahua.Api/Data/RemoteFile.cs)>
```cs
var videos = session.VideoService.FindFiles(DateTime.Today, DateTime.Now);
```

Get videos list from IP Camera (specific IP channel)
```cs
int channel = 2;
var videos = session.VideoService.FindFiles(DateTime.Today, DateTime.Now, channel);
```

Download video
```cs
foreach (var video in videos)
{
    Console.WriteLine(video.Name);
    var name = $"{video.Date.ToString(DateFormat)}_{video.Duration}.mp4";
    var destinationPath = Path.Combine(@$"C:\Users\{Environment.UserName}\Desktop", name);
    var downloadId = session.VideoService.StartDownloadFile(video, destinationPath);
    if (downloadId > 0)
    {
        Console.WriteLine($"Downloading {destinationPath}");
        do
        {
            await Task.Delay(5000);
            var downloadProgress = session.VideoService.GetDownloadPosition(downloadId);
            Console.WriteLine($"Downloading {downloadProgress} %");
            if (downloadProgress.downloadSize == downloadProgress.totalSize)
            {
                session.VideoService.StopDownloadFile(downloadId);
                break;
            }
            else if (!downloadProgress.success)
            {
                throw new InvalidOperationException($"UpdateDownloadProgress failed, progress value = {downloadProgress}");
            }
        }
        while (true);
        Console.WriteLine($"Downloaded {destinationPath}");
    }
}
```
