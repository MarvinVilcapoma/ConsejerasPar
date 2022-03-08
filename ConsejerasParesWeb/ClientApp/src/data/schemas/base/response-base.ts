export class ResponseBase<T> {
    code!: number;
    message!: string;
    messageEN!: string;
    isResultList!: boolean;
    listado: T[] = [];
    objeto!: T;
    dato!:string;
    technicalErrors!: string;
    functionalErrors!: string;
}
  