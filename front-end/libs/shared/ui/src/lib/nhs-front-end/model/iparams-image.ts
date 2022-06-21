export interface IParamsImage {
      /**	The source location of the image. */
  src:	string;
  
  /**	The alt text of the image. */
  alt:	string;
  
  /**	Optional caption text for the image. */
  caption?:	string;
  
  /**	A list of screen sizes for the browser to load the correct image from the srcset images. */
  sizes?:	string;
  
  /**	A list of image source URLs and their respective sizes. Separate each image with a comma. */
  srcset?:	string;
  
  /**	Classes to add to the image container. */
  classes?:	string;
  
  /**	HTML attributes (for example data attributes) to add to the image container.} */
  attributes?:	object;
}
