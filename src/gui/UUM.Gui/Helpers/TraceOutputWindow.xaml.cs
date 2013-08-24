using Catel.Windows;

namespace UUM.Gui.Helpers
{
    /// <summary>
    /// Interaction logic for TraceOutputWindow.xaml
    /// </summary>
    public partial class TraceOutputWindow
    {
        public TraceOutputWindow()
            : base(DataWindowMode.Custom, setOwnerAndFocus: false)
        {
            InitializeComponent();
        }

        protected override System.Type GetViewModelType()
        {
            return typeof(TraceOutputViewModel);
        }
    }
}
