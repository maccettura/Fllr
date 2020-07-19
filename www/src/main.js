import Vue from 'vue'
import App from './App.vue'
import Vuelidate from 'vuelidate'
import Toasted from 'vue-toasted'

Vue.use(Vuelidate)
Vue.use(Toasted)

Vue.config.productionTip = false

new Vue({
  render: h => h(App),
}).$mount('#app')