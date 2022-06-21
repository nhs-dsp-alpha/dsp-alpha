import { SafeHtml } from "@angular/platform-browser";

export interface IParamsCard {
     /** Text to use within the heading of the card component. If `headingHtml` is provided, the `heading` argument will be ignored. */
  heading?: string;
  /** HTML to use within the heading of the card component. If `headingHtml` is provided, the `heading` argument will be ignored. */
  headingHtml?: string;
  headingSafeHtml?: SafeHtml;
  /** Classes to add to the card heading. */
  headingClasses?: string;
  /** Optional heading level for the card heading. Default: 2 */
  headingLevel?: number;
  /** The value of the card link href attribute. */
  href?: string;
  /** The value of the card link routerLink attribute. */
  routerLink?: string;
  /** If set to true, then the whole Card will become a clickable Card variant. */
  clickable?: boolean;
  /** If set to true, then the Card will become a feature Card variant. */
  feature?: boolean;
  /** The URL of the image in the card. */
  imgURL?: string;
  /**	The alternative text of the image in the card. */
  imgALT?: string;
  /**	Text description within the card content. If `descriptionHtml` is provided, the `description` argument will be ignored. */
  description?: string;
  /**	HTML to use within the card content. If `descriptionHtml` is provided, the `description` argument will be ignored. */
  descriptionHtml?: string;
  descriptionSafeHtml?: SafeHtml;
  /**	Classes to add to the card. */
  classes?: string;
  /**	HTML attributes (for example data attributes) to add to the card. */
  attributes?: object;
}
