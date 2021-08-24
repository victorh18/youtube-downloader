import Vue from "vue";
import Vuex from "vuex";

import appStore from "./app/appStore";

Vue.use(Vuex);

const store = new Vuex.Store({
    modules: {
        app: appStore
    }
})

export default store;