using System;
using System.IO;
using NYoutubeDL;
using ytd_api.Core.Interfaces;
using System.Linq;
using System.Collections.Generic;

namespace ytd_api.Infrastructure 
{
    public class YoutubeDownloader : IYoutubeDownloader
    {
        const string FILE_DATE_FORMAT = "yyyymmss_hhMMss";
        public KeyValuePair<string, byte[]> DownloadAudio(string audioUrl, string format, string filenamePattern)
        {
            var ydlClient = new YoutubeDL();
            ydlClient.Options.PostProcessingOptions.ExtractAudio = true;
            ydlClient.Options.PostProcessingOptions.AudioFormat = NYoutubeDL.Helpers.Enums.AudioFormat.mp3;
            ydlClient.Options.PostProcessingOptions.AudioQuality = "0";
            return Download(ydlClient, audioUrl, format, filenamePattern);
            
        }

        public KeyValuePair<string, byte[]> DownloadVideo(string videoUrl, string format, string filenamePattern)
        {
            var ydlClient = new YoutubeDL();
            ydlClient.Options.VideoFormatOptions.Format = NYoutubeDL.Helpers.Enums.VideoFormat.mp4;
            return Download(ydlClient, videoUrl, format, filenamePattern);
        }

        public string GetFilename(string fileFormat, string filenamePattern)
        {
            var filePrefix = DateTime.Now.ToString(FILE_DATE_FORMAT);
            var fileRoot = Path.Combine(AppContext.BaseDirectory, filePrefix);
            var filePath = fileRoot + fileFormat;
            return fileRoot + filenamePattern;
        }

        public KeyValuePair<string, byte[]> Download(YoutubeDL ydlClient, string url, string format, string filenamePattern) {
            var fileName = GetFilename(format, filenamePattern);
            var filePrefix = Path.GetFileName(fileName).Substring(0, FILE_DATE_FORMAT.Length);
            Console.WriteLine(filePrefix);
            Console.WriteLine(fileName);

            ydlClient.Options.FilesystemOptions.Output = fileName;
            ydlClient.VideoUrl = url;
            ydlClient.Download();

            var newFilePath = Directory.GetFiles(AppContext.BaseDirectory, filePrefix + "*").First();
            var audioName = Path.GetFileName(newFilePath).Substring(filePrefix.Length);
            var file = System.IO.File.ReadAllBytes(newFilePath);
            return new KeyValuePair<string, byte[]>(audioName, file);
            
        }
    }
}