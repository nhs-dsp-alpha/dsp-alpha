export interface IParamsContentsList {
      /** Classes to add to the content list container. */
  classes?: string;
  /** HTML attributes (for example data attributes) to items in the content list. */
  attributes?: object;

  /** Array of content list items objects. */
  items: Array<
    {
      /** Text to use within each content list item label. */
      text: string;
      /** href value to use within each content list item label. */
      href: string;
      /** Set the current active page. */
      current?: boolean;
    }>
}
