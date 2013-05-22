
using System;
using System.Windows;
using Catel.MVVM.Services;
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
			var messageService = GetService<IMessageService>();
			if (messageService.Show("Are you sure you want to do this?", "Are you sure?", MessageButton.YesNo) == MessageResult.Yes)
			{
				Application.Current.Shutdown();
				// Do it!
			}
			//TODO: ask user
			
		}
	}
}