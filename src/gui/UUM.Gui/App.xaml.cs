using System.Windows;

using Catel.IoC;
using Catel.Logging;

using UUM.Api.Interfaces;
using UUM.Engine.Services;

namespace UUM.Gui
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App
	{
		
        protected override void OnStartup(StartupEventArgs e)
        {
        	#if DEBUG
        	LogManager.RegisterDebugListener();
        	#endif
            log4net.Config.XmlConfigurator.Configure();
            
            Catel.Windows.StyleHelper.CreateStyleForwardersForDefaultStyles();

            ServiceLocator.Default.RegisterType<IPluginRepository, PluginRepository>();

            base.OnStartup(e);
        }
	}
}