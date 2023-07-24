using TestSwaggerLogin.ViewModel;

namespace TestSwaggerLogin.View
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow(VmBase viewModel)
        {
            InitializeComponent();
            DataContext = viewModel;
        }
    }
}
