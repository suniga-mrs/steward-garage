import { createApp, markRaw } from 'vue';
import { createPinia } from 'pinia';
import { APP_HTTP_CLIENT } from './utilities/dependency.util';
import { useHttpClient } from './utilities/http-client.util';
import App from './App.vue';
import router from './router';


const appHttpClientInstance = useHttpClient({
  baseUrl: '',
  timeout: 60000,
});

const app = createApp(App);
const pinia = createPinia();

pinia.use(({ store }) => {
  store.router = markRaw(router);
  store.httpClient = appHttpClientInstance;
});

app.provide(APP_HTTP_CLIENT, appHttpClientInstance);

// app.config.performance = true;

app.use(pinia);
app.use(router);

app.mount('#app');
