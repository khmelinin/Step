using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;

namespace a12
{
    [Serializable]
    [SqlUserDefinedType(Format.Native, IsByteOrdered = true)]
    public struct Point:INullable
    {
        private int x;
        private int y;
        private bool isNull;
        public static Point Null
        {
            get
            {
                var p = new Point();
                p.isNull = true;
                return p;
            }
        }
        public bool IsNull => isNull;

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        [SqlMethod(OnNullCall = false)]
        public static Point Parse(SqlString str)
        {
            if (str.IsNull)
                return Null;
            var parts = str.Value.Split(',');
            if (parts.Length!=2)
            {
                throw new ArgumentException();
            }

            var result = new Point { X = Int32.Parse(parts[0]), Y = Int32.Parse(parts[1]) };
            return result;
        }
        public override string ToString()
        {
            if (this.isNull)
                return "NULL";
            return $"{X}, {Y}";
        }

        [SqlMethod(OnNullCall = false)]
        public double Distance(Point o)
        {
            return DistanceXY(o.X, o.Y);
        }

        [SqlMethod(OnNullCall = false)]
        private double DistanceXY(int x, int y)
        {
            return Math.Sqrt(Math.Pow(x - x, 2) + Math.Pow(Y - y, 2));
        }
    }
}
