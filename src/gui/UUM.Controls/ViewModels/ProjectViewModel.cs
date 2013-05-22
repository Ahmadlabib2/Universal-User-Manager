// See LICENCE.txt in the root for conditions of use
using System;
using UUM.Engine;
using Catel.MVVM;

namespace UUM.Controls.ViewModels
{
	/// <summary>
	/// Description of ProjectViewModel.
	/// </summary>
	public class ProjectViewModel : ViewModelBase
	{
		private readonly Project Projectmodel;
		
	
			public ProjectViewModel(Project model)
			{
				Projectmodel = model;
			}
			
			[Model]
			public Project Model
			{
				get { return Projectmodel; }
			}
			
		}
	}
