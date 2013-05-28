
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Windows;
using Catel.Data;
using Catel.MVVM;
using Catel.MVVM.Services;
using UUM.Api;
using UUM.Api.Interfaces;
using UUM.Engine.Models;

namespace UUM.Gui.ViewModels
{
    /// <summary>
    /// Description of WorkspaceViewModel.
    /// </summary>
    public class WorkspaceViewModel : ViewModelBase
    {
        /// <summary>UUM Project files|*.uumx|All files|*.*</summary>
        private const string UumProjectFileFilter = "UUM Project files|*.uumx|All files|*.*";

        public WorkspaceViewModel()
        {
            NewProject = new Command(OnNewProjectExecuted, OnNewProjectCanExecute);
            SaveProject = new Command(OnSaveProjectExecuted, OnSaveProjectCanExecute);
            LoadProject = new Command(OnLoadProjectExecuted, OnLoadProjectCanExecute);
            CloseProject = new Command(OnCloseProjectExecute, OnCloseProjectCanExecute);
            ApplicationExit = new Command(OnApplicationExitExecuted);
			
            // MEF loading of available plugins
            var catalog = new DirectoryCatalog(".", "UUM.Plugin.*.dll");
            var container = new CompositionContainer(catalog);

            container.SatisfyImportsOnce(this);
        }

        #region Properties
        /// <summary>
        /// Gets the title of the view model.
        /// </summary>
        /// <value>The title.</value>
        public override string Title { get { return "Workspace"; } }

        [ImportMany(AllowRecomposition = true)]
        public ObservableCollection<IPlugin> Plugins { get; set; }

        #endregion

        #region Property: Project
        public ProjectModel Project
        {
            get { return GetValue<ProjectModel>(ProjectProperty); }
            set { SetValue(ProjectProperty, value); }
        }
        public static readonly PropertyData ProjectProperty =
            RegisterProperty("Project", typeof(ProjectModel), null);
        #endregion

        #region Command: NewProject
        public Command NewProject { get; private set; }

        private void OnNewProjectExecuted()
        {
            Project = new ProjectModel();
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
                Project.Save(saveFileService.FileName, SerializationMode.Xml);
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
                Project = ProjectModel.Load(openFileService.FileName, SerializationMode.Xml);
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
