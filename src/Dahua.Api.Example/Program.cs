using Dahua.Api;

var host = "192.168.1.68";
var port = 37777;
var user = "admin";
var password = "password";
string DateFormat = "yyyyMMdd_HHmmss";

try
{
    DahuaApi.Init();
    Console.WriteLine("Initialization successful!");
    //Log in
    Console.WriteLine("Logging in...");
    var session = DahuaApi.Login(host, port, user, password);
    Console.WriteLine("Login successful!");
    Console.WriteLine("Device time: " + session.ConfigService.GetTime());
    Console.WriteLine("Machine name: " + session.ConfigService.GetMachineName());
    Console.WriteLine("Device serial number: " + session.ConfigService.GetDeviceSerialNumber());
    Console.WriteLine("Device type: " + session.ConfigService.GetDeviceType());


    var videos = session.VideoService.FindFiles(DateTime.Today, DateTime.Now);


    Console.WriteLine($"Found {videos.Count} videos");
    foreach (var video in videos)
    {
        Console.WriteLine(video.Name);
        var name = $"{video.Date.ToString(DateFormat)}_{video.Duration}.mp4";

        var destinationPath = Path.Combine(@$"C:\Users\{Environment.UserName}\Desktop", "bin", name);
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
        break;
    }


    Console.WriteLine("Channel:" + string.Join(",", session.AllChannels.Select(t => $"Channel{t.Id}_{t.Name}")));

    //sign out
    session.Logout();
    Console.WriteLine("Logout completed");

    //Clean up
    DahuaApi.Cleanup();
    Console.WriteLine("Cleaning completed");
}
catch (Exception ex)
{
    Console.WriteLine(ex.ToString());
}