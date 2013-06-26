using System.Windows;
using Catel.IoC;
using UUM.Api.Interfaces;
using UUM.Engine.Services;

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

            ServiceLocator.Default.RegisterType<IPluginRepository, PluginRepository>();
            
            base.OnStartup(e);
        }
	}
}