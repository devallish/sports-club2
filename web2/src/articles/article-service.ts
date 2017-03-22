import { json } from 'aurelia-fetch-client';
import { ArticleModel } from './article-model';
import { SummaryItem } from '../shared/summary-item';
import { HttpServiceBase } from '../shared/http-service-base';
import { ArticleEditModel } from './article-edit-model';
import { ArticleAssociation } from './article-association';

export class ArticlesService extends HttpServiceBase{

    getById(id:number) : Promise<ArticleModel>{
        return super.get(`articles/${id}`)
    }

    getForNew() : Promise<ArticleEditModel>{
        return super.get(`articles/new`);
    }

    getForEditById(id: number): Promise<ArticleEditModel>{
        return super.get(`articles/${id}/edit`);
    }


    create(article: ArticleEditModel): Promise<Response>{
        return super.post<ArticleEditModel>('articles', article);    
    }
    
    update(article: ArticleEditModel): Promise<Response>{
        return super.put<ArticleEditModel>('articles', article);
    }
        
    // }
    // getById(id:number): ArticleModel{

    //     let article = new ArticleModel();
    //     article.id = id;
    //     article.title = `Title of ${id}`;
    //     article.summary = 'Summary of article';
    //     article.date = new Date(2017, 1, 3);
    //     article.content1 = "A mixed Andover side took the field at Winchester last Saturday in the Gales Hampshire cup and despite a good showing for much of the game, eventually succumbed to the more expansive game of the home side. Andover welcomed back Carl Sievewright to the pack where they dominated throughout in the tight play providing a lot of possession.";
    //     article.imageUrl1 = "./src/assets/images/action/Action-3.jpg";
    //     article.content2 = "An early interception gifted Winchester a try however and when after just ten minutes Ioan Gwynn Davies was forced off with a bang on the knee, things looked ominous. Replacement Harry ward performed splendidly in his place however and Andover soon stormed back through a pushover try grounded by Aaron Hatcher.";
    //     article.imageUrl2 = "./src/assets/images/action/Action-5.jpg";
    //     article.content3 = "Winchester kicked a penalty and scored a further try but when Tom Waite crashed over from a lineout Andover were looking very strong and Winchester rattled. From a further deep lineout Andover chose the wrong option however and a Winchester counter lead to a further penalty to leave the sides ten points apart at the break. It stayed that way for much of the second half but as Andover pressed again the game boiled over. Tom Waite took a boot to the face causing an eye injury and when the referee deemed it only a yellow card Andover lost their cool.";
    //     article.imageUrl3 = "./src/assets/images/action/Action-8.jpg";
    //     article.content4 = "A yellow card to Ward quickly followed and Winchester took full advantage with two further scores. Afterwards Director of Rugby Andy Waite said ‘Despite all the changes we were in the game for most of the time and I thought the lads who came in did very well.’ ‘It was great to see Ollie Lindridge back in action and although I’m not saying we would have won we certainly didn’t get the rub of the green today.’ Next Saturday Andover travel to Old Tonbridgians in Richmond to continue their league campaign.";
    //     article.imageUrl4 = "./src/assets/images/action/Action-7.jpg";
    //     return article;
    // }

    getForSquadId(id: number): Array<SummaryItem>{
        return [
            {routeName:'article', id: 1, title: 'Colts v Wimborne', summary: 'So close yet so far at the local derby', date: new Date(2017,1,13), imageUrl: './src/assets/images/action/Action-5.jpg' },
            {routeName:'article', id: 2, title: 'Colts v Winchester', summary: 'The golden oldies take London Irish to the wire..', date: new Date(2017,1,13), imageUrl: '' },
            {routeName:'article', id: 3, title: 'Colts County Players', summary: 'The whole squad from the U15 make it through to county', date: new Date(2017,1,13), imageUrl: './src/assets/images/action/Action-7.jpg' },
            {routeName:'article', id: 4, title: 'Colts New Coach', summary: 'The U13 Squad are pleased to welcome a new coach.', date: new Date(2017,1,13), imageUrl: './src/assets/images/action/Action-7.jpg' },
            {routeName:'article', id: 5, title: 'Colts v Alton', summary: 'This years Burns night will be held on Friday 25th November 2017.', date: new Date(2017,1,13), imageUrl: '' },
        ];
    }

    getForClubId(id: number): Promise<Array<SummaryItem>> {
        return this.get<Array<SummaryItem>>(`clubs/${id}/articles`);
    }

    getRelatedToId(id: number): Array<SummaryItem>{

        return [
            {routeName:'article', id: 1, title: 'Colts v Basingstoke', summary: 'So close yet so far at the local derby', date: new Date(2017,1,13), imageUrl: './src/assets/images/action/Action-5.jpg' },
            {routeName:'article', id: 2, title: 'Colts v Trojans', summary: 'The golden oldies take London Irish to the wire..', date: new Date(2017,1,13), imageUrl: '' },
            {routeName:'article', id: 3, title: 'Colts County Players', summary: 'The whole squad from the U15 make it through to county', date: new Date(2017,1,13), imageUrl: './src/assets/images/action/Action-7.jpg' },
            {routeName:'article', id: 4, title: 'Colts v Eastleigh', summary: 'The U13 Squad are pleased to welcome a new coach.', date: new Date(2017,1,13), imageUrl: './src/assets/images/action/Action-7.jpg' },
            {routeName:'article', id: 5, title: 'Colts v Overton', summary: 'This years Burns night will be held on Friday 25th November 2017.', date: new Date(2017,1,13), imageUrl: '' },
        ];
    }
}