using Catel.Windows;
using UUM.Gui.Helpers;

namespace UUM.Gui.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
#if DEBUG
        private readonly TraceOutputWindow _traceOutputWindow;
#endif

        public MainWindow()
            : base(DataWindowMode.Custom)
        {
            InitializeComponent();

#if DEBUG
            _traceOutputWindow = new TraceOutputWindow();
            _traceOutputWindow.Show();

            Closed += (sender, e) =>
                            {
                                if (_traceOutputWindow != null)
                                {
                                    _traceOutputWindow.Close();
                                }
                            };
#endif
        }
    }
}