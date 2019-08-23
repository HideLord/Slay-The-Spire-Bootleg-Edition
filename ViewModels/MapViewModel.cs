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
		/// <summary>
		/// The model of the node
		/// </summary>
		public Tile Model;
		/// <summary>
		/// The neighbouring nodes in the map
		/// </summary>
		public List<CanvasNode> Neighbours;

		public CanvasNode()
		{
			Neighbours = new List<CanvasNode>();
		}
	}

	public class MapViewModel : BaseViewModel
	{
		private static double NodeSpace = 64;
		private static double MapPadding = 64;
		private static double NodeMargin = 64;
		private static double LayerSpace = 192;

		public Tile LevelMap { get; set; }
		public List<List<CanvasNode>> CanvasNodes { get; set; }

		public MapViewModel()
		{
			LevelMap = Generator.GenerateMapSpire(16, 5, 4, 5, 10);
			CanvasNodes = new List<List<CanvasNode>>();
			GenerateCanvasLayout();
		}
		public MapViewModel(Tile LevelMap)
		{
			this.LevelMap = LevelMap;
			CanvasNodes = new List<List<CanvasNode>>();
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
				currCanvasNode.Model = currTile;

				for(var i = 0; i < currTile.Neighbours.Count; i++)
				{
					if (used[currTile.Neighbours[i].LayerInd, currTile.Neighbours[i].NodeInd]) continue;
					used[currTile.Neighbours[i].LayerInd, currTile.Neighbours[i].NodeInd] = true;
					TileStack.Enqueue(new KeyValuePair<Tile,int>(currTile.Neighbours[i], currdepth+1));
				}
				
				if (currTile.GetType() == typeof(EnemyTile))
				{
					currCanvasNode.ImageSource = "Images/MapIcons/EnemyIcon.png";
				}
				else if (currTile.GetType() == typeof(EliteTile))
				{
					currCanvasNode.ImageSource = "Images/MapIcons/EliteIcon.png";
				}
				else if (currTile.GetType() == typeof(TreasureTile))
				{
					currCanvasNode.ImageSource = "Images/MapIcons/TreasureIcon.png";
				}
				else if (currTile.GetType() == typeof(EventTile))
				{
					currCanvasNode.ImageSource = "Images/MapIcons/EventIcon.png";
				}
				else if (currTile.GetType() == typeof(BossTile))
				{
					currCanvasNode.ImageSource = "Images/MapIcons/BossIcon.gif";
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

				if (CanvasNodes.Count <= currTile.LayerInd) CanvasNodes.Add(new List<CanvasNode>());
				while (CanvasNodes[currTile.LayerInd].Count <= currTile.NodeInd) CanvasNodes[currTile.LayerInd].Add(new CanvasNode());
				CanvasNodes[currTile.LayerInd][currTile.NodeInd] = currCanvasNode;
			}

			for (var layer = 0; layer < CanvasNodes.Count(); layer++)
			{
				int NCount = CanvasNodes[layer].Count();
				double PrevX = MapPadding;
				for (var node = 0; node < CanvasNodes[layer].Count(); node++)
				{
					CanvasNode currNode = CanvasNodes[layer][node];

					currNode.X = Generator.GenerateRandomInt((int)PrevX, (int)(MapPadding + (node+1)*(7 / NCount) * (NodeSpace + NodeMargin) + 1));
					currNode.Y = MapPadding + LayerSpace * (layer) + Generator.GenerateRandomInt((int)-NodeSpace/2, (int)NodeSpace/2);
					PrevX = currNode.X + NodeMargin + NodeSpace;

					if (currNode.Model != null)
					{
						for (int i = 0; i < currNode.Model.Neighbours.Count; i++)
						{
							// HAHA good luck getting this one future me!
							currNode.Neighbours.Add(CanvasNodes[currNode.Model.Neighbours[i].LayerInd][currNode.Model.Neighbours[i].NodeInd]);
							if(currNode.Model.Neighbours[i].LayerInd == 0 && currNode.Model.Neighbours[i].NodeInd == 0)
							{

							}
						}
					}
				}
			}
		}

	}
}
