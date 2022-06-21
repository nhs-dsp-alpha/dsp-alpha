import { SafeHtml } from "@angular/platform-browser";
import { IParamsClickable } from "./iparams-clickable";

interface IKeyValue {
    /** If `html` is set, this is not required. Text to use within the each key. If `html` is provided, the `text` argument will be ignored. */
    text?: string;
  
    /** If `text` is set, this is not required. HTML to use within the each value. If `html` is provided, the `text` argument will be ignored. */
    html?: string;
    safeHtml?: SafeHtml;
  
    /** Classes to add to the key wrapper. */
    classes?: string;
  }
  
  interface IActionItem extends IParamsClickable {
    href: string;
    routerLink?: string;
    text?: string;
    html?: string;
    safeHtml?: SafeHtml;
    visuallyHiddenText?: string;
  }
  
  interface IAction {
    classes?: string;
    items: Array<IActionItem>;
  }
  
  interface IRow {
    /** Classes to add to the row `div`. */
    classes?: string;
  
    key: IKeyValue;
    value: IKeyValue;
    actions?: IAction;
  }

export interface IParamsSummaryList {
      /** Array of row item objects. */
  rows: Array<IRow>,

  /**	Classes to add to the summary list container. */
  classes?: string;

  /**	HTML attributes (for example data attributes) to add to the summary list container. */
  attributes?: object;
}
