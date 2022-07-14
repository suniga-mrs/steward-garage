import type { IHttpClient } from './http-client.util';
import type { InjectionKey } from 'vue';

export const APP_HTTP_CLIENT = Symbol() as InjectionKey<IHttpClient>;
