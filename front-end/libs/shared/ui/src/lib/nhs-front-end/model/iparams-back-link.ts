import { SafeHtml } from "@angular/platform-browser";
import { IParamsClickable } from "./iparams-clickable";

export interface IParamsBackLink extends IParamsClickable {
      /**	Text to use within the back link component. If `html` is provided, the `text` argument will be ignored. Defaults to "Back". */
  text?: string;
  /**	HTML to use within the back link component. If `html` is provided, the `text` argument will be ignored. Defaults to "Back". */
  html?: string;
  safeHtml?: SafeHtml;
  /**	The value of the link href attribute. */
  href?: string;
  /** The value of the routerLink attribute. */
  routerLink?: string;
  /**	Classes to add to the container. */
  classes?: string;
  /**	HTML attributes (for example data attributes) to add to the anchor tag.} */
  attributes?: object;
}

