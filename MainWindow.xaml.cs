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
		}
		
		private void GameLoop(object sender, System.EventArgs e)
		{
			
		}

		
	}
}
