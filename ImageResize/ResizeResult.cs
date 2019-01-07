namespace ImageResize
{
    using System.IO;

    public class ResizeResult : System.IDisposable
    {
        public ResizeResult(MemoryStream memoryStream)
        {
            ImageData = memoryStream;
        }

        public ResizeResult()
        {
            ImageData = new MemoryStream();
        }

        public MemoryStream ImageData { get; }

        public void Dispose()
        {
            ImageData.Dispose();
        }
    }
}