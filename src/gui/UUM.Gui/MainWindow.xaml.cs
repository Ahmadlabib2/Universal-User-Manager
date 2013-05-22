// See LICENCE.txt in the root for conditions of use
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;

using Catel.Data;
using UUM.Controls.ViewModels;
using UUM.Engine;

namespace UUM.Gui
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();

			//TODO: Remove this test code
			
			User user = new User()
			{
				FirstName = "Albert",
				LastName = "Einstein"
				
			};
			user.Save("Users.xml", SerializationMode.Xml);
			DataContext = new UserViewModel(user);
			
			Project project = new Project()
			{
			 ProjectName ="FirstProject",
			 ProjectDescription= "Load from LDAP"
			};
			project.Save("Projects.xml", SerializationMode.Xml);
			DataContext = new ProjectViewModel(project);
			
			
		}
	}
}