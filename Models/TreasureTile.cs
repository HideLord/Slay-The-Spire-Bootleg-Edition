using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoVis.Models
{
	public class TreasureTile : Tile
	{
		public List<Card> Deck;

		public override void Activate()
		{
			for(int i = 0; i < 3; i++)
			{
				Deck.Add(Generator.GenerateRandomWeapon());
			}
		}
	}
}
