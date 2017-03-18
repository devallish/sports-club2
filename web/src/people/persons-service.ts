import { PersonSummaryItem } from './person-summary-item';

export class PersonsService{

    getForSquadId(id: number): Array<PersonSummaryItem>{

        let persons =[
            {id: 1, name: 'Dave Gregory', role: 'Coach', phoneNo: '01264 364341', mobileNo: '07845 141 735', email: 'devallish@googlemail.com', imageUrl: './src/assets/images/persons/person-5.jpg'},
            {id: 2, name: 'Dan Gregory', role: 'Slob', phoneNo: '01264 44444', mobileNo: '07845 141 735', email: 'devallish@googlemail.com', imageUrl: './src/assets/images/persons/person-5.jpg'},
            {id: 3, name: 'Gill Gregory', role: 'Eye Candy', phoneNo: '01264 55555', mobileNo: '07845 141 735', email: 'devallish@googlemail.com', imageUrl: './src/assets/images/persons/person-5.jpg'},
            {id: 4, name: 'Alex Gregory', role: 'Farter', phoneNo: '01264 6666', mobileNo: '07845 141 735', email: 'devallish@googlemail.com', imageUrl: './src/assets/images/persons/person-5.jpg'},
            // {id: 5, name: 'Peter Gregory', role: 'Burper', phoneNo: '01264 666644', mobileNo: '07845 141 735', email: 'devallish@googlemail.com', imageUrl: './src/assets/images/persons/person-5.jpg'},
        ];

        return persons;
    }
}