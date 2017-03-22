import { SquadModel } from './squad-model';
import { SquadPersonAssociation } from './squad-person-association';

export class SquadEditModel extends SquadModel{

    associations: Array<SquadPersonAssociation>;
    
}