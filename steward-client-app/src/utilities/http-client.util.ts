
import { merge } from "./function.util";
import axios from 'axios';
import qs from 'qs';

interface IHttpClientOptions {
    baseUrl: string,
    headers?: Record<string, string>,
    timeout?: number,
}

// type THttpClientSuccessResponse = {
//     data: any,
// }

// type THttpClientErrorResponse = Record<any, any>;

// type THttpResponse = THttpClientSuccessResponse | THttpClientErrorResponse;

interface IHttpGetOptions {
    url: string,
    data?: Record<string, any>,
    headers?: Record<string, string>,
}

interface IHttpPostOptions {
    url: string,
    data?: Record<string, any>,
    headers?: Record<string, string>,
}

interface IHttpDeleteOptions extends IHttpGetOptions { }
interface IHttpPutOptions extends IHttpPostOptions { }

interface IHttpClient {
    //public methods
    get: (options: IHttpGetOptions) => any

    post: (options: IHttpPostOptions) => any

    delete: (options: IHttpDeleteOptions) => any

    put: (options: IHttpPutOptions) => any

}

function useHttpClient(options: IHttpClientOptions): IHttpClient {

    const _defaults: IHttpClientOptions = {
        timeout: 30000,
        baseUrl: "",
        headers: {
            "Content-Type": "application/x-www-form-urlencoded"
        }
    };

    const _options = merge(_defaults, options);

    const _httpClient = axios.create({
        baseURL: _options.baseUrl,
        timeout: _options.timeout,
        headers: _options.headers
    });

    //REQUEST INTERCEPTOR
    _httpClient.interceptors.request.use(function (config) {
        // Do something before request is sent

        let _method = config?.method || "";

        //  mas-signature
        // if (['post', 'get', 'delete'].includes(_method)) {
        //     console.log(config)

        //     const requestContent = _method == 'post' ? config.data : config.params;

        //     // console.log(requestContent)

        //     // const generateRequestSignature = httpSignGenerate(JSON.stringify(requestContent));

        //     // config.headers[signatureHeader] = generateRequestSignature
        // }

        let _headers = config?.headers || {};

        //transform content
        const contentType = Object.keys(_headers).includes("Content-Type") ?
            _headers["Content-Type"] : "";

        if (contentType == "application/x-www-form-urlencoded") {
            config.data = qs.stringify(config.data)
            config.params = qs.stringify(config.params)
        }

        return config;

    }, function (error) {
        // Do something with request error
        return Promise.reject(error);
    });

    //RESPONSE INTERCEPTOR
    _httpClient.interceptors.response.use(function (response) {

        let errorMessage = ''

        if (response.config.method == "get") {

            let requestBody = typeof response.data == 'object' ? JSON.stringify(response.data) : response.data + '';

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

    }, function (error) {
        // Any status codes that falls outside the range of 2xx cause this function to trigger
        // Do something with response error
        // showUiError(JSON.stringify(error))
        console.error(error);

        return Promise.reject(error);
    });

    function $get(options: IHttpGetOptions) {

        return _httpClient.get(options.url, {
            headers: options.headers,
            params: options.data
        });

    }

    function $post(options: IHttpPostOptions) {
        return _httpClient.post(options.url, options.data);

    }

    function $delete(options: IHttpDeleteOptions) {

        return _httpClient.delete(options.url, {
            headers: options.headers,
            params: options.query
        });

    }

    function $put(options: IHttpPutOptions) {

        return _httpClient.put(options.url, {
            headers: options.headers,
            data: options.data
        });

    }

    return {
        get: $get,
        post: $post,
        delete: $delete,
        put: $put
    }
}

export default useHttpClient;