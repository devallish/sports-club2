import { ClubModel } from './club-model';
import { FooterModel } from './shared/footer-model';
import { HttpClient, json } from 'aurelia-fetch-client';
import { HttpServiceBase } from './shared/http-service-base';

export class AppService extends HttpServiceBase {

    getAppInfo() : Promise<ClubModel>{
        return this.get<ClubModel>('clubs/home');
    }
}