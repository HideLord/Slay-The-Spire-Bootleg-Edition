using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using AlgoVis.Models;

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
			var Spawn = Generator.GenerateMap(10, 1, 1);
		}

		private void OnKeyDownHandler(object sender, KeyEventArgs e)
		{
			
		}
		private void OnKeyUpHandler(object sender, KeyEventArgs e)
		{
			if (e.Key == Key.E) // Interact
			{

			}
			if (e.Key == Key.Escape) // Show game menu
			{

			}
		}
		private void GameLoop(object sender, System.EventArgs e)
		{
			
		}

		
	}
}
