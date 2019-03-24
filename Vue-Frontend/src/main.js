import Vue from "vue";
import "./plugins/vuetify";
import App from "./App.vue";
import VueStash from "vue-stash";
import store from "./store";
import VueCookie from 'vue-cookie';

Vue.config.productionTip = false;
Vue.use(VueStash);
Vue.use(VueCookie);

new Vue({
  render: h => h(App),
  data: { store }
}).$mount("#app");
