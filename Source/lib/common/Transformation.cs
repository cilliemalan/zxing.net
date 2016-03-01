namespace ZXing.Common
{
    public abstract class Transformation
    {
        public abstract Point Transform(int x, int y);
        public abstract Point ReverseTransform(int x, int y);

        public virtual Point Transform(Point p) { return Transform(p.X, p.Y); }
        public virtual Point ReverseTransform(Point p) { return ReverseTransform(p.X, p.Y); }

        public virtual Point[] BulkTransform(Point[] pnts, int offset, int amount, int startX, int y)
        {
            for (int x = startX, i = offset; i < amount; i++, x++)
            {
                pnts[i] = Transform(x, y);
            }

            return pnts;
        }

        public struct Point
        {
            public Point(int x, int y) { X = x; Y = y; }
            public int X, Y;
        }
    }
}