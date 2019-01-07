using ImageResize;
using Xunit.Abstractions;

namespace Tests
{
    // ReSharper disable once UnusedMember.Global
    public class ImageMagicImageResizerShould : ImageResizerShould
    {
        public ImageMagicImageResizerShould(ITestOutputHelper output)
            : base(new ImageMagikImageResizer(), output)
        {
        }
    }
}
