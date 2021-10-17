using System.Collections.Generic;


namespace ytd_api.Core.Interfaces {
    public interface IDownloadService {
        KeyValuePair<string, byte[]> Download(string url, string format, string filenameFormat);
    }
}