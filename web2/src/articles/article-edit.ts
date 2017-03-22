import { inject, View } from 'aurelia-framework';
import { RouteConfig } from 'aurelia-router';
import { ArticlesService } from './article-service';
import { ArticleAssociation } from './article-association';
import { ArticleEditModel } from './article-edit-model';

@inject(ArticlesService)
export class ArticleEdit{
    
    article: ArticleEditModel;
    editTypeDescription:string;
    
    constructor(private articlesService: ArticlesService){}

    async activate(params, routeConfig: RouteConfig ){
        let id = params['id'] as number;
        if (id === 0){
            this.editTypeDescription = 'New';
            this.article = await this.articlesService.getForNew();
            routeConfig.navModel.setTitle('New Article');
        }else{
            this.editTypeDescription = 'Edit';
            this.article = await this.articlesService.getForEditById(id);
            routeConfig.navModel.setTitle(`Editing ${this.article.title}`);
        }
    }

    async save(){
        // TODO: need to handle response 
        // - this is just assuming ok..
        let message = '';
        if (this.article.id === 0){
            await this.articlesService.create(this.article);
            message = 'Article has been created.';
        }else{
            await this.articlesService.update(this.article);
            message = 'Article has been updated.';
        }
        // TODO: us a nicer dialog for this..
        //       do we want to redirect somewhere?
        alert(message);
    }

    addAssociation(){
        alert('Association added - not really');
    }

    removeAssociation(){
        alert('Association removed - not really');
    }
}