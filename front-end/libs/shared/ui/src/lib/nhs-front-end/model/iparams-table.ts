import { SafeHtml } from "@angular/platform-browser";
import { IParamsClickable } from "./iparams-clickable";

interface IHeadCol {
    /** If `html` is set, this is not required. Text for table head cells. If `html` is provided, the `text` argument will be ignored. */
    text?:	string;
    
    /**	If `text` is set, this is not required. HTML for table head cells. If `html` is provided, the `text` argument will be ignored. */
    html?:	string;
    safeHtml?: SafeHtml;
    
    /**	Specify format of a cell. Currently we only use "numeric". */
    format?:	string;
    
    /** Specify how many columns a cell extends. */
    colspan?:	number;
  }
  
  interface ICol extends IParamsClickable {
    /** If `html` is set, this is not required. Text for cells in table rows. If `html` is provided, the `text` argument will be ignored. */
    text?:	string;
  
    //** NOT DOCUMENTED but Implied by the nunjucks macro */
    header?:	string;
    
    /**	If `text` is set, this is not required. HTML for cells in table rows. If `html` is provided, the `text` argument will be ignored. */
    html?:	string;
    safeHtml?: SafeHtml;
    
    /**	Specify format of a cell. Currently we only use "numeric". */
    format?:	string;
    
    /** Specify how many columns a cell extends. */
    colspan?:	number;
    
    /** Specify how many rows a cell extends. */
    rowspan?:	number;
  }
  
  interface IRow extends Array<ICol> {
    /**	Specify how many rows a cell extends. */
    rowspan?: number;
  }
  
  interface ITable {
    panel?: boolean;
    
    /**	Classes to add to the panel. */
    panelClasses?:	string;
    
    /**	Heading/label of the panel if the panel argument is set to true. */
    heading?:	string;
    
    /** Optional heading level for the heading. Default: 3. */
    headingLevel?: number;
    
    /**	Caption text. */
    caption?:	string;
    
    /**	Classes for caption text size. Classes should correspond to the available typography heading classes. */
    captionClasses?:	string;
    
    /** If set to true, first cell in table row will be a TH instead of a TD. */
    firstCellIsHeader?:	boolean;
    
    /** If set to true, responsive table classes will be applied. */
    responsive?:	boolean;
    
    /**	Classes to add to the table container. */
    tableClasses?:	string;
    
    /**	HTML attributes (for example data attributes) to add to the table container. */
    attributes?:	object;
  
    head: Array<IHeadCol>;
  
    rows: Array<IRow>;
  }

export interface IParamsTable  extends ITable {
}
