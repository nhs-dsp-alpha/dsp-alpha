export interface IParamsDoAndDontList {
      /**	Title to be displayed on the do and don't list component. */
  title:	string;
  
  /** Type of do and don't list component, "cross", "tick". */
  type:	string;
  
  /**	Array of do and don't items objects. */
  items:	Array<{item:string}>;

  /**	If set to true when type is "cross", then removes the default "do not" text prefix to each item. */
  hidePrefix?: boolean;
  
  /**	Optional heading level for the title heading. Default: 3 */
  headingLevel?: number;
  
  /**	Classes to add to the do and don't list container. */
  classes?:	string;
  
  /**	HTML attributes (for example data attributes) to add to the do and don't list container. */
  attributes?: object;
}
