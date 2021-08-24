import * as MutationTypes from "./app-mutations";

export default {
    state: {
        url: '',
        fileFormat: 'mp3',
        filePattern: '',
        videoId: ''
    },
    getters: {
        embeddedUrl: (state) => {
            return "https://youtube.com/embed/" + state.videoId;
        }
    },
    mutations: {
        [MutationTypes.UPDATE_URL](state, { url }) {
            state.url = url;
        },
        [MutationTypes.UPDATE_FILE_FORMAT](state, { fileFormat }){
            state.fileFormat = fileFormat;
        },
        [MutationTypes.UPDATE_FILE_PATTERN](state, { filePattern }){
            state.filePattern = filePattern;
        },
        [MutationTypes.UPDATE_VIDEO_ID](state, { videoId }){
            state.videoId = videoId;
        }
    },
    actions: {
        [MutationTypes.UPDATE_URL]({ commit }, { url }){
            commit(MutationTypes.UPDATE_URL, { url })
        },
        [MutationTypes.UPDATE_FILE_FORMAT]({ commit }, { fileFormat }){
            commit(MutationTypes.UPDATE_FILE_FORMAT, { fileFormat })
        },
        [MutationTypes.UPDATE_FILE_PATTERN]({ commit }, { filePattern }){
            commit(MutationTypes.UPDATE_FILE_PATTERN, { filePattern })
        },
        [MutationTypes.UPDATE_VIDEO_ID]({ commit }, { videoId }){
            commit(MutationTypes.UPDATE_VIDEO_ID, { videoId })
        }
    }

}