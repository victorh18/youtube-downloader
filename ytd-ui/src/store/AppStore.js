import Vue from "vue";
import Vuex from "vuex";

Vue.use(Vuex);

const store = new Vuex.Store({
    state: {
        fileFormat: "",
        url: "",
        filePattern: ""
    },
    mutations: {
        updateFileFormat(state, payload) {
            state.fileFormat = payload
        }
    }
})

export default store;