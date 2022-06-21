import { SafeHtml } from "@angular/platform-browser";

export interface IParamsWarningCallout {
      /**	Heading to be used within the warning callout. */
  heading: string;

  /**	Optional heading level for the heading. Default: 3 */
  headingLevel?: number;

  /**	Content to be used within the warning callout. */
  html: string;
  safeHtml?: SafeHtml;

  /**	Classes to add to the warning callout. */
  classes?: string;

  /**	HTML attributes (for example data attributes) to add to the warning callout.  */
  attributes?: object;
}
