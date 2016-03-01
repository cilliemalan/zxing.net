using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZXing.Common
{
    public class RotationTransformation : Transformation
    {
        private readonly double _angle;
        private readonly float sinA;
        private readonly float cosA;
        private readonly float w;
        float h;
        float w2;
        float h2;
        int neww;
        int newh;
        int nw2;
        int nh2;

        public RotationTransformation(double angle, int w, int h)
        {
            this.w = w;
            this.h = h;
            w2 = w * 0.5f;
            h2 = h * 0.5f;

            _angle = angle;
            sinA = (float)Math.Sin(angle);
            cosA = (float)Math.Cos(angle);

            float x0 = (-w2) * cosA - (-h2) * sinA;
            float y0 = (-w2) * sinA + (-h2) * cosA;
            float x1 = (w2) * cosA - (-h2) * sinA;
            float y1 = (w2) * sinA + (-h2) * cosA;
            float x2 = (w2) * cosA - (h2) * sinA;
            float y2 = (w2) * sinA + (h2) * cosA;
            float x3 = (-w2) * cosA - (h2) * sinA;
            float y3 = (-w2) * sinA + (h2) * cosA;
            float minx = Math.Min(Math.Min(x0, x1), Math.Min(x2, x3));
            float maxx = Math.Max(Math.Max(x0, x1), Math.Max(x2, x3));
            float miny = Math.Min(Math.Min(y0, y1), Math.Min(y2, y3));
            float maxy = Math.Max(Math.Max(y0, y1), Math.Max(y2, y3));

            neww = (int)(maxx - minx);
            newh = (int)(maxy - miny);
            nw2 = neww / 2;
            nh2 = newh / 2;
        }

        public override Point ReverseTransform(int px, int py)
        {
            var x = px - w2;
            var y = py - h2;
            var rx = x * cosA + y * sinA;
            var ry = - x * sinA + y * cosA;

            return new Point((int)(rx + nw2), (int)(ry + nh2));
        }

        public override Point Transform(int px, int py)
        {
            var x = px - nw2;
            var y = py - nh2;
            var rx = x * cosA - y * sinA;
            var ry = x * sinA + y * cosA;

            return new Point((int)(rx + w2), (int)(ry + h2));
        }

        public override Point[] BulkTransform(Point[] pnts, int offset, int amount, int startX, int py)
        {
            var y = py - nh2;
            var ycosA = y * cosA;
            var ysinA = y * sinA;

            for (int px = startX, i = offset; i < amount; i++, px++)
            {
                var x = px - nw2;
                var rx = x * cosA - ysinA;
                var ry = x * sinA + ycosA;

                pnts[i] = new Point((int)(rx + w2), (int)(ry + h2));
            }

            return pnts;
        }
    }
}
