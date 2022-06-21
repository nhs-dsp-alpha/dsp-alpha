export interface IParamsFooter {
    copyright?:	string;
    classes?:	string;
    attributes?:	object;
  
    links?: Array<
      {
        URL: string;
        label?: string;
      }>
}
