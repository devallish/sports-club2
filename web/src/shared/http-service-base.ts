import { HttpClient, json } from 'aurelia-fetch-client';
import { inject } from 'aurelia-framework';
import environment from '../env';

@inject(HttpClient, environment.apiBaseUrlKey)
export class HttpServiceBase {
    
    httpClient: HttpClient;

    constructor(httpClient: HttpClient, apiBaseUrl: string ) {
   
        this.httpClient = httpClient;
   
        this.httpClient.configure(config =>
            config.withBaseUrl(apiBaseUrl)
                .withDefaults({
                    credentials: 'same-origin',
                    headers: {
                        'Accept': 'application/json',
                        'X-Requested-With': 'Fetch'
                    }
                }));
    }

    get<T>(url: string): Promise<T> {
        return this.httpClient
            .fetch(url)
            .then(response => {
                console.log("http-service-base - begin");
                console.log(response);
                let data = response.json() as Promise<T>;
                console.log(data);
                console.log("http-service-base - end");
                return data;
            })
            .catch(error => console.error(error));
    }

    post<T>(url: string, data: T): Promise<Response>{
        
        return this.httpClient
                .fetch(url, {
                    method: 'post',
                    body: json(data)
                })
                .catch(error => console.error(error));
    }
    put<T>(url: string, data: T): Promise<Response>{

        return this.httpClient
                .fetch(url, {
                    method: 'put',
                    body: json(data)
                })
                .catch(error => console.error(error));
    }
    //test() {

        //this.httpClient.fetch("someapi")
        //    .then(response => response.json())
        //    .then(data => {
        //        this.httpClient.fetch("childrecords01")
        //            .then(response => response.json())
        //            .then(childData => data.childData = childData);
        //        this.httpClient.fetch("childRecords02")
        //            .then(response => response.json())
        //            .then(childData => data.childData2 = childData);
        //        return data;
        //    });
    //}

}