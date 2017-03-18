import { inject } from 'aurelia-framework';
import { RouteConfig } from 'aurelia-router';
import { ArticlesService } from './article-service';
import { ArticleModel } from './article-model';
import { SummaryItem } from '../shared/summary-item';

@inject(ArticlesService)
export class Article{
    
    article: ArticleModel;
    relatedArticles: Array<SummaryItem>;

    constructor (private articlesService: ArticlesService){
    }

    async activate(params, routeConfig: RouteConfig ){
        let id = params['id'] as number;
        this.article = await this.articlesService.getById(id);
        this.relatedArticles = this.articlesService.getRelatedToId(id);
    }
}