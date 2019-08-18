using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoVis.Models
{
	/// <summary>
	/// Basic class containing information about a point.
	/// What did you expect
	/// </summary>
    public class Point
    {
		public int x { get; set; }
		public int y { get; set; }
		public Point(int x, int y)
		{
			this.x = x;
			this.y = y;
		}
		public void copyTo(ref Point A)
		{
			A.x = x;
			A.y = y;
		}
		public void copyFrom(Point A)
		{
			x = A.x;
			y = A.y;
		}
	}
}
