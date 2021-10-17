namespace ytd_api.Core.Interfaces {
    public interface IMetadataService {
        string getVideoId(string videoUrl);
        string getApiVersion();
    }
}