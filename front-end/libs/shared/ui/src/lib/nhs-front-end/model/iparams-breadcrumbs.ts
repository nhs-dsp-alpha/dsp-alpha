export interface IParamsBreadcrumbs {
      /** Text to use for the current page. */
  text: string;
  /** The value of the current page link href attribute. */
  href: string;
  /** Classes to add to the container. */
  classes?:	string;
  /** HTML attributes (for example data attributes) to add to the container. */
  attributes?:	object;

  /** Array of breadcrumbs item objects. */
  items: Array<
    {
      /** Text to use within the breadcrumbs item. */
      text: string;
      /** The value of the breadcrumb item link href attribute. */
      href?: string;
      /** HTML attributes (for example data attributes) to add to the individual crumb. */
      attributes?:	object;
    }>
}
