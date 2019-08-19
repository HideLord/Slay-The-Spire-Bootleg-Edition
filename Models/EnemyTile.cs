using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoVis.Models
{
	public class EnemyTile : Tile
	{
		public List<Card> Deck;
		public List<Enemy> Enemies;
		public override void Activate()
		{
			throw new NotImplementedException();
		}
	}
}
