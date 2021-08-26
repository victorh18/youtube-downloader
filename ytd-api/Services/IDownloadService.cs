using System.Collections.Generic;

namespace ytd_api.Services.Interfaces {
    public interface IDownloadService {
        KeyValuePair<string, byte[]> DownloadVideo(string videoUrl, string format, string filenameFormat);
    }
}