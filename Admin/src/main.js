import Vue from 'vue'
import App from './App.vue'
import store from './store'
import router from './routes'
import vuetify from './plugins/vuetify'
import configureRequest from './common/request'

import BlockUI from 'vue-blockui'
import VueTheMask from 'vue-the-mask'
import VuetifyConfirm from 'vuetify-confirm'

Vue.use(BlockUI)
Vue.use(VueTheMask)
Vue.use(VuetifyConfirm, {
  vuetify,
  buttonTrueText: 'Sim',
  buttonFalseText: 'Não',
  color: 'primary',
  icon: 'mdi-exclamation',
  title: 'Confirmação',
  width: 350,
  property: '$confirm'
})

configureRequest(Vue, router);

Vue.config.productionTip = false

new Vue({
  router,
  store,
  vuetify,
  render: h => h(App)
}).$mount('#app')
