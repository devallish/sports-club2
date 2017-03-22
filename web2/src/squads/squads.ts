import { inject, View } from 'aurelia-framework';
import { SquadsService, SquadGroup } from './squads-service';

@inject(SquadsService)
export class Squads{    

    squadGroups: Array<SquadGroup>;
    
    constructor(private squadsService: SquadsService){ }

    // TODO: async ness..
    created(owningView: View, thisView: View){

        this.squadGroups = this.squadsService.getGroupedAsSummaryItems();
    }
}