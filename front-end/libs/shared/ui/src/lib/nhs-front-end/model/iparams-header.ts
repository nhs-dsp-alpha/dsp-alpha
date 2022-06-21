export interface IParamsHeader {
    showNav: boolean;
    showSearch: boolean;
  
    homeText?: string;
    homeHref?: string;
    ariaLabel?: string;
  
    searchAction?:	string;
    searchInputName?:	string;
    classes?:	string;
    attributes?:	object;
  
    organisation?: {
      name?: string;
      descriptor?: string;
      logoURL: string;
      split?: string;
    },
  
    service?: {
      name: string;
    },
  
    transactional?:	boolean;
    transactionalService?: {
      name: string;
      href: string;
      longName?: boolean;
    },
    
    primaryLinks?: Array<
      {
        url: string,
        label?: string,
        external?: boolean
      }>
}
