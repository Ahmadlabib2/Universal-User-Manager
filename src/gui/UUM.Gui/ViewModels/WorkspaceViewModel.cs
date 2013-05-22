
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using Catel.Data;
using Catel.MVVM;

using UUM.Api;
using System.ComponentModel.Composition.Hosting;

using UUM.Engine;
using UUM.Controls.ViewModels;

namespace UUM.Gui.ViewModels
{
	/// <summary>
	/// Description of WorkspaceViewModel.
	/// </summary>
	public class WorkspaceViewModel : ViewModelBase
	{
		public WorkspaceViewModel()
		{
			NewProject = new Command(OnNewProjectExecuted, OnNewProjectCanExecute);
			SaveProject = new Command(OnSaveProjectExecuted, OnSaveProjectCanExecute);
			//TODO: LoadProject

            // MEF loading of available plugins
            var catalog = new DirectoryCatalog(".", "UUM.Plugin.*.dll");
            var container = new CompositionContainer(catalog);
            
            container.SatisfyImportsOnce(this);
		}
		
		#region Property: Project
		public ProjectViewModel Project
		{
            get { return GetValue<ProjectViewModel>(ProjectProperty); }
            set { SetValue(ProjectProperty, value); }
		}
        public static readonly PropertyData ProjectProperty = 
            RegisterProperty("Project", typeof (ProjectViewModel), null);
		#endregion
		
		#region Command: NewProject
		public Command NewProject { get; private set; }

		private void OnNewProjectExecuted()
		{
			Project = new ProjectViewModel(new Project());
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
			//HACK: use the catel File services to ask user for a fileName
			Project.Model.Save("project.xml", SerializationMode.Xml);
		}
		
		private bool OnSaveProjectCanExecute()
		{
			return Project != null;
		}
		#endregion

        [ImportMany(AllowRecomposition = true)]
        public ObservableCollection<IPlugin> Plugins { get; set; }
	}
}
