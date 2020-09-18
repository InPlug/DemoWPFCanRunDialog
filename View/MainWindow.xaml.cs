using System.Windows;
using Xceed.Wpf.Toolkit;

namespace DemoWPFCanRunDialog.View
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region public members

        /// <summary>
        /// Konstruktor des Haupt-Fensters.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            //Point renderedLocation = this.TranslatePoint(new Point(0, 0), Application.Current.MainWindow);
            //Point renderedLocation = this.TranslatePoint(new Point(0, 0), Window.GetWindow(this));
        }

        #endregion public members

        #region private members

        #endregion private members

    }
}
