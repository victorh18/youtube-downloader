import axios from 'axios'
import store from '../store/store'

const baseUrl = process.env.VUE_APP_API_URL;

export default {
    async downloadVideo(){
        var { url, fileFormat, filePattern } = store.state.app

        const request = {
          method: "get",
          url: baseUrl + "/Download",
          responseType: "blob",
          params: {
            url: url,
            format: fileFormat,
            filenameFormat: filePattern,
          },
        };

        try {
            let response = await axios(request);
            let { data, headers } = response;

            const blob = new Blob([data]);
            const link = document.createElement("a");
            link.href = URL.createObjectURL(blob);
            let filename = decodeURI(headers["x-filename"]);
            console.log(filename);
            link.download = filename;
            link.click();
            URL.revokeObjectURL(link.href);

        } catch (error) {
            console.log(error);
        }

      },
}