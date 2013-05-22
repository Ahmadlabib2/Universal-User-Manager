using System.Windows;

namespace UUM.Gui
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
        protected override void OnStartup(StartupEventArgs e)
        {
			Catel.Windows.StyleHelper.CreateStyleForwardersForDefaultStyles();
            base.OnStartup(e);
        }
	}
}