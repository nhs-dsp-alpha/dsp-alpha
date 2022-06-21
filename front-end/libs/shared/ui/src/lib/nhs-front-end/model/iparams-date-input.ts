import { IParamsErrorMessage } from "./iparams-error-message";
import { IParamsHintText } from "./iparams-hint-text";

export interface IParamsDateInput {
    /** Text for the FieldSet Legend */
    fieldsetLegendText: string;

    /**Classes to add to the FieldSet Legend use classes: '--s' for small font, '--m' for medium font, '--l' for large font */
    fieldsetLegendClasses?: string;
    
    /**Options for the hint component. */
    hint?: IParamsHintText;

    /**Options for the error message component. The error message component will not display if you use a falsy value for `errorMessage`, for example `false` or `null`. */
    errorMessage?: IParamsErrorMessage;

    /**This is used for the main component and to compose id attribute for each item. */
    id?: string;

    /**Optional prefix. This is used to prefix each `item.name` using `-`. */
    namePrefix?: string;

      /**An array of input objects with name, value and classes.*/
        items:  Array<
        {
            /**	Item-specific id. If provided, it will be used instead of the generated id. */
            id?: string;

            /**	Item-specific name attribute. */
            name: string;

            /**	Item-specific label text. If provided, this will be used instead of `name` for item label text.*/
            label?: string;

            /**If provided, it will be used as the initial value of the input. */
            value?: string;

            /**Max length of input value of date component */
            maxLength?: number;

        }>

   
  /**HTML attributes (for example data attributes) to add to the date-input container.*/
  classes?: string;


}
