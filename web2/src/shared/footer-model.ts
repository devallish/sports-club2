export class FooterModel{
    addressLines: Array<string>;
    externalLinks: Array<ExternalLink>;
    internalLinks: Array<InternalLink>;
}

export class ExternalLink{
    displayValue: string;
    url:string;
}
export class InternalLink{
    displayValue: string;
    routerName: string;
    routerData: string;
}
