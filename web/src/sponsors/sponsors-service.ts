import { SummaryItem } from '../shared/summary-item';
import { HttpServiceBase } from '../shared/http-service-base';

export class SponsorsService extends HttpServiceBase{

    getForClubId(id: number): Promise<Array<SummaryItem>> {
        return this.get<Array<SummaryItem>>(`clubs/${id}/sponsors`);
    }

    getForSquadId(id: number): Array<SummaryItem>{

        let sponsors = new Array<SummaryItem>();
        //return sponsors;
        let sponsorNames = ['Daves Beer','Devallish Tech','Pie Land'];
        
        sponsorNames.forEach((value, index) => {
            let newSponsor = new SummaryItem();
            newSponsor.id = index;
            //newSponsor.title = value;
            newSponsor.imageUrl = `./src/assets/images/sponsors/sponsor_0${index+1}.jpg`;
            sponsors.push(newSponsor);
        });

        return sponsors;
    }
}