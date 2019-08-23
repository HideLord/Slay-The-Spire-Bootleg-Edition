using System;
using System.Collections.Generic;
using System.IO;
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
	/// Interaction logic for CharacterSelectPage.xaml
	/// </summary>
	public partial class CharacterSelectPage : Page
	{
		public CharacterSelectPage()
		{
			InitializeComponent();
		}

		private void ChangeToLight(object sender, MouseEventArgs e)
		{
			Image Icon = sender as Image;
			if(Icon != null)
			{
				string SourceString = (Icon.Source as BitmapFrame).Decoder.ToString();
				if (SourceString.Substring(SourceString.Length - 9, 5) == "Light")
					return;
				SourceString = SourceString.Substring(0, SourceString.Length-4) + "Light.png";
				
				Icon.Source = BitmapFrame.Create(new Uri(SourceString));
			}
		}
		private void ChangeToNormal(object sender, MouseEventArgs e)
		{
			Image Icon = sender as Image;
			if (Icon != null)
			{
				string SourceString = ((BitmapFrame)Icon.Source).Decoder.ToString();
				if (SourceString.Substring(SourceString.Length - 9, 5) != "Light")
					return;
				SourceString = SourceString.Substring(0, SourceString.Length - 9) + ".png";

				Icon.Source = BitmapFrame.Create(new Uri(SourceString));
			}
		}
	}
}
