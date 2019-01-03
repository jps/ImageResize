namespace ImageResize
{
    public interface IResizer
    {
        ResizeResult ResizeImage(ResizeRequest resizeRequest);
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