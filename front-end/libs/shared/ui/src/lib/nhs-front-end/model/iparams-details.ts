import { SafeHtml } from "@angular/platform-browser";

export interface IParamsDetails {
      /**	Text to be displayed on the details component. */
  text:	string;

  /**	HTML content to be displayed within the details component. */
  html:	string;
  safeHtml?: SafeHtml;
  
  /**	Classes to add to the details element. */
  classes?:	string;
  
  /** HTML attributes (for example data attributes) to add to the details element. */
  attributes?: object;
}
