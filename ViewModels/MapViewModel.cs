using AlgoVis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoVis.ViewModels
{
	public class MapViewModel : BaseViewModel
	{
		/// <summary>
		/// Absolutely not sure if this will work or not! Needs testing...
		/// </summary>
		public Tile LevelMap { get; set; } // = Generator.GenerateMap(10, 1, 1);
		public MapViewModel()
		{
			LevelMap = Generator.GenerateMapSpire(16, 5, 4, 5, 10);
			GenerateCanvasLayout();
		}

		/// <summary>
		/// Traverses the map tree and lays out the map
		/// </summary>
		private void GenerateCanvasLayout()
		{
			Stack<Tile> TileStack = new Stack<Tile>();
			TileStack.Push(LevelMap);
			while (TileStack.Count != 0)
			{

			}
		}
	}
}
