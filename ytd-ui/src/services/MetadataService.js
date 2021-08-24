import axios from 'axios'
import store from '../store/store'

import * as AppMutations from '../store/app/app-mutations'

const baseUrl = process.env.VUE_APP_API_URL;

export default {
    async getVideoId(url) {
        const request = {
            method: 'get',
            url: baseUrl + '/Metadata',
            params: {
                url: url
            }
        };
        
        try {
            let response = await axios(request);
            let data = await response.data;
            let videoId = data.id;
            store.commit(AppMutations.UPDATE_VIDEO_ID, { videoId })
            return videoId;
            
        } catch (error) {
            console.log(error)
        }
    }
}