export interface IParamsActionLink {
  /** Text to use within the action link component. */
  text: string;
  /** The value of the link href attribute. */
  href: string;

  /**	If set to true, then the link will open in a new window. */
  openInNewWindow?:	boolean;
  
  /**	Classes to add to the anchor tag. */
  classes?:	string;
  
  /**	HTML attributes (for example data attributes) to add to the anchor tag.   */
  attributes?:	object;
}
