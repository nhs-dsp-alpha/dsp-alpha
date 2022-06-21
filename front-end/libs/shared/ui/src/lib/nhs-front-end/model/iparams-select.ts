import { IParamsErrorMessage } from "./iparams-error-message";
import { IParamsHintText } from "./iparams-hint-text";

export interface IParamsSelect {
    /**Id for each select box */
    id: string;

    /**Name property for the select.*/
    name: string;

    /**Label text or HTML by specifying value for either text or html keys.*/
    labelText: string;

    /**Provide hint to each radio item. */
    hint?: IParamsHintText;


    /*Options for the error message component. The error message component will not display if you use a falsy value for `errorMessage`, for example `false` or `null`.*/
    errorMessage?: IParamsErrorMessage;

  /**Array of option items for the select.*/
  items:  Array<
  {
    /**Value for the option item. Defaults to an empty string.*/
    value: string;

    /**Text for the option item.*/
    text: string;
    
    /**Sets the option as the selected.*/
    selected?: boolean;

    /**Sets the option item as disabled.*/
    disabled: boolean;

  }>


  /**Classes to add to the radio container. inline radio buttons (hoizontal) use class 'nhsuk-radios--inline' */
  classes?: string;

  /**HTML attributes (for example data attributes) to add to the radio input tag. */
  attributes?:	object;
}
