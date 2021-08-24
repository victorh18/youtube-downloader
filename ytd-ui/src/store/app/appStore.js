import * as MutationTypes from "./app-mutations";

export default {
    state: {
        url: '',
        fileFormat: '',
        filePattern: '',
    },
    mutations: {
        [MutationTypes.UPDATE_URL](state, { url }) {
            state.url = url;
        },
        [MutationTypes.UPDATE_FILE_FORMAT](state, { fileFormat }){
            state.fileFormat = fileFormat;
        },
        [MutationTypes.UPDATE_FILE_PATTERN](state, { filePattern }){
            state.filePattern = filePattern
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
        }
    }

}