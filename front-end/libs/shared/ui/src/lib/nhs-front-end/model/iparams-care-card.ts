import { SafeHtml } from "@angular/platform-browser";

export interface IParamsCareCard {
    /**	Care card component variant type - non-urgent, urgent or immediate */
  type: string;

  /**	Heading to be used within the care card component. */
  heading: string;

  /**	Optional heading level for the heading. Default: 3 */
  headingLevel?: number;

  /**	Content to be used within the care card component. */
  HTML: string;
  safeHTML?: SafeHtml;

  /**	Classes to add to the care card. */
  classes?: string;

  /**	HTML attributes (for example data attributes) to add to the care card.  */
  attributes?: object;
}
