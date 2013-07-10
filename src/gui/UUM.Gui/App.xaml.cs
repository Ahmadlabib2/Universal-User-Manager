using System.Windows;
using Catel.IoC;
using UUM.Api.Interfaces;
using UUM.Engine.Services;
using log4net.Config;

namespace UUM.Gui
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
        protected override void OnStartup(StartupEventArgs e)
        {
            //HACK: this is wrong for use of log4net over Catel
            XmlConfigurator.Configure();
            
            Catel.Windows.StyleHelper.CreateStyleForwardersForDefaultStyles();

            ServiceLocator.Default.RegisterType<IPluginRepository, PluginRepository>();

            base.OnStartup(e);
        }
	}
}