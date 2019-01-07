namespace ImageResize
{
    public interface IImageResizer
    {
        ResizeResult ResizeImage(ResizeRequest resizeRequest);
    }
}