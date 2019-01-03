using ImageResize;
using System;
using System.IO;
using Shouldly;
using Xunit;
using System.Reflection;
using System.Diagnostics;
using Xunit.Abstractions;

namespace Tests
{
    public class ImageMagicResizerShould
    {
        private readonly ITestOutputHelper _output;

        public ImageMagicResizerShould(ITestOutputHelper output)
        {
            _output = output;
        }


        string CurrentPath => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        string LargeImage => $@"{CurrentPath}\TestImages\002_Lapageria_rosea_04_ies.jpg";

        [Fact]
        public void ReturnResizeResult()
        {
            var resizer = new ImageMagikResizer();
            var resizeRequest = new ResizeRequest(LargeImage, 100, 100);

            Stopwatch sw = new Stopwatch();
            sw.Start();

            using (var resizeResult = resizer.ResizeImage(resizeRequest))
            {
                sw.Stop();

                _output.WriteLine($"Took:{sw.Elapsed}");

                resizeResult.ShouldBeOfType<ResizeResult>();
                resizeResult.imageData.Length.ShouldBeGreaterThanOrEqualTo(1);
            }
        }

       

    }
}
