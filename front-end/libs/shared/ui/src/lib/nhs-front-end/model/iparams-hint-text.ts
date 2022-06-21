export interface IParamsHintText {
    /** If `html` is set, this is not required. Text to use within the hint. If `html` is provided, the `text` argument will be ignored.*/
    text?: string;

    /** If `text` is set, this is not required. HTML to use within the hint. If `html` is provided, the `text` argument will be ignored.*/
    html?: string;

    /** Id attribute to add to the hint. */
    id: string;

    /**	Classes to add to button, for secondary button use class nhsuk-button--secondary for white button use nhsuk-button--reverse */
    classes?:	string;

    /**	HTML attributes (for example data attributes) to add to the button component.   */
    attributes?:	object;
}
