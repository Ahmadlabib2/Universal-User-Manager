using System.Collections.ObjectModel;
using System.Windows;
using Catel.Data;
using Catel.MVVM;
using Catel.MVVM.Services;
using Catel.MVVM.Tasks;
using UUM.Api.Interfaces;
using UUM.Engine.Models;
using Catel.Logging;

namespace UUM.Gui.ViewModels
{
    /// <summary>
    ///     Description of WorkspaceViewModel.
    /// </summary>
    public class WorkspaceViewModel : ViewModelBase
    {
        /// <summary>UUM Project files|*.uumx|All files|*.*</summary>
        private const string UumProjectFileFilter = "UUM Project files|*.uumx|All files|*.*";
        private readonly ILog _log = LogManager.GetCurrentClassLogger();
        //AddListener(new Log4netListener());
        
        
        //GetLogger(typeof(WorkspaceViewModel));


        public WorkspaceViewModel()
        {
            var splashScreenService = GetService<ISplashScreenService>();
            splashScreenService.Enqueue(new ActionTask("Loading plug-ins", OnLoadPlugins));
            splashScreenService.Commit();
            NewProject = new Command(OnNewProjectExecuted, OnNewProjectCanExecute);
            SaveProject = new Command(OnSaveProjectExecuted, OnSaveProjectCanExecute);
            LoadProject = new Command(OnLoadProjectExecuted, OnLoadProjectCanExecute);
            CloseProject = new Command(OnCloseProjectExecute, OnCloseProjectCanExecute);
            ApplicationExit = new Command(OnApplicationExitExecuted);
           
            
        }

        private void OnLoadPlugins(ITaskProgressTracker tracker)
        {
            var pluginRepository = GetService<IPluginRepository>();
            pluginRepository.Initialize();
            Plugins = pluginRepository.Plugins;
        }

        #region Properties

        /// <summary>
        ///     Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title
        {
            get { return "Workspace"; }
        }
		
        #endregion
		
        #region Property: Project

        public static readonly PropertyData ProjectProperty =
            RegisterProperty("Project", typeof (ProjectModel), null);

        public ProjectModel Project
        {
            get { return GetValue<ProjectModel>(ProjectProperty); }
            set { SetValue(ProjectProperty, value); }
        }

        #endregion
		
        #region Property: Plugins

        public static readonly PropertyData PluginsProperty =
            RegisterProperty("Plugins", typeof (ObservableCollection<IPlugin>), new ObservableCollection<IPlugin>());

        public ObservableCollection<IPlugin> Plugins
        {
            get { return GetValue<ObservableCollection<IPlugin>>(PluginsProperty); }
            set { SetValue(PluginsProperty, value); }
        }

        #endregion

        #region Command: NewProject

        public Command NewProject { get; private set; }

        private void OnNewProjectExecuted()
        {
            Project = new ProjectModel();
           // LogManager.AddListener(new FileLogListener("UUM.log"));
            _log.Info("NewProject command executed");
        }

        private bool OnNewProjectCanExecute()
        {
            return Project == null;
        }

        #endregion

        #region Command: SaveProject

        public Command SaveProject { get; private set; }

        private void OnSaveProjectExecuted()
        {
            var saveFileService = GetService<ISaveFileService>();
            saveFileService.Filter = UumProjectFileFilter;
            if (saveFileService.DetermineFile())
            {
                string fileName = saveFileService.FileName;
                Project.Save(fileName, SerializationMode.Xml);
                //TODO: Listener must be setup at application startup!
               //  LogManager.AddListener(new FileLogListener("UUM.log"));
               _log.Info("SaveProject command executed: '{0}'", fileName);
            }
        }

        private bool OnSaveProjectCanExecute()
        {
            return Project != null;
        }

        #endregion

        #region Command: LoadProject

        public Command LoadProject { get; private set; }

        private void OnLoadProjectExecuted()
        {
            var openFileService = GetService<IOpenFileService>();
            openFileService.Filter = UumProjectFileFilter;
            if (openFileService.DetermineFile())
            {
                string fileName = openFileService.FileName;
                Project = ProjectModel.Load(fileName, SerializationMode.Xml);
                //TODO: No.....
                // LogManager.AddListener(new FileLogListener("UUM.log"));
                 
                _log.Info("LoadProject command executed: '{0}'", fileName);
            }
        }

        private bool OnLoadProjectCanExecute()
        {
            return Project == null;
        }

        #endregion

        #region Command: CloseProject

        public Command CloseProject { get; private set; }

        private void OnCloseProjectExecute()
        {
            Project = null;
        }

        private bool OnCloseProjectCanExecute()
        {
            return Project != null;
        }

        #endregion

        #region Command: ApplicationExit

        public Command ApplicationExit { get; private set; }

        private void OnApplicationExitExecuted()
        {
            var messageService = GetService<IMessageService>();
            if (messageService.Show("Are you sure you want to exit application?",
                                    "Are you sure?", MessageButton.YesNo) == MessageResult.Yes)
            {
                Application.Current.Shutdown();
                // Do it!
            }
        }

        #endregion
    }
}