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

		public MapPage(ViewModels.MapViewModel Map)
		{
			InitializeComponent();
			this.Map = Map;
		}

		/// <summary>
		/// Draw Node on canvas at coordinates x,y and take picture from uri
		/// </summary>
		/// <param name="x"> X coord </param>
		/// <param name="y"> Y coord </param>
		void drawNode(int x, int y, string uri)
		{

		}
	}
}
