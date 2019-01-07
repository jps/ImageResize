using ImageMagick;

namespace ImageResize
{
    public class ImageMagikImageResizer : IImageResizer
    {
        public ResizeResult ResizeImage(ResizeRequest resizeRequest)
        {
            MagickReadSettings settings = new MagickReadSettings
            {
                Width = resizeRequest.Width,
                Height = resizeRequest.Height
            };

            using (var fileReader = resizeRequest.FileReader)
            using (var image = new MagickImage(resizeRequest.PathToImage, settings))
            {
                image.Format = MagickFormat.Jpg;
                
                var resizeResult = new ResizeResult();
                image.Write(resizeResult.ImageData);

                return resizeResult;
            }
        }
    }
}