export interface IParamsButton {
    /** Whether to use an `input`, `button` or `a` element to create the button. In most cases you will not need to set this as it will be configured automatically if you use `href` or `html`.*/
  element?: string;
  
  /** If `html` is set, this is not required. Text for the button or link. If `html` is provided, the `text` argument will be ignored and `element` will be automatically set to `button` unless `href` is also set, or it has already been defined. This argument has no effect if `element` is set to `input`.*/
  text?: string;

   /**	If `text` is set, this is not required. HTML for the button or link. If `html` is provided, the `text` argument will be ignored and `element` will be automatically set to `button` unless `href` is also set, or it has already been defined. This argument has no effect if `element` is set to `input`.*/
  html?: string;

  /** Name for the `input` or `button`. This has no effect on `a` elements. */
  name?: string;

  /** Type of `input` or `button` – `button`, `submit` or `reset`. Defaults to `submit`. This has no effect on `a` elements. */
  type?: string;

  /**	Value for the `button` tag. This has no effect on `a` or `input` elements. */
  value?: string;

  /**	Whether the button should be disabled. For button and input elements, `disabled` and `aria-disabled` attributes will be set automatically. */
  disabled?: boolean;

  /** The URL that the button should link to. If this is set, `element` will be automatically set to `a` if it has not already been defined. */
  href?: string;

  /**	Classes to add to button, for secondary button use class nhsuk-button--secondary for white button use nhsuk-button--reverse */
  classes?:	string;

  /**	HTML attributes (for example data attributes) to add to the button component.   */
  attributes?:	object;
}
