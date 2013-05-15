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
			IFormatter formatter = new BinaryFormatter();
			User.SerializeItem("D:/Work/uum/Users.xml", formatter);
			InitializeComponent();
		}
	}
}