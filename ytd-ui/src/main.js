import Vue from 'vue'
import App from './App.vue'
import vuetify from './plugins/vuetify'
import AppStore from './store/AppStore.js'

Vue.config.productionTip = false

new Vue({
  vuetify,
  render: h => h(App),
  store: AppStore
}).$mount('#app')
