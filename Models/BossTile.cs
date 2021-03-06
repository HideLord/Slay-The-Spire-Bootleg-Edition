﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoVis.Models
{
	public class BossTile : EnemyTile
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
