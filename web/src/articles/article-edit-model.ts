import { ArticleModel } from './article-model';
import { ArticleAssociation } from './article-association';

export class ArticleEditModel extends ArticleModel{ 

    publishDate : Date;
    removeDate : Date;
    associations : Array<ArticleAssociation>;
}