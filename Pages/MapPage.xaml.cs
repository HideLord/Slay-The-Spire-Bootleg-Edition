using AlgoVis.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AlgoVis.Pages
{
	/// <summary>
	/// Interaction logic for MapPage.xaml
	/// </summary>
	public partial class MapPage : Page
	{
		public ViewModels.MapViewModel Map;

		public MapPage()
		{
			InitializeComponent();
			Map = new ViewModels.MapViewModel();
			drawMap();
		}

		public MapPage(ViewModels.MapViewModel Map)
		{
			InitializeComponent();
			this.Map = Map;
		}

		public void drawMap()
		{
			for (var i = 0; i < Map.CanvasNodes.Count; i++)
			{
				for (var j = 0; j < Map.CanvasNodes[i].Count; j++)
				{
					drawPaths(Map.CanvasNodes[i][j]);
				}
			}
			for (var i = 0; i < Map.CanvasNodes.Count; i++)
			{
				for (var j = 0; j < Map.CanvasNodes[i].Count; j++) {
					drawNode(Map.CanvasNodes[i][j].X, Map.CanvasNodes[i][j].Y, Map.CanvasNodes[i][j].ImageSource);
				}
			}
		}

		void drawPaths(CanvasNode node)
		{
			for(int i = 0; i < node.Neighbours.Count; i++)
			{
				Line line = new Line();
				line.StrokeThickness = 4;
				line.Stroke = System.Windows.Media.Brushes.Black;
				line.X1 = node.X + 32;
				line.X2 = node.Neighbours[i].X + 32;
				line.Y1 = node.Y + 32;
				line.Y2 = node.Neighbours[i].Y + 32;
				MapCanvas.Children.Add(line);
			}
		}

		/// <summary>
		/// Draw Node on canvas at coordinates x,y and take picture from uri
		/// </summary>
		/// <param name="x"> X coord </param>
		/// <param name="y"> Y coord </param>
		void drawNode(double x, double y, string uri)
		{
			Button NodeButton = new Button();
			Image NodeSprite = new Image();
			NodeSprite.Source = new BitmapImage(new Uri("../"+uri, UriKind.Relative));
			NodeButton.Content = NodeSprite;
			NodeButton.RenderTransform = new TranslateTransform(x, y);
			NodeButton.Background = new SolidColorBrush(Colors.Transparent);
			NodeButton.BorderBrush = new SolidColorBrush(Colors.Transparent);
			MapCanvas.Children.Add(NodeButton);
		}
	}
}
