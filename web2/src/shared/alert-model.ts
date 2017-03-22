export class AlertModel{
    title: string;
    message: string;
    level: AlertLevels;
}
export enum AlertLevels{
    Information = 0,
    Important = 1
}