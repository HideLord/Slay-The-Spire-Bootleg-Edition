using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoVis.Models
{
	/// <summary>
	/// Just a base model for all of the tiles
	/// </summary>
	public class Tile {
		public Tile()
		{
			Neighbours = new List<Tile>();
		}
		public List<Tile> Neighbours;
		public virtual void Activate()
		{
			throw new NotImplementedException();
		}
    }
}
