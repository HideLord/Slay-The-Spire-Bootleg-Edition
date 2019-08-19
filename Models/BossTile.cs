using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoVis.Models
{
	public class BossTile : Tile
	{
		public List<Trinket> Trinkets;
		public List<Card> Deck;

		public override void Activate()
		{
			Deck.Add(Generator.GenerateRandomWeapon());
			Deck.Add(Generator.GenerateRandomUtility());
			Deck.Add(Generator.GenerateRandomDefence());
		}
	}
}
