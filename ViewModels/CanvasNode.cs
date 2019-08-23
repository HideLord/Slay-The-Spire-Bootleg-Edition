using AlgoVis.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgoVis.ViewModels
{
	/// <summary>
	/// A simple class to hold info about a node
	/// </summary>
	public class CanvasNode : BaseViewModel
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
		public Tile Model { get; set; }
		/// <summary>
		/// The neighbouring nodes in the map
		/// </summary>
		public List<CanvasNode> Neighbours { get; set; }

		public CanvasNode()
		{
			Neighbours = new List<CanvasNode>();
		}
	}
}
