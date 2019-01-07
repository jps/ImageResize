using ImageResize;
using Xunit.Abstractions;

namespace Tests
{
    // ReSharper disable once UnusedMember.Global
    public class SystemDrawingImageResizerShould : ImageResizerShould
    {
        public SystemDrawingImageResizerShould(ITestOutputHelper output)
            : base(new SystemDrawingImageResizer(), output)
        {
        }
    }
}
