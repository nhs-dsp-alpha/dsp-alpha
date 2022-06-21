import { SafeHtml } from "@angular/platform-browser";

export interface IParamsInsetText {
        /**	HTML content to be used within the inset text component. */
        html:	string;
        safeHtml?: SafeHtml;
        
        /**	Classes to add to the details element. */
        classes?:	string;
        
        /** HTML attributes (for example data attributes) to add to the details element. */
        attributes?: object;
}
