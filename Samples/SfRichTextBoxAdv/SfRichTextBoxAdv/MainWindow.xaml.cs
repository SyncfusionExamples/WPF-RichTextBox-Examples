using System.Windows;

namespace SfRichTextBoxAdv
{
    #region Constructor
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // Loads the specified Word document into the SfRichTextBoxAdv control.
            richTextBoxAdv.Load(@"Assets/GettingStarted.docx");
        }
    }
    #endregion
}