export class KeyValuePair {
    key: string;
    value: any;
}

const apiBaseUrlKey: string = "ApiBaseUrl";

export default {
    debug: true,
    apiBaseUrlKey: apiBaseUrlKey    
}

export function getInjectableValues(): Array < KeyValuePair > {
    return new Array<KeyValuePair>(
        { key: apiBaseUrlKey, value: "http://localhost:5000/api/v1/" }
    );
}