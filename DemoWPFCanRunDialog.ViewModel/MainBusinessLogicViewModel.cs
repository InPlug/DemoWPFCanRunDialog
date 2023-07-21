using System;
using System.Windows.Input;
using System.Windows.Threading;
using System.Windows;
using NetEti.MVVMini;
using System.Threading;
using System.Threading.Tasks;
using Model;
using DemoWPFCanRunDialog.Model;

namespace DemoWPFCanRunDialog.ViewModel
{
    /// <summary>
    /// ViewModel für die Geschäftslogik.
    /// </summary>
    /// <remarks>
    /// File: MainBusinessLogicViewModel.cs
    /// Autor: Erik Nagel
    ///
    /// 31.05.2015 Erik Nagel: erstellt
    /// </remarks>
    public class MainBusinessLogicViewModel : ObservableObject, IMinimumDialogServer
    {
        #region public members

        #region IMinimumDialogServer Implementation

        /// <summary>
        /// Schließt die Ui mit einer Verzögerung von millisecondsDelay.
        /// </summary>
        /// <param name="millisecondsDelay">Verzögerung in Millisekunden vor Schließen der Ui.</param>
        /// <param name="dialogResult">DialogResult (True oder False).</param>
        public void WaitAndClose(int millisecondsDelay, bool dialogResult)
        {
            this._canHandleCmdBreak = false;
            if (this._uIMain != null && this._uIMain is Window && !((Window)this._uIMain).DialogResult.HasValue)
            {
                CommandManager.InvalidateRequerySuggested();
                new TaskFactory().StartNew(new Action(() =>
                {
                    Thread.Sleep(millisecondsDelay);
                    if (this.Dispatcher.CheckAccess())
                        ((Window)this._uIMain).DialogResult = true;
                    else
                        this.Dispatcher.Invoke(DispatcherPriority.Normal,
                            new ThreadStart(new Action(() => { ((Window)this._uIMain).DialogResult = dialogResult; })));
                }));
            }
        }

        #endregion IMinimumDialogServer Implementation

        #region published members

        /// <summary>
        /// Id des Aufrufenden Knotens im LogicalTaskTree.
        /// </summary>
        public string StartNodeQuestion
        {
            get
            {
                return String.Format("Knoten {0} starten?", this._root.CallingNodeId);
            }
        }

        /// <summary>
        /// Id des Aufrufenden Knotens im LogicalTaskTree.
        /// </summary>
        public string CallingNodeId
        {
            get
            {
                return this._root.CallingNodeId;
            }
            set
            {
                this.RaisePropertyChanged("CallingNodeId");
                this.RaisePropertyChanged("StartNodeQuestion");
            }
        }

        /// <summary>
        /// Command für den CmdTrue-Button in der MainBusinessLogic.
        /// </summary>
        public ICommand? CmdOk { get { return this._cmdOkMainBusinessLogicRelayCommand; } }

        /// <summary>
        /// Command für den Break-Button im der MainBusinessLogic.
        /// </summary>
        public ICommand? CmdBreak { get { return this._cmdBreakMainBusinessLogicRelayCommand; } }

        #endregion published members

        /// <summary>
        /// Konstruktor
        /// </summary>
        public MainBusinessLogicViewModel(MainBusinessLogic root, FrameworkElement uiMain)
        {
            this._root = root;
            this._uIMain = uiMain;
            this._root.DialogServer = this;
            this._canHandleCmdBreak = true;
            if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            {
                this._uIDispatcher = this._uIMain.Dispatcher;
            }
            this._cmdOkMainBusinessLogicRelayCommand = new RelayCommand(CmdOkMainBusinessLogicExecute, canCmdOkMainBusinessLogicExecute);
            this._cmdBreakMainBusinessLogicRelayCommand = new RelayCommand(CmdBreakMainBusinessLogicExecute, CanCmdBreakMainBusinessLogicExecute);

            this._root.StateChanged -= this.mainBusinessLogicStateChanged;
            this._root.StateChanged += this.mainBusinessLogicStateChanged;

        }

        #endregion public members

        #region private members

        private MainBusinessLogic _root;
        private RelayCommand? _cmdOkMainBusinessLogicRelayCommand;
        private RelayCommand? _cmdBreakMainBusinessLogicRelayCommand;
        private FrameworkElement? _uIMain { get; set; }
        private bool _canHandleCmdBreak;
        private System.Windows.Threading.Dispatcher? _uIDispatcher { get; set; }

        private void mainBusinessLogicStateChanged(object? sender, State state)
        {
            this.RaisePropertyChanged("CallingNodeId");
            // Die Buttons müssen zum Update gezwungen werden, da die Verarbeitung in einem
            // anderen Thread läuft:
            this._cmdOkMainBusinessLogicRelayCommand?.UpdateCanExecuteState(this.Dispatcher);
            this._cmdBreakMainBusinessLogicRelayCommand?.UpdateCanExecuteState(this.Dispatcher);
        }

        private void CmdOkMainBusinessLogicExecute(object? parameter)
        {
            this._root.HandleCmdOk();
        }

        private bool canCmdOkMainBusinessLogicExecute()
        {
            return this._root.CanHandleCmdOk();
        }

        private void CmdBreakMainBusinessLogicExecute(object? parameter)
        {
            this._root.HandleCmdBreak();
        }

        private bool CanCmdBreakMainBusinessLogicExecute()
        {
            return this._canHandleCmdBreak && this._root.CanHandleCmdBreak();
        }

        #endregion private members

    }
}
