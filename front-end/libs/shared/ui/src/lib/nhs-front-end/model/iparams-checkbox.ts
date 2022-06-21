import { SafeHtml } from "@angular/platform-browser";
import { IParamsErrorMessage } from "./iparams-error-message";
import { IParamsHintText } from "./iparams-hint-text";

export interface IParamsCheckbox {
       
  /** Text for the FieldSet Legend */
  fieldsetLegendText: string;

  /**Classes to add to the FieldSet Legend use classes: '--s' for small font, '--m' for medium font, '--l' for large font */
 fieldsetLegendClasses?: string;
 /**Options for the hint component (for example text). */
 hint?: IParamsHintText;

 /**Options for the error message component. The error message component will not display if you use a falsy value for `errorMessage`, for example `false` or `null`. */
 errorMessage?: IParamsErrorMessage;

 /**String to prefix id for each checkbox item if no id is specified on each item. If `idPrefix` is not passed, fallback to using the name attribute instead. */
 idPrefix?: string;
  
 /**	Name attribute for each checkbox item.*/
 name: string;

 /**	Contains an array of error link items and all their available arguments. */
 items:  Array<
 {
   /**If `html` is set, this is not required. Text to use within each checkbox item label. If `html` is provided, the `text` argument will be ignored. */
   text?: string;

   /**If `text` is set, this is not required. HTML to use within each checkbox item label. If `html` is provided, the `text` argument will be ignored. */
   html?: SafeHtml;

   /**Specific id attribute for the checkbox item. If omitted, then `idPrefix` string will be applied. */
   id?: string;

   /**Value for the checkbox input. */
   value: string;

   /**Provide hint to each  item. */
   hint?: IParamsHintText;

   /**Divider text to separate checkbox items, for example the text "or". */
   divider?: string;

   /**If true, checkbox will be checked */
   checked?: boolean;

   /**If true, checkbox will be disabled. */
   disabled: boolean;

 }>

 /**Classes to add to the checkbox container. inline checkbox buttons (hoizontal) use class 'nhsuk-radios--inline' */
 classes?: string;

 /**HTML attributes (for example data attributes) to add to the checkbox input tag. */
 attributes?:	object;
}
