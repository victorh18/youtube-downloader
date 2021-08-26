using ytd_api.Services.Interfaces;

namespace ytd_api.Services.Implementations
{
    public class MetadataService : IMetadataService {
        public MetadataService()
        {
            
        }

        public string getVideoId(string videoUrl) {
            string id = "";
            if (videoUrl.Contains("https://www.youtube.com/watch?v="))
            {
                id = videoUrl.Substring("https://www.youtube.com/watch?v=".Length, videoUrl.Length - "https://www.youtube.com/watch?v=".Length);
            }
            if (videoUrl.Contains(@"https://youtu.be/"))
            {
                id = videoUrl.Substring(@"https://youtu.be/".Length, videoUrl.Length - @"https://youtu.be/".Length); 
            }

            return id;
        }
    }
}