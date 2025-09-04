using OxVidco.ViewModels;

namespace OxVidco.Views
{
    public partial class UpdateView : System.Windows.Controls.UserControl
    {
        /// <summary>
        /// Constructor for UpdateView
        /// </summary>
        /// <remarks>
        /// This constructor initializes the view and sets the DataContext to an instance of
        /// UpdateViewModel. If the DataContext is null, it throws a NullReferenceException.
        /// </remarks>
        public UpdateView()
        {
            InitializeComponent();

            var dataContext = new UpdateViewModel();

            DataContext = dataContext ?? throw new NullReferenceException("UpdateViewModel is null");
        }
    }
}