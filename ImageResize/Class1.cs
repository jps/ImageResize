using System;

namespace ImageResize
{
    public class ResizeResult
    {
        public string pathToImage { get; }        
    }

    public class ResizeRequest
    {
        public string pathToImage { get; }        
    }

    public interface IResizer
    {
        ResizeResult ResizeImage(ResizeRequest resizeRequest);
    }

    public class ImageMagicResizer : IResizer
    {
        public ResizeResult ResizeImage(ResizeRequest resizeRequest)
        {
            throw new NotImplementedException();
        }
    }
}



/*

https://github.com/dlemstra/Magick.NET/blob/master/Documentation/ResizeImage.md
// Read from file
using (MagickImage image = new MagickImage(SampleFiles.SnakewarePng))
{
    MagickGeometry size = new MagickGeometry(100, 100);
    // This will resize the image to a fixed size without maintaining the aspect ratio.
    // Normally an image will be resized to fit inside the specified size.
    size.IgnoreAspectRatio = true;

    image.Resize(size);

    // Save the result
    image.Write(SampleFiles.OutputDirectory + "Snakeware.100x100.png");
}

 */