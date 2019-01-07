namespace Tests
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using ImageResize;
    using Shouldly;
    using Xunit;
    using Xunit.Abstractions;

    public abstract class ImageResizerShould
    {
        private readonly IImageResizer _imageResizer;

        private readonly ITestOutputHelper _output;

        private string CurrentPath => Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

        private string LargeImage => $@"{CurrentPath}\TestImages\002_Lapageria_rosea_04_ies.jpg";

        protected ImageResizerShould(
            IImageResizer imageResizer,
            ITestOutputHelper output)
        {
            _imageResizer = imageResizer;
            _output = output;
        }

        [Fact]
        public void ReturnResizeResult()
        {

            var resizeRequest = new ResizeRequest(LargeImage, 100, 100);

            var sw = new Stopwatch();
            sw.Start();

            using (var resizeResult = _imageResizer.ResizeImage(resizeRequest))
            {
                sw.Stop();

                _output.WriteLine($"Took:{sw.Elapsed}");

                resizeResult.ShouldBeOfType<ResizeResult>();
                resizeResult.ImageData.Length.ShouldBeGreaterThanOrEqualTo(1);
            }
        }

        [Fact]
        public void FindAverageRunTime()
        {
            const int amountOfTimesToRun = 10;
            var runTimes = new Stack<TimeSpan>(amountOfTimesToRun);
            var resizeRequest = new ResizeRequest(LargeImage, 100, 100);

            for (int i = 0; i < amountOfTimesToRun; i++)
            {
                var sw = new Stopwatch();
                sw.Start();

                using (_imageResizer.ResizeImage(resizeRequest))
                {
                    sw.Stop();
                    runTimes.Push(sw.Elapsed);
                    _output.WriteLine($"Took:{sw.Elapsed}");
                }
            }

            var average = runTimes.Average(x => x.TotalMilliseconds);
            _output.WriteLine($"Average:{average} ms");
        }

    }
}