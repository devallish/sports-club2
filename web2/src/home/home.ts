import { inject, bindable } from 'aurelia-framework';
import { RouteConfig } from 'aurelia-router';
import { SummaryItem } from '../shared/summary-item';
import { AlertModel, AlertLevels } from '../shared/alert-model';
import { SponsorsService } from '../sponsors/sponsors-service';
import { ArticlesService } from '../articles/article-service';
import { ClubModel } from '../club-model';

@inject(ArticlesService, SponsorsService)
export class Home{

    articles: Array<SummaryItem>;
    sponsors: Array<SummaryItem>;
    alert1: AlertModel;
    alert2: AlertModel;
    
    constructor(private articlesService : ArticlesService, private sponsorsService : SponsorsService){}

    async activate(params, routeConfig: RouteConfig ){

        let id = routeConfig.navModel.settings.clubId;
        
        // articles
        this.articles = await this.articlesService.getForClubId(id);
        // sponsors
        this.sponsors = await this.sponsorsService.getForClubId(id);
        // alerts

        // this.alert1 = { title: 'RUGBY IS CANCELLED THIS WEEKEND', 
        //     message: 'Due to the weather conditions ALL rugby at the Goodship Ground is cancelled', 
        //     level: AlertLevels.Information};

        // this.alert2 = { title: 'RUGBY IS NOT CANCELLED THIS WEEKEND', 
        //     message: 'Due to the weather conditions NO rugby at the Goodship Ground is cancelled', 
        //     level: AlertLevels.Important};

        
    }
}