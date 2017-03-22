import { inject } from 'aurelia-framework';
import { RouteConfig } from 'aurelia-router';
import { SquadEditModel } from './squad-edit-model';
import { SquadsService } from './squads-service';

@inject(SquadsService)
export class SquadEdit{
    
    squad: SquadEditModel;
    editTypeDescription: string;

    constructor(private squadsService:SquadsService){}

    async activate(params: any, routeConfig: RouteConfig){
        let id = params['id'] as number;
        if (id === 0){
            this.editTypeDescription = 'New';
            this.squad = await this.squadsService.getForNew();
            routeConfig.navModel.setTitle('New Squad');
        }else{
            this.editTypeDescription = 'Edit';
            this.squad = await this.squadsService.getForEditById(id);
            routeConfig.navModel.setTitle(`Editing ${this.squad.name}`);
        }
    }    

    async save(){
        // TODO: need to handle response 
        // - this is just assuming ok..
        let message = '';
        if (this.squad.id === 0){
            await this.squadsService.create(this.squad);
            message = 'Squad has been created.';
        }else {
            await this.squadsService.update(this.squad);
            message = 'Squad has been updated.';
        }
        // TODO: us a nicer dialog for this..
        //       do we want to redirect somewhere?
        alert(message);
    }

    async addPerson(){

    }

    async removePerson(){

    }
}