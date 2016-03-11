using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using ZXing;

namespace zxing.test
{
    public class Pdf417Tests
    {
        private BarcodeReader barcodereader;

        public Pdf417Tests()
        {
            barcodereader = new BarcodeReader();
            barcodereader.Options.PossibleFormats = new[] { BarcodeFormat.PDF_417 };
        }

        [Fact]
        public void PixelPerfectTest()
        {
            var image = Support.Image("Pdf417/pixelperfect.png");
            var expected = "Simple PDF417 Barcode";

            string decoded = barcodereader.Decode(image)?.Text;

            Assert.Equal(expected, decoded);
        }

        [Fact]
        public void LargePixelPerfectTest()
        {
            var image = Support.Image("Pdf417/verylargepixelperfect.png");
            var expected = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas imperdiet neque arcu, ac dictum ex commodo quis. Sed iaculis, nibh quis dignissim dictum, turpis ex mattis velit, vel consequat sapien orci et felis. Mauris quis massa convallis, consequat sem feugiat, suscipit purus. Suspendisse at rhoncus turpis, in maximus sapien. Nunc ultricies, nunc sit amet tempus pellentesque, augue magna rutrum ligula, non pharetra sem sapien in ex. Duis ultrices ligula at justo consequat, id fermentum libero rhoncus. Sed in egestas magna, vitae consequat dolor. Mauris sem ligula, posuere ac velit eget, aliquet molestie velit. Nunc tincidunt sem nunc, vel mattis tellus hendrerit id. Vestibulum ut dolor sit amet nisi vehicula sodales a fringilla odio. Cum sociis natoque penatibus et magnis dis parturient montes.";

            string decoded = barcodereader.Decode(image)?.Text;

            Assert.Equal(expected, decoded);
        }

        [Fact]
        public void RotatedDiscTest()
        {
            var image = Support.Image("Pdf417/rotated_disc.jpg");
            var expected = "%MVL1CC08%0142%4046T0BH%1%4046047ZL6SH%DS19LGGP%VSX247W%Hatch back / Luikrug%HONDA%BRIO%White / Wit%MAKDD1780FN000309%L12B34004104%2016-04-30%";

            string decoded = barcodereader.Decode(image)?.Text;

            Assert.Equal(expected, decoded);
        }

        [Fact]
        public void StraightDiscTest()
        {
            var image = Support.Image("Pdf417/straight_disc.jpg");
            var expected = "%MVL1CC08%0142%4046T0BH%1%4046047ZL6SH%DS19LGGP%VSX247W%Hatch back / Luikrug%HONDA%BRIO%White / Wit%MAKDD1780FN000309%L12B34004104%2016-04-30%";

            string decoded = barcodereader.Decode(image)?.Text;

            Assert.Equal(expected, decoded);
        }

        [Fact]
        public void LicenseCardTest()
        {
            var image = Support.Image("Pdf417/driverslicense_fake.png");
            var expected = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas imperdiet neque arcu, ac dictum ex commodo quis. Sed iaculis, nibh quis dignissim dictum, turpis ex mattis velit, vel consequat sapien orci et felis. Mauris quis massa convallis, consequat sem feugiat, suscipit purus. Suspendisse at rhoncus turpis, in maximus sapien. Nunc ultricies, nunc sit amet tempus pellentesque, augue magna rutrum ligula, non pharetra sem sapien in ex. Duis ultrices ligula at justo consequat, id fermentum libero rhoncus. Sed in egestas magna, vitae consequat dolor. Mauris sem ligula, posuere ac velit eget, aliquet molestie velit. Nunc tincidunt sem nunc, vel mattis tellus hendrerit id. Vestibulum ut dolor sit amet nisi vehicula sodales a fringilla odio. Cum sociis natoque penatibus et magnis dis parturient montes.";

            string decoded = barcodereader.Decode(image)?.Text;

            Assert.Equal(expected, decoded);
        }
    }
}
