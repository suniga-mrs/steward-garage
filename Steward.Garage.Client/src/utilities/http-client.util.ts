import { merge } from './function.util';
import axios from 'axios';
import qs from 'qs';

interface IHttpClientOptions {
  baseUrl: string;
  headers?: Record<string, string>;
  timeout?: number;
}

interface IHttpGetOptions {
  url: string;
  data?: Record<string, any>;
  headers?: Record<string, string>;
}

interface IHttpPostOptions {
  url: string;
  data?: Record<string, any>;
  headers?: Record<string, string>;
}

interface IHttpDeleteOptions extends IHttpGetOptions {}
// interface IHttpPutOptions extends IHttpPostOptions {}

export interface IHttpClient {
  //public methods
  get: (options: IHttpGetOptions) => any;

  post: (options: IHttpPostOptions) => any;

  delete: (options: IHttpDeleteOptions) => any;

  // put: (options: IHttpPutOptions) => any;
}

function useHttpClient(options: IHttpClientOptions): IHttpClient {
  const _defaults: IHttpClientOptions = {
    timeout: 30000,
    baseUrl: '',
    headers: {
      'Content-Type': 'application/x-www-form-urlencoded',
    },
  };

  const _options = merge(_defaults, options);

  const _httpClient = axios.create({
    baseURL: _options.baseUrl,
    timeout: _options.timeout,
    headers: _options.headers,
  });

  //REQUEST INTERCEPTOR
  _httpClient.interceptors.request.use(
    function (config) {
      // Do something before request is sent

      const _method = config?.method || '';

      //  mas-signature
      // if (['post', 'get', 'delete'].includes(_method)) {
      //     console.log(config)

      //     const requestContent = _method == 'post' ? config.data : config.params;

      //     // console.log(requestContent)

      //     // const generateRequestSignature = httpSignGenerate(JSON.stringify(requestContent));

      //     // config.headers[signatureHeader] = generateRequestSignature
      // }

      const _headers = config?.headers || {};

      //transform content
      const contentType = Object.keys(_headers).includes('Content-Type')
        ? _headers['Content-Type']
        : '';

      // debugger;

      if (contentType == 'application/x-www-form-urlencoded') {

      }

      config.data = qs.stringify(config.data);
      config.params = qs.stringify(config.params);
      config.url = config.url + '?' + qs.stringify(config.params);

      return config;
    },
    function (error) {
      // Do something with request error
      return Promise.reject(error);
    }
  );

  //RESPONSE INTERCEPTOR
  _httpClient.interceptors.response.use(
    function (response) {
      // const errorMessage = '';

      if (response.config.method == 'get') {
        // const requestBody =
        //   typeof response.data == 'object'
        //     ? JSON.stringify(response.data)
        //     : response.data + '';
        // const generatedResponseSignature = httpSignGenerate(requestBody);
        // if (response.headers[signatureHeader] !== generatedResponseSignature) {
        //     errorMessage = "There was an error with the response from the server. Please contact MIS/IT.";
        // }
        // if (errorMessage != '') {
        //     showUiError(errorMessage)
        //     return {
        //         error: "There was an error with the response from the server. Please contact MIS/IT."
        //     }
        // }
      }

      //showUiError('showUiError')

      return response;
    },
    function (error) {
      // Any status codes that falls outside the range of 2xx cause this function to trigger
      // Do something with response error
      // showUiError(JSON.stringify(error))
      console.error(error);

      return Promise.reject(error);
    }
  );

  function $get(options: IHttpGetOptions) {
    // debugger;
    return fetch(options.url + '?' + qs.stringify(options.data))
      .then((res) => res.json())
      .then((resData) => resData);

    // return _httpClient.get(options.url, {
    //   headers: options.headers,
    //   params: options.data,
    // });
  }

  function $post(options: IHttpPostOptions) {
    return fetch(options.url, {
      method: 'POST',
      body: qs.stringify(options.data),
      headers: {
        // 'Content-Type': 'application/json',
        'Content-Type': 'application/x-www-form-urlencoded',
      },
    })
      .then((res) => res.json())
      .then((resData) => resData);

    // return _httpClient.post(options.url, options.data);
  }

  function $delete(options: IHttpDeleteOptions) {
    return fetch(options.url + '?' + qs.stringify(options.data), {
      method: 'DELETE',
    })
      .then((res) => res.json())
      .then((resData) => resData);
    // return _httpClient.delete(options.url, {
    //   headers: options.headers,
    //   params: options.data,
    // });
  }

  // function $put(options: IHttpPutOptions) {
  //   return _httpClient.put(options.url, {
  //     headers: options.headers,
  //     data: options.data,
  //   });
  // }

  return {
    get: $get,
    post: $post,
    delete: $delete,
    // put: $put,
  };
}

export default useHttpClient;
