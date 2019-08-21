using AlgoVis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoVis.ViewModels
{
	public class CanvasNode
	{
		public int x { get; set; }
		public int y { get; set; }
		public string uri { get; set; }
	}

	public class MapViewModel : BaseViewModel
	{
		/// <summary>
		/// Absolutely not sure if this will work or not! Needs testing...
		/// </summary>
		public Tile LevelMap { get; set; } // = Generator.GenerateMap(10, 1, 1);
		public List<CanvasNode> CanvasNodes { get; set; }
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
			Stack<KeyValuePair<Tile, int>> TileStack = new Stack<KeyValuePair<Tile, int>>();
			TileStack.Push(new KeyValuePair<Tile, int>(LevelMap,0));
			while (TileStack.Count != 0)
			{

			}
		}
	}
}
