using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZXing.Common
{
    using Point = Transformation.Point;

    public sealed partial class BitMatrix
    {
        public BitMatrix Transform(Transformation transformation)
        {
            Transformation t = transformation;
            Point p0, p1, p2, p3;
            int w = width;
            int h = height;

            p0 = t.ReverseTransform(0, 0);
            p1 = t.ReverseTransform(w, 0);
            p2 = t.ReverseTransform(w, h);
            p3 = t.ReverseTransform(0, h);

            var minx = Math.Min(Math.Min(p0.X, p1.X), Math.Min(p2.X, p3.X));
            var miny = Math.Min(Math.Min(p0.Y, p1.Y), Math.Min(p2.Y, p3.Y));
            var maxx = Math.Max(Math.Max(p0.X, p1.X), Math.Max(p2.X, p3.X));
            var maxy = Math.Max(Math.Max(p0.Y, p1.Y), Math.Max(p2.Y, p3.Y));

            var nw = maxx;
            var nh = maxy;
            var nrs = (nw + 31) >> 5;

            int[] newBits = new int[nrs * nh];
            Point[] pnts = new Point[32];
            int[] trfix = new int[32];

            for (int y = 0; y < nh; y++)
            {
                for (int x = 0, i = y * nrs; x < nw; x += 32, i++)
                {
                    t.BulkTransform(pnts, 0, 32, x, y);
                    
                    trfix[00] = pnts[00].Y * rowSize + (pnts[00].X >> 5);
                    trfix[01] = pnts[01].Y * rowSize + (pnts[01].X >> 5);
                    trfix[02] = pnts[02].Y * rowSize + (pnts[02].X >> 5);
                    trfix[03] = pnts[03].Y * rowSize + (pnts[03].X >> 5);
                    trfix[04] = pnts[04].Y * rowSize + (pnts[04].X >> 5);
                    trfix[05] = pnts[05].Y * rowSize + (pnts[05].X >> 5);
                    trfix[06] = pnts[06].Y * rowSize + (pnts[06].X >> 5);
                    trfix[07] = pnts[07].Y * rowSize + (pnts[07].X >> 5);
                    trfix[08] = pnts[08].Y * rowSize + (pnts[08].X >> 5);
                    trfix[09] = pnts[09].Y * rowSize + (pnts[09].X >> 5);
                    trfix[10] = pnts[10].Y * rowSize + (pnts[10].X >> 5);
                    trfix[11] = pnts[11].Y * rowSize + (pnts[11].X >> 5);
                    trfix[12] = pnts[12].Y * rowSize + (pnts[12].X >> 5);
                    trfix[13] = pnts[13].Y * rowSize + (pnts[13].X >> 5);
                    trfix[14] = pnts[14].Y * rowSize + (pnts[14].X >> 5);
                    trfix[15] = pnts[15].Y * rowSize + (pnts[15].X >> 5);
                    trfix[16] = pnts[16].Y * rowSize + (pnts[16].X >> 5);
                    trfix[17] = pnts[17].Y * rowSize + (pnts[17].X >> 5);
                    trfix[18] = pnts[18].Y * rowSize + (pnts[18].X >> 5);
                    trfix[19] = pnts[19].Y * rowSize + (pnts[19].X >> 5);
                    trfix[20] = pnts[20].Y * rowSize + (pnts[20].X >> 5);
                    trfix[21] = pnts[21].Y * rowSize + (pnts[21].X >> 5);
                    trfix[22] = pnts[22].Y * rowSize + (pnts[22].X >> 5);
                    trfix[23] = pnts[23].Y * rowSize + (pnts[23].X >> 5);
                    trfix[24] = pnts[24].Y * rowSize + (pnts[24].X >> 5);
                    trfix[25] = pnts[25].Y * rowSize + (pnts[25].X >> 5);
                    trfix[26] = pnts[26].Y * rowSize + (pnts[26].X >> 5);
                    trfix[27] = pnts[27].Y * rowSize + (pnts[27].X >> 5);
                    trfix[28] = pnts[28].Y * rowSize + (pnts[28].X >> 5);
                    trfix[29] = pnts[29].Y * rowSize + (pnts[29].X >> 5);
                    trfix[30] = pnts[30].Y * rowSize + (pnts[30].X >> 5);
                    trfix[31] = pnts[31].Y * rowSize + (pnts[31].X >> 5);

                    int L = bits.Length;

                    if (trfix[00] < 0 || trfix[00] >= L) trfix[00] = 0;
                    if (trfix[01] < 0 || trfix[01] >= L) trfix[01] = 0;
                    if (trfix[02] < 0 || trfix[02] >= L) trfix[02] = 0;
                    if (trfix[03] < 0 || trfix[03] >= L) trfix[03] = 0;
                    if (trfix[04] < 0 || trfix[04] >= L) trfix[04] = 0;
                    if (trfix[05] < 0 || trfix[05] >= L) trfix[05] = 0;
                    if (trfix[06] < 0 || trfix[06] >= L) trfix[06] = 0;
                    if (trfix[07] < 0 || trfix[07] >= L) trfix[07] = 0;
                    if (trfix[08] < 0 || trfix[08] >= L) trfix[08] = 0;
                    if (trfix[09] < 0 || trfix[09] >= L) trfix[09] = 0;
                    if (trfix[10] < 0 || trfix[10] >= L) trfix[10] = 0;
                    if (trfix[11] < 0 || trfix[11] >= L) trfix[11] = 0;
                    if (trfix[12] < 0 || trfix[12] >= L) trfix[12] = 0;
                    if (trfix[13] < 0 || trfix[13] >= L) trfix[13] = 0;
                    if (trfix[14] < 0 || trfix[14] >= L) trfix[14] = 0;
                    if (trfix[15] < 0 || trfix[15] >= L) trfix[15] = 0;
                    if (trfix[16] < 0 || trfix[16] >= L) trfix[16] = 0;
                    if (trfix[17] < 0 || trfix[17] >= L) trfix[17] = 0;
                    if (trfix[18] < 0 || trfix[18] >= L) trfix[18] = 0;
                    if (trfix[19] < 0 || trfix[19] >= L) trfix[19] = 0;
                    if (trfix[20] < 0 || trfix[20] >= L) trfix[20] = 0;
                    if (trfix[21] < 0 || trfix[21] >= L) trfix[21] = 0;
                    if (trfix[22] < 0 || trfix[22] >= L) trfix[22] = 0;
                    if (trfix[23] < 0 || trfix[23] >= L) trfix[23] = 0;
                    if (trfix[24] < 0 || trfix[24] >= L) trfix[24] = 0;
                    if (trfix[25] < 0 || trfix[25] >= L) trfix[25] = 0;
                    if (trfix[26] < 0 || trfix[26] >= L) trfix[26] = 0;
                    if (trfix[27] < 0 || trfix[27] >= L) trfix[27] = 0;
                    if (trfix[28] < 0 || trfix[28] >= L) trfix[28] = 0;
                    if (trfix[29] < 0 || trfix[29] >= L) trfix[29] = 0;
                    if (trfix[30] < 0 || trfix[30] >= L) trfix[30] = 0;
                    if (trfix[31] < 0 || trfix[31] >= L) trfix[31] = 0;

                    int newI_mask = (int)(
                        ((uint)(trfix[00] > 0 ? 1 : 0) << 00) |
                        ((uint)(trfix[01] > 0 ? 1 : 0) << 01) |
                        ((uint)(trfix[02] > 0 ? 1 : 0) << 02) |
                        ((uint)(trfix[03] > 0 ? 1 : 0) << 03) |
                        ((uint)(trfix[04] > 0 ? 1 : 0) << 04) |
                        ((uint)(trfix[05] > 0 ? 1 : 0) << 05) |
                        ((uint)(trfix[06] > 0 ? 1 : 0) << 06) |
                        ((uint)(trfix[07] > 0 ? 1 : 0) << 07) |
                        ((uint)(trfix[08] > 0 ? 1 : 0) << 08) |
                        ((uint)(trfix[09] > 0 ? 1 : 0) << 09) |
                        ((uint)(trfix[10] > 0 ? 1 : 0) << 10) |
                        ((uint)(trfix[11] > 0 ? 1 : 0) << 11) |
                        ((uint)(trfix[12] > 0 ? 1 : 0) << 12) |
                        ((uint)(trfix[13] > 0 ? 1 : 0) << 13) |
                        ((uint)(trfix[14] > 0 ? 1 : 0) << 14) |
                        ((uint)(trfix[15] > 0 ? 1 : 0) << 15) |
                        ((uint)(trfix[16] > 0 ? 1 : 0) << 16) |
                        ((uint)(trfix[17] > 0 ? 1 : 0) << 17) |
                        ((uint)(trfix[18] > 0 ? 1 : 0) << 18) |
                        ((uint)(trfix[19] > 0 ? 1 : 0) << 19) |
                        ((uint)(trfix[20] > 0 ? 1 : 0) << 20) |
                        ((uint)(trfix[21] > 0 ? 1 : 0) << 21) |
                        ((uint)(trfix[22] > 0 ? 1 : 0) << 22) |
                        ((uint)(trfix[23] > 0 ? 1 : 0) << 23) |
                        ((uint)(trfix[24] > 0 ? 1 : 0) << 24) |
                        ((uint)(trfix[25] > 0 ? 1 : 0) << 25) |
                        ((uint)(trfix[26] > 0 ? 1 : 0) << 26) |
                        ((uint)(trfix[27] > 0 ? 1 : 0) << 27) |
                        ((uint)(trfix[28] > 0 ? 1 : 0) << 28) |
                        ((uint)(trfix[29] > 0 ? 1 : 0) << 29) |
                        ((uint)(trfix[30] > 0 ? 1 : 0) << 30) |
                        ((uint)(trfix[31] > 0 ? 1 : 0) << 31));

                    int newI = (int)(
                        (((((uint)(bits[trfix[00]]) >> (pnts[00].X & 0x1f))) & 1) << 00) |
                        (((((uint)(bits[trfix[01]]) >> (pnts[01].X & 0x1f))) & 1) << 01) |
                        (((((uint)(bits[trfix[02]]) >> (pnts[02].X & 0x1f))) & 1) << 02) |
                        (((((uint)(bits[trfix[03]]) >> (pnts[03].X & 0x1f))) & 1) << 03) |
                        (((((uint)(bits[trfix[04]]) >> (pnts[04].X & 0x1f))) & 1) << 04) |
                        (((((uint)(bits[trfix[05]]) >> (pnts[05].X & 0x1f))) & 1) << 05) |
                        (((((uint)(bits[trfix[06]]) >> (pnts[06].X & 0x1f))) & 1) << 06) |
                        (((((uint)(bits[trfix[07]]) >> (pnts[07].X & 0x1f))) & 1) << 07) |
                        (((((uint)(bits[trfix[08]]) >> (pnts[08].X & 0x1f))) & 1) << 08) |
                        (((((uint)(bits[trfix[09]]) >> (pnts[09].X & 0x1f))) & 1) << 09) |
                        (((((uint)(bits[trfix[10]]) >> (pnts[10].X & 0x1f))) & 1) << 10) |
                        (((((uint)(bits[trfix[11]]) >> (pnts[11].X & 0x1f))) & 1) << 11) |
                        (((((uint)(bits[trfix[12]]) >> (pnts[12].X & 0x1f))) & 1) << 12) |
                        (((((uint)(bits[trfix[13]]) >> (pnts[13].X & 0x1f))) & 1) << 13) |
                        (((((uint)(bits[trfix[14]]) >> (pnts[14].X & 0x1f))) & 1) << 14) |
                        (((((uint)(bits[trfix[15]]) >> (pnts[15].X & 0x1f))) & 1) << 15) |
                        (((((uint)(bits[trfix[16]]) >> (pnts[16].X & 0x1f))) & 1) << 16) |
                        (((((uint)(bits[trfix[17]]) >> (pnts[17].X & 0x1f))) & 1) << 17) |
                        (((((uint)(bits[trfix[18]]) >> (pnts[18].X & 0x1f))) & 1) << 18) |
                        (((((uint)(bits[trfix[19]]) >> (pnts[19].X & 0x1f))) & 1) << 19) |
                        (((((uint)(bits[trfix[20]]) >> (pnts[20].X & 0x1f))) & 1) << 20) |
                        (((((uint)(bits[trfix[21]]) >> (pnts[21].X & 0x1f))) & 1) << 21) |
                        (((((uint)(bits[trfix[22]]) >> (pnts[22].X & 0x1f))) & 1) << 22) |
                        (((((uint)(bits[trfix[23]]) >> (pnts[23].X & 0x1f))) & 1) << 23) |
                        (((((uint)(bits[trfix[24]]) >> (pnts[24].X & 0x1f))) & 1) << 24) |
                        (((((uint)(bits[trfix[25]]) >> (pnts[25].X & 0x1f))) & 1) << 25) |
                        (((((uint)(bits[trfix[26]]) >> (pnts[26].X & 0x1f))) & 1) << 26) |
                        (((((uint)(bits[trfix[27]]) >> (pnts[27].X & 0x1f))) & 1) << 27) |
                        (((((uint)(bits[trfix[28]]) >> (pnts[28].X & 0x1f))) & 1) << 28) |
                        (((((uint)(bits[trfix[29]]) >> (pnts[29].X & 0x1f))) & 1) << 29) |
                        (((((uint)(bits[trfix[30]]) >> (pnts[30].X & 0x1f))) & 1) << 30) |
                        (((((uint)(bits[trfix[31]]) >> (pnts[31].X & 0x1f))) & 1) << 31));

                    newBits[i] = newI & newI_mask;
                }
            }

            return new BitMatrix(nw, nh, nrs, newBits);
        }

        private int bits_c(int ix)
        {
            if (ix < 0 || ix > bits.Length) return 0;
            else return bits[ix];
        }
    }
}
