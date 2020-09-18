using System;
using NetEti.MVVMini;
using System.Windows.Input;
using System.Windows;

namespace DemoWPFCanRunDialog.ViewModel
{
    /// <summary>
    /// ViewModel für das MainWindow.
    /// </summary>
    /// <remarks>
    /// File: MainWindowViewModel
    /// Autor: Erik Nagel
    ///
    /// 31.05.2015 Erik Nagel: erstellt
    /// </remarks>
    public class MainWindowViewModel : ObservableObject
    {
        #region public members

        /// <summary>
        /// ViewModel für das Hauptfenster.
        /// </summary>
        public MainBusinessLogicViewModel MainBusinessLogicViewModel_ { get; set; }

        /// <summary>
        /// Konstruktor - übernimmt das ViewModel für die Geschäftslogik.
        /// </summary>
        /// <param name="mainBusinessLogicViewModel">ViewModel für die Geschäftslogik.</param>
        public MainWindowViewModel(MainBusinessLogicViewModel mainBusinessLogicViewModel)
        {
            this.MainBusinessLogicViewModel_ = mainBusinessLogicViewModel;
        }

        #endregion public members

        #region private members

        #endregion private members

    }
}
