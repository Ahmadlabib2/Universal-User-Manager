using Catel.Windows.Controls;

namespace UUM.Controls.Views
{
    /// <summary>
    /// Interaction logic for RepositorySettingsControl.xaml.
    /// </summary>
    public partial class RepositorySettingsControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RepositorySettingsControl"/> class.
        /// </summary>
        public RepositorySettingsControl()
        {
            InitializeComponent();
            DisableWhenNoViewModel = true;
        }
    }
}
