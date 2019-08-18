using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace AlgoVis
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			CompositionTarget.Rendering += GameLoop;

		}

		private void OnKeyDownHandler(object sender, KeyEventArgs e)
		{
			var win = sender as Window;
			if (e.Key == Key.W) // Go up
			{
				Console.WriteLine("W");
			}
			if(e.Key == Key.A) // Go left
			{

			}
			if(e.Key == Key.S) // Go down
			{

			}
			if(e.Key == Key.D) // Go Right
			{

			}
		}
		private void OnKeyUpHandler(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.E ||
				e.Key == Key.Escape) // Set Key as down
			{
				KeyIsDown[e.Key] = true;
			}
		}
		private void GameLoop(object sender, System.EventArgs e)
		{
			
		}

		
	}
}
