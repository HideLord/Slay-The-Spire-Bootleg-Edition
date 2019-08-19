using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoVis.Models
{
	class EliteTile : EnemyTile
	{
		public List<Trinket> Trinkets;

		public override void Activate()
		{
			Deck.Add(Generator.GenerateRandomWeapon());
			Deck.Add(Generator.GenerateRandomUtility());
			Deck.Add(Generator.GenerateRandomDefence());
		}
	}
}
