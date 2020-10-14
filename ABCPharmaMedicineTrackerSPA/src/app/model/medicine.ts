export interface IMedicine{
    name:string
    brand : string
    price : number 
    quantity : number
    expirdate : Date
    notes : string
}

export class Medicine implements IMedicine{
    name: string;
    brand: string;
    price: number;
    quantity: number;
    expirdate: Date;
    notes: string;

}