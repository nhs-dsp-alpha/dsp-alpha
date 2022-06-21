import { IParamsErrorMessage } from "./iparams-error-message";
import { IParamsHintText } from "./iparams-hint-text";

export interface IParamsTextInput {

     /**The id of the input. */
     id: string;

     /**The name of the input, which is submitted with the form data.*/
     name: string;

     /**Type of input control to render. Defaults to "text". */
     type?: string;

     /**Optional initial value of the input. */
     value?:string;

     /**One or more element IDs to add to the `aria-describedby` attribute, used to provide additional descriptive information for screenreader users. */
     describedBy?:string;

     /**Options for the label component. */
     label: string;

    /**Max length of input value of text component */
    maxLength?: string|number;

    /**autocomplete attribute to identify input purpose, for instance "postal-code" or "username". */
    autocomplete?: string;

    /**Options for the hint component. */
    hint?: IParamsHintText;

    /**Options for the error message component. The error message component will not display if you use a falsy value for `errorMessage`, for example `false` or `null`. */
    errorMessage?: IParamsErrorMessage;

    prefix?: {
        text?: string,
        html?: string,
        safeHtml?: string,
        classes?: string,
        attributes?: object
    };

    suffix?: {
        text?: string,
        html?: string,
        safeHtml?: string,
        classes?: string,
        attributes?: object
    };

    /**	Classes to add to the tag. */
    classes?:	string;
}

