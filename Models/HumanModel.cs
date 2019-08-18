using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoVis.Models
{
	/// <summary>
	/// A base class containing only mandatory info about the human object
	/// </summary>
    public abstract class HumanModel
    {
		public int Health { get; set; }
		public Point Coords
		{
			get { return Coords; }
			set{ Coords.copyFrom(value as Point); }
		}
    }
}
