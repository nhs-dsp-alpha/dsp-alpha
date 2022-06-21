import { SafeHtml } from "@angular/platform-browser";

export interface IParamsTag {
      /**If `html` is set, this is not required. Text to use within the tag component. If `html` is provided, the `text` argument will be ignored. */
  text?: string;
  
  /**	If `text` is set, this is not required. HTML to use within the tag component. If `html` is provided, the `text` argument will be ignored. */
  html?:	string;
  safeHtml?: SafeHtml;
  
  /**	Classes to add to the tag. */
  classes?:	string;
  
  /** HTML attributes (for example data attributes) to add to the tag. */
  attributes?: object;
}
