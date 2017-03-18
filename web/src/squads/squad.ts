import { inject } from 'aurelia-framework';
import { RouteConfig } from 'aurelia-router';
import { SquadsService } from './squads-service';
import { SquadModel } from './squad-model';
import { SummaryItem } from '../shared/summary-item';
import { SponsorsService } from '../sponsors/sponsors-service';
import { PersonsService } from '../people/persons-service';
import { PersonSummaryItem } from '../people/person-summary-item';
import { ArticlesService } from '../articles/article-service';

@inject(SquadsService, SponsorsService, PersonsService, ArticlesService)
export class Squad {

    squad: SquadModel;
    sponsors: Array<SummaryItem>;
    persons: Array<PersonSummaryItem>;
    articles: Array<SummaryItem>;

    constructor(private squadsService: SquadsService, 
                private sponsorsService: SponsorsService,
                private personsService: PersonsService,
                private articleService: ArticlesService){}

    activate(params: any, routerConfig: RouteConfig){

        let id = params['id'] as number;

        this.squad = this.squadsService.getById(id); 
        this.sponsors = this.sponsorsService.getForSquadId(id);
        this.persons = this.personsService.getForSquadId(id);
        this.articles = this.articleService.getForSquadId(id);
    
        routerConfig.navModel.setTitle(this.squad.title);
    }    
}