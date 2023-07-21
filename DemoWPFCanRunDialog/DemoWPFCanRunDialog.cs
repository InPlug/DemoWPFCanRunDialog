using System.Linq;
using Vishnu.Interchange;
using DemoWPFCanRunDialog.ViewModel;
using System.Windows;

namespace DemoWPFCanRunDialog
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public class DemoWPFCanRunDialog : ICanRun
    {
        /// <summary>
        /// Startet die Abfrage, ob der Knoten (Checker) gestartet werden kann
        /// - wird von einem Knoten im LogicalTaskTree aufgerufen.
        /// </summary>
        /// <param name="parameters">Spezifische Aufrufparameter oder null.</param>
        /// <param name="treeParameters">Für den gesamten Tree gültige Parameter oder null.</param>
        /// <param name="source">Auslösendes TreeEvent oder null.</param>
        /// <returns>True, wenn der Knoten (Checker) gestartet werden darf.</returns>
        public bool CanRun(ref object? parameters, TreeParameters treeParameters, TreeEvent source)
        {
            // Parameterübernahme
            string callingNodeId = source.NodeName;
            if (source.Results != null && source.Results.Count > 0)
            {
                Result? lastResult = source.Results.First().Value;
            }

            // Die Haupt-Klasse der Geschäftslogik
            this._mainBusinessLogic = new Model.MainBusinessLogic(callingNodeId);

            // Das Main-Window
            this._mainWindow = new View.MainWindow();

            // Das MainBusinessLogic-ViewModel
            this._mainBusinessLogicViewModel = new MainBusinessLogicViewModel(this._mainBusinessLogic, this._mainWindow);

            // Das Main-ViewModel
            this._mainWindowViewModel = new MainWindowViewModel(this._mainBusinessLogicViewModel);

            // Verbinden von Main-Window mit Main-ViewModel
            this._mainWindow.DataContext = this._mainWindowViewModel;

            bool rtn = false;

            this._mainWindow.WindowStartupLocation = System.Windows.WindowStartupLocation.Manual;
            Point parentViewAbsoluteScreenPosition = treeParameters.GetParentViewAbsoluteScreenPosition();
            this._mainWindow.Left = parentViewAbsoluteScreenPosition.X - this._mainWindow.ActualWidth / 2;
            this._mainWindow.Top = parentViewAbsoluteScreenPosition.Y - this._mainWindow.ActualHeight / 2;

            this._mainWindow.ShowDialog();
            if (this._mainBusinessLogic.DialogResult)
            {
                rtn = true;
            }
            return rtn;
        }

        private View.MainWindow? _mainWindow;
        private Model.MainBusinessLogic? _mainBusinessLogic;
        private MainBusinessLogicViewModel? _mainBusinessLogicViewModel;
        private MainWindowViewModel? _mainWindowViewModel;

    }
}
