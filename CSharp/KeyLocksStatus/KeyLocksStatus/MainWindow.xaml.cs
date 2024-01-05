using System;
using System.ComponentModel;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;

namespace KeyLocksStatus
{



    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// identified the keys whose state will be indicated.
        /// </summary>
        private enum EKeys
        {
            eCaps,
            eNum,
            eScroll,
            eUnknown
        };

        /// <summary>
        /// Defines the possible states for the keys
        /// </summary>
        private enum ELockState
        {
            eOn,
            eOff,
            eUnknown
        }

        // The interval (in ms) between checks of the key state.
        private readonly int SleepInterval = 500;
        // Define the brushes that indicate the lock states.
        private static readonly System.Windows.Media.SolidColorBrush[] Colours = { Brushes.Green, Brushes.Red, Brushes.Gray };
        // The labels that will be used as indicators.
        private static readonly Label[] Indicators = new Label[GetEnumSize<EKeys>()];
        // Background worker thread that will update the UI peridically.
        private readonly BackgroundWorker _backgroundWorker = new BackgroundWorker();


        public MainWindow()
        {
            InitializeComponent();
            Indicators[(int)EKeys.eCaps] = capsLock;
            Indicators[(int)EKeys.eNum] = numLock;
            Indicators[(int)EKeys.eScroll] = scrollLock;
            Indicators[(int)EKeys.eUnknown] = null;
            // Set up the Background Worker Events 
            _backgroundWorker.DoWork += _backgroundWorker_DoWork;
            _backgroundWorker.RunWorkerCompleted += _backgroundWorker_RunWorkerCompleted;
            _backgroundWorker.RunWorkerAsync();            // Run the Background Worker
            Loaded += new RoutedEventHandler(Window_Loaded);
        }

        /// <summary>
        /// Get the number of items in an enum definition.
        /// </summary>
        /// <typeparam name="EType">The type holding the enum</typeparam>
        /// <returns>The number of items in the enum.</returns>
        static int GetEnumSize<EType>()
        {
            return Enum.GetValues(typeof(EType)).Length;
        }

        /// <summary>
        /// When the window ha loaded reposition it to the bottom right corner.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Rect desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
            Left = desktopWorkingArea.Right - Width;
            Top = desktopWorkingArea.Bottom - Height;
            Topmost = true;
        }

        /// <summary>
        /// The background worker thread
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            bool bKeepRunning = true;
            while (bKeepRunning)
            {
                if (e.Cancel)
                {
                    bKeepRunning = false;
                }
                else
                {
                    Thread.Sleep(SleepInterval);
                    _ = Dispatcher.Invoke(DispatcherPriority.Normal, new Action<EKeys>(UpdateButtonState), EKeys.eCaps);
                    _ = Dispatcher.Invoke(DispatcherPriority.Normal, new Action<EKeys>(UpdateButtonState), EKeys.eNum);
                    _ = Dispatcher.Invoke(DispatcherPriority.Normal, new Action<EKeys>(UpdateButtonState), EKeys.eScroll);
                }
            }
        }

        /// <summary>
        /// Called when the background thread completes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void _backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Do nothing.
        }

        /// <summary>
        /// Update the associated indicator with the button's current state
        /// </summary>
        /// <param name="button">The indeicator to update</param>
        private void UpdateButtonState(EKeys button)
        {
            Label indicator = Indicators[(int)button];
            if (indicator != null)
            {
                indicator.Background = Colours[(int)GetKeyState(button)];
            }
        }


        /// <summary>
        /// Get the lock state of specific keys.
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        private ELockState GetKeyState(EKeys key)
        {
            ELockState result = ELockState.eUnknown;


            System.Windows.Application.Current.Dispatcher.Invoke(delegate
            {
                switch (key)
                {
                    case EKeys.eCaps:
                        result = Keyboard.IsKeyToggled(Key.CapsLock) ? ELockState.eOn : ELockState.eOff;
                        break;
                    case EKeys.eNum:
                        result = Keyboard.IsKeyToggled(Key.NumLock) ? ELockState.eOn : ELockState.eOff;
                        break;
                    case EKeys.eScroll:
                        result = Keyboard.IsKeyToggled(Key.Scroll) ? ELockState.eOn : ELockState.eOff;
                        break;
                    default:
                        result = ELockState.eUnknown;
                        break;
                }
            });
            return result;
        }
    }

}
