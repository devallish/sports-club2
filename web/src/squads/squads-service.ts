import { SquadModel } from './squad-model';
import { SquadEditModel } from './squad-edit-model';
import { SummaryItem } from '../shared/summary-item';
import { HttpServiceBase } from '../shared/http-service-base';
export class SquadsService extends HttpServiceBase {

    getById(id: number):SquadModel{
        return {id: id, title: `Squad ${id}`, summary: 'Summary for squad',
                information: 'We train on a Sunday afternoon, at the club starting at 12.00pm. Training usually is a two hour session. We also have a midweek training session on a Thursday evening at the club from 7.00pm - 8.30pm. On matchdays kick-off will normally be around 2.00pm, but may be variable. The matchday squad to arrive one hour prior to KO. Players / parents should look out for messages from the coaches / manager via email and the Facebook page regarding training times and match information. We play Hampshire League games about once per month and also arrange ‘friendly’ matches with local squads both in Hampshire and other Counties throughout the season. Details of fixtures are available on the fixture tab on the club website. At this stage of competitive rugby, we aim to continue to develop individual and team play, embrace the spirit of the game, compete to the best of our ability and yet retain the fun side of rugby at the same time. Match experience for all, in addition to a transition into adult rugby is also a priority. At Colts (Under 17/18) we play a full version of 15 a side rugby with only a couple of modifications from the adult game. We always welcome new squad members and are happy for you to come along and give rugby a try! The squad members are representative of most of the local schools  / colleges in the area and it is likely you will already know somebody that plays in the squad. Several members of our squad have been successful in being selected for the Hampshire Schools of Rugby and Hampshire representative teams. If you are interested in coming along, then please just turn up at training and introduce yourself and you will be welcomed. You would need appropriate rugby kit (shorts and a top) to train in, plus boots and a gumshield. Club apparel if you wish to purchase it is available from the clubhouse and second hand kit is also available from the "shed" at very reasonable prices. Alternatively, if you have any questions, please give our Team Manager or one of the coaches a call. Their contact details are below',
                //imageUrl:''};
                imageUrl:'./src/assets/images/action/Action-3.jpg'};
    }

    getForNew(): Promise<SquadEditModel>{
        return super.get('squads/new');
    }

    getForEditById(id: number): Promise<SquadEditModel>{
        return super.get(`squads/${id}/edit`);
    }
    
    create(squad: SquadEditModel): Promise<Response>{
        return super.post<SquadEditModel>('squads', squad);
    }
    update(squad: SquadEditModel): Promise<Response>{
        return super.put<SquadEditModel>('squads', squad);
    }

    getGroupedAsSummaryItems():Array<SquadGroup>{
        
        let squadGroups = new Array<SquadGroup>();
        
        squadGroups.push({name: "Juniors", squads: [
            { routeName: 'squad', id: 1, title: 'Under 6', summary: 'Summary for Under 6', date: null, imageUrl: './src/assets/images/squads/squad_01.jpg' },
            { routeName: 'squad', id: 2, title: 'Under 7', summary: 'Summary for Under 7', date: null, imageUrl: './src/assets/images/squads/squad_02.jpg' },
            { routeName: 'squad', id: 3, title: 'Under 8', summary: 'Summary for Under 8', date: null, imageUrl: '' },
            { routeName: 'squad', id: 4, title: 'Under 9', summary: 'Summary for Under 9', date: null, imageUrl: './src/assets/images/squads/squad_04.jpg' },
            { routeName: 'squad', id: 5, title: 'Under 10', summary: 'Summary for Under 10', date: null, imageUrl: './src/assets/images/squads/squad_03.jpg' },
            { routeName: 'squad', id: 1, title: 'Under 11', summary: 'Summary for Under 11', date: null, imageUrl: './src/assets/images/squads/squad_02.jpg' },
            { routeName: 'squad', id: 2, title: 'Under 12', summary: 'Summary for Under 12', date: null, imageUrl: '' },
            { routeName: 'squad', id: 3, title: 'Under 13', summary: 'Summary for Under 13', date: null, imageUrl: './src/assets/images/squads/squad_03.jpg' },
            { routeName: 'squad', id: 4, title: 'Under 14', summary: 'Summary for Under 14', date: null, imageUrl: '' },
            { routeName: 'squad', id: 5, title: 'Under 15', summary: 'Summary for Under 15', date: null, imageUrl: './src/assets/images/squads/squad_01.jpg' },
            { routeName: 'squad', id: 1, title: 'Under 16', summary: 'Summary for Under 16', date: null, imageUrl: './src/assets/images/squads/squad_02.jpg' },
            { routeName: 'squad', id: 2, title: 'Colts', summary: 'Summary for Colts', date: null, imageUrl: './src/assets/images/squads/squad_01.jpg' }
        ] });

        squadGroups.push({name: "Seniors", squads: [
            { routeName: 'squad', id: 20, title: '1st XV', summary: 'Summary for 1st XV', date: null, imageUrl: './src/assets/images/squads/squad_04.jpg' },
            { routeName: 'squad', id: 21, title: '2nd XV', summary: 'Summary for 2n XV', date: null, imageUrl: './src/assets/images/squads/squad_01.jpg' },
            { routeName: 'squad', id: 22, title: '3rd XV', summary: 'Summary for 3rd XV', date: null, imageUrl: './src/assets/images/squads/squad_03.jpg' },
            { routeName: 'squad', id: 23, title: 'Ladies', summary: 'Summary for Ladies', date: null, imageUrl: './src/assets/images/squads/squad_02.jpg' },
            { routeName: 'squad', id: 24, title: 'Vets', summary: 'Summary for Vets', date: null, imageUrl: './src/assets/images/squads/squad_01.jpg' }
        ]});

        return squadGroups;
    }
}

export class SquadGroup{
    squads: Array<SummaryItem>;
    name: string;
}