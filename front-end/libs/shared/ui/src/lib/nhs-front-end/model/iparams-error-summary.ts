export interface IParamsErrorSummary {
      
  /** If `titleHtml` is set, this is not required. Text to use for the heading of the error summary block. If `titleHtml` is provided, `titleText` will be ignored.*/
  titleText?: string;

  /** If `titleText` is set, this is not required. HTML to use for the heading of the error summary block. If `titleHtml` is provided, `titleText` will be ignored.*/
  titleHtml?: string;

  /** Text to use for the description of the errors. If you set `descriptionHtml`, the component will ignore `descriptionText`.*/
  descriptionText?: string;

  /**HTML to use for the description of the errors. If you set this option, the component will ignore `descriptionText`. */
  descriptionHtml?: string;

  /**	Contains an array of error link items and all their available arguments. */
  errorList?:  Array<
  {
    href: string;
    text?: string;
    html?: string;
    attributes?: object;
  }>


  /**	Classes to add to button, for secondary button use class nhsuk-button--secondary for white button use nhsuk-button--reverse */
  classes?:	string;

  /**	HTML attributes (for example data attributes) to add to the button component.   */
  attributes?:	object;
}
