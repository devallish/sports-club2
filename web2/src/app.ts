import { inject } from 'aurelia-framework';
import { AppRouter, Router, RouterConfiguration } from 'aurelia-router';
import { AppService } from './app-service';
import { ClubModel } from './club-model';

@inject(AppService)
export class App {
  
  router: Router;
  title: string;
  model: ClubModel;

  constructor(private appService: AppService){}

  async configureRouter(routerConfig: RouterConfiguration, appRouter: AppRouter){

    this.router = appRouter;

    // TODO: is the is best place for this?
    //       I intend to load other inforamtion that might need to be
    //       mapped onto the router. i.e. pages of information.
    //       Saying that it might be a child router for this, but that
    //       just moves the problem somewhere else..
    
    this.model = await this.appService.getAppInfo();
    
    routerConfig.title = this.model.browserTitle;

    routerConfig.map([
      { route:['','home'], name:'home', moduleId:'home/home', nav: true, title: "Home", settings:{ clubId: this.model.id}},
      { route: 'squads', name:'squads', moduleId:'squads/squads', nav: true, title: "Squads"},
      { route: 'squad/:id', name: 'squad', moduleId: 'squads/squad', nav: false},
      { route: 'squad/:id/edit', name: 'squad-edit', moduleId: 'squads/squad-edit', nav: false},
      { route: 'squad/new', name: 'squad-new', moduleId: 'squads/squad-edit', nav: false},
      { route: 'articles', name:'articles', moduleId:'articles/articles', nav: true, title: "News"},
      { route: 'article/:id', name: 'article', moduleId: 'articles/article', nav: false },
      { route: 'article/:id/edit', name: 'article-edit', moduleId: 'articles/article-edit', nav: false },
      { route: 'article/new', name: 'article-new', moduleId: 'articles/article-edit', nav: false },
      { route: 'contactus', name: 'contactus', moduleId: 'contact-us/contact-us', nav: true, title: 'Contact Us'}
    ]);
  }
}
