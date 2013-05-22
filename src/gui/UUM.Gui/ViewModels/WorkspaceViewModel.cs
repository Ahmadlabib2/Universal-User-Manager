
using System;
using Catel.Data;
using Catel.MVVM;
using Catel.MVVM.Services;
using UUM.Controls.ViewModels;
using UUM.Engine;

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
			
			var saveFileService = GetService<ISaveFileService>();
			saveFileService.Filter = "C# File|*.cs";
			if (saveFileService.DetermineFile())
			{
				
				Project.Model.Save(saveFileService.FileName ,SerializationMode.Xml);
				
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
			openFileService.Filter = "All files|*.*";
			if (openFileService.DetermineFile())
			{
				Project.Load(openFileService.FileName);
				
			}
			
		}
		#endregion
		
	}
}
