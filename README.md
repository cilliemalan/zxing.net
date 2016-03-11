# zxing.net
Clone of ZXing.Net with improved PDF417 support. contains code from https://zxingnet.codeplex.com/

# PDF417
PDF417 is a 2D barcode used mainly in the travel industry (e.g. drivers license). zxing.net has
support for PDF417 but there were some problems with the algorithm. I improved the algorithm and
it is now better able to handle rotated barcodes, as well as being able to scan drivers license
barcodes (that tend to be flipped vertically).
