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
			for(var i = 0; i < Map.CanvasNodes.Count; i++)
			{
				drawNode(Map.CanvasNodes[i].X, Map.CanvasNodes[i].Y, Map.CanvasNodes[i].ImageSource);
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
