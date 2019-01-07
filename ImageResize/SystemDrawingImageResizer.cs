using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace ImageResize
{
    using System.Drawing.Imaging;
    using System.IO;

    public class SystemDrawingImageResizer : IImageResizer
    {
        public ResizeResult ResizeImage(ResizeRequest resizeRequest)
        {
            var originalImage = new Bitmap(resizeRequest.FileReader);

            var resizedImage = new Bitmap(resizeRequest.Width, resizeRequest.Height);
            using (var gfx = Graphics.FromImage(resizedImage))
            {
                gfx.DrawImage(
                    image: originalImage,
                    destRect: new Rectangle(0, 0, resizeRequest.Width, resizeRequest.Height),
                    srcRect: new Rectangle(0, 0, originalImage.Width, originalImage.Height),
                    srcUnit: GraphicsUnit.Pixel);
            }
            

            var resultStream = new MemoryStream();
            resizedImage.Save(resultStream, ImageFormat.Png);
            resultStream.Position = 0;

            return new ResizeResult(resultStream);
        }
    }
}
