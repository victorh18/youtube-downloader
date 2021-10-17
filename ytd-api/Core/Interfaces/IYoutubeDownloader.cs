using System.Collections.Generic;

namespace ytd_api.Core.Interfaces
{
    public interface IYoutubeDownloader {
        KeyValuePair<string, byte[]> DownloadVideo(string videoUrl, string format, string filenamePattern);
        KeyValuePair<string, byte[]> DownloadAudio(string audioUrl, string format, string filenamePattern);
        string GetFilename(string fileFormat, string filenamePattern);
    }
}