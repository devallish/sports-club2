import {Aurelia} from 'aurelia-framework'
import environment from './env';
import { getInjectableValues } from "./env";

// TODO: what exactly is this doing..?
//       beyond setting a config value..
//Configure Bluebird Promises.
(<any>Promise).config({
  warnings: {
    wForgottenReturn: false
  }
});


export function configure(aurelia: Aurelia) {
  aurelia.use
    .standardConfiguration()
    .feature('resources');

  if (environment.debug) {
    aurelia.use.developmentLogging();
  }

  for (let configValue of getInjectableValues()){
    aurelia.use.instance(configValue.key, configValue.value);
  }

  aurelia.start().then(() => aurelia.setRoot());
}
