using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoVis.Models
{
	public class UnitStats
	{
		public int Mana { get; set; }
		public int Health { get; set; }
		public double AttackModifier { get; set; }
		public double PoisonModifier { get; set; }

	}
	public class Enemy
	{
		public List<Card> AttackSet;
		public UnitStats Stats;
	}
}
