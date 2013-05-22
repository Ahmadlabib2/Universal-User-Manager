
using System;
using System.Windows;
using Catel.Windows.Controls;

namespace UUM.Gui.Views
{
	/// <summary>
	/// Interaction logic for WorkspaceView.xaml
	/// </summary>
	public partial class WorkspaceView : UserControl
	{
		public WorkspaceView()
		{
			InitializeComponent();
		}
		
		private void ApplicationExit_Click(object sender, System.Windows.RoutedEventArgs e)
		{
			//TODO: ask user
            Application.Current.Shutdown();
		}
	}
}