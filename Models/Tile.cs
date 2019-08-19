using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoVis.Models
{
	/// <summary>
	/// Just a base model for all of the tiles 
	/// used only at spawn points as a gateway 
	/// to the level
	/// </summary>
	public class Tile {
		public bool wasVisited;
		public List<Tile> Neighbours;
		public Tile()
		{
			wasVisited = false;
			Neighbours = new List<Tile>();
		}
		public virtual void Activate()
		{
			throw new NotImplementedException();
		}
    }
}
