using AlgoVis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoVis.ViewModels
{
	class MapViewModel : BaseViewModel
	{
		/// <summary>
		/// Absolutely not sure if this will work or not! Needs testing...
		/// </summary>
		public Tile LevelMap { get; set; } // = Generator.GenerateMap(10, 1, 1);
	}
}
