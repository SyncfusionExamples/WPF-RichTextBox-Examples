using Syncfusion.Windows.Tools.Controls;


namespace SfRichTextBoxAdv_with_SfRichTextRibbon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : RibbonWindow
    {

        #region Constructor
        public MainWindow()
        {
            InitializeComponent();

            // Loads the specified Word document into the SfRichTextBoxAdv control.
            richTextBoxAdv.Load(@"Assets/GettingStarted.docx");
        }
        #endregion
    }
}
