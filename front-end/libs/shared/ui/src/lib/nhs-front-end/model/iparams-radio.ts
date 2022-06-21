import { IParamsErrorMessage } from "./iparams-error-message";
import { IParamsHintText } from "./iparams-hint-text";

export interface IParamsRadio {
    
  /** Text for the Fieldset Legend */
  fieldsetLegendText: string;

  /**Options for the hint component (for example text). */
  hint?: IParamsHintText;

  /**Options for the error message component. The error message component will not display if you use a falsy value for `errorMessage`, for example `false` or `null`. */
  errorMessage?: IParamsErrorMessage;

  /**String to prefix id for each radio item if no id is specified on each item. If `idPrefix` is not passed, fallback to using the name attribute instead. */
  idPrefix?: string;
   
  /**	Name attribute for each radio item.*/
  name: string;

  /**	Contains an array of error link items and all their available arguments. */
  items:  Array<
  {
    /**If `html` is set, this is not required. Text to use within each radio item label. If `html` is provided, the `text` argument will be ignored. */
    text?: string;

    /**If `text` is set, this is not required. HTML to use within each radio item label. If `html` is provided, the `text` argument will be ignored. */
    html?: string;

    /**Specific id attribute for the radio item. If omitted, then `idPrefix` string will be applied. */
    id?: string;

    /**Value for the radio input. */
    value?: string;

    /**Provide hint to each radio item. */
    hint?: IParamsHintText;

    /**Divider text to separate radio items, for example the text "or". */
    divider?: string;

    /**If true, radio will be checked */
    checked: boolean;

    /**	If true, content provided will be revealed when the item is checked. */
    conditional: string;

    /**Provide content for the conditional reveal. */
    conditionalHtml: string;

    /**HTML attributes (for example data attributes) to add to the radio input tag. */
    attributes?: object;
  }>

  /**Classes to add to the radio container. inline radio buttons (hoizontal) use class 'nhsuk-radios--inline' */
  classes?: string;

  /**HTML attributes (for example data attributes) to add to the radio input tag. */
  attributes?:	object;
}
