import 'aurelia-bootstrapper';
import { Aurelia } from 'aurelia-framework';

export function configure(aurelia: Aurelia){
    aurelia.use
        .standardConfiguration()
        .developmentLogging();
    aurelia.start().then(() => aurelia.setRoot());
}