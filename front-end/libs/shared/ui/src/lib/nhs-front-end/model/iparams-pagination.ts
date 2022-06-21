export interface IParamsPagination {
  /**	The value of the previous link href attribute. */
  previousUrl:	string;
  /**	The text of the previous link. */
  previousPage:	string;
  /**	The value of the next link href attribute. */
  nextUrl:	string;
  /**	The text of the next link. */
  nextPage:	string;
  /**	Classes to add to the pagination container. */
  classes?:	string;
  /**	HTML attributes (for example data attributes) to add to the pagination container. */
  attributes?:	object;
}

