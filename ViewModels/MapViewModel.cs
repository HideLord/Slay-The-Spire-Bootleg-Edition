using AlgoVis.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoVis.ViewModels
{
	/// <summary>
	/// A simple class to hold info about a node
	/// </summary>
	public class CanvasNode
	{
		/// <summary>
		/// X and Y coordinates
		/// </summary>
		public double X { get; set; }
		public double Y { get; set; }
		/// <summary>
		/// The image source for the node
		/// </summary>
		public string ImageSource { get; set; }
	}

	public class MapViewModel : BaseViewModel
	{
		private static double NodeSpace = 64;
		private static double MapPadding = 64;
		private static double NodeMargin = 64;
		private static double LayerSpace = 128;

		public Tile LevelMap { get; set; }
		public List<CanvasNode> CanvasNodes { get; set; }

		public MapViewModel()
		{
			LevelMap = Generator.GenerateMapSpire(16, 5, 4, 5, 10);
			CanvasNodes = new List<CanvasNode>();
			GenerateCanvasLayout();
		}
		public MapViewModel(Tile LevelMap)
		{
			this.LevelMap = LevelMap;
			CanvasNodes = new List<CanvasNode>();
			GenerateCanvasLayout();
		}

		/// <summary>
		/// Traverses the map tree and lays out the map for the canvas
		/// </summary>
		private void GenerateCanvasLayout()
		{
			Queue<KeyValuePair<Tile, int>> TileStack = new Queue<KeyValuePair<Tile, int>>();
			TileStack.Enqueue(new KeyValuePair<Tile, int>(LevelMap,0));
			bool[,] used = new bool[500,500];

			while (TileStack.Count != 0)
			{
				var curr = TileStack.Dequeue();

				var currTile  = curr.Key;
				var currdepth = curr.Value;
				var currCanvasNode = new CanvasNode();

				for(var i = 0; i < currTile.Neighbours.Count; i++)
				{
					if (used[currTile.Neighbours[i].LayerInd, currTile.Neighbours[i].NodeInd]) continue;
					used[currTile.Neighbours[i].LayerInd, currTile.Neighbours[i].NodeInd] = true;
					TileStack.Enqueue(new KeyValuePair<Tile,int>(currTile.Neighbours[i], currdepth+1));
				}

				currCanvasNode.X = (currTile.NodeInd * (NodeSpace + NodeMargin)) + MapPadding;
				currCanvasNode.Y = (currTile.LayerInd * LayerSpace) + MapPadding;

				if (currTile.GetType() == typeof(EnemyTile))
				{
					currCanvasNode.ImageSource = "Images/EnemyIcon.png";
				}
				else if (currTile.GetType() == typeof(EliteTile))
				{
					currCanvasNode.ImageSource = "Images/EliteIcon.png";
				}
				else if (currTile.GetType() == typeof(TreasureTile))
				{
					currCanvasNode.ImageSource = "Images/TreasureIcon.png";
				}
				else if (currTile.GetType() == typeof(EventTile))
				{
					currCanvasNode.ImageSource = "Images/EventIcon.png";
				}
				else if (currTile.GetType() == typeof(BossTile))
				{
					currCanvasNode.ImageSource = "Images/BossIcon.png";
				}
				else if (currTile.GetType() == typeof(Tile))
				{
					// This is the spawn tile and should be ignored
					continue;
				}
				else
				{
					throw new Exception("Unexpected class while traversing map" + currTile.GetType().ToString());
				}

				CanvasNodes.Add(currCanvasNode);
			}
		}

	}
}
