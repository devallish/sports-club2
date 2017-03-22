import { inject, View } from 'aurelia-framework';
import { ArticlesService } from './article-service';
import { SummaryItem } from '../shared/summary-item';

@inject(ArticlesService)
export class Articles{
    
    articles: Array<SummaryItem>;

    constructor(private articleService: ArticlesService){ }

    created(owningView: View, thisView: View){

        this.articles = this.articleService.getForSquadId(1);
    }
}