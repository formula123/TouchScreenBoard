using System;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Input;

namespace TouchScreenBoard
{
    public class TouchScreenKeypad : Window
    {
        #region Property & Variable & Constructor
        private static double _WidthTouchKeypad = 300;

        private static double _heightTouchKeypad = 300;

        public static double HeightTouchKeyboard
        {
            get { return _heightTouchKeypad; }
            set { _heightTouchKeypad = value; }
        }

        public static double WidthTouchKeyboard
        {
            get { return _WidthTouchKeypad; }
            set { _WidthTouchKeypad = value; }

        }

        private static Window _InstanceObject;

        private static Brush _PreviousTextBoxBackgroundBrush = null;
        private static Brush _PreviousTextBoxBorderBrush = null;
        private static Thickness _PreviousTextBoxBorderThickness;

        private static Control _CurrentControl;
        public static string TouchScreenText
        {
            get
            {
                if (_CurrentControl is TextBox)
                {
                    return ((TextBox)_CurrentControl).Text;
                }
                else if (_CurrentControl is PasswordBox)
                {
                    return ((PasswordBox)_CurrentControl).Password;
                }
                else return "";


            }
            set
            {
                if (_CurrentControl is TextBox)
                {
                    ((TextBox)_CurrentControl).Text = value;
                }
                else if (_CurrentControl is PasswordBox)
                {
                    ((PasswordBox)_CurrentControl).Password = value;
                }


            }

        }

        public static RoutedUICommand Cmd1 = new RoutedUICommand();
        public static RoutedUICommand Cmd2 = new RoutedUICommand();
        public static RoutedUICommand Cmd3 = new RoutedUICommand();
        public static RoutedUICommand Cmd4 = new RoutedUICommand();
        public static RoutedUICommand Cmd5 = new RoutedUICommand();
        public static RoutedUICommand Cmd6 = new RoutedUICommand();
        public static RoutedUICommand Cmd7 = new RoutedUICommand();
        public static RoutedUICommand Cmd8 = new RoutedUICommand();
        public static RoutedUICommand Cmd9 = new RoutedUICommand();
        public static RoutedUICommand Cmd0 = new RoutedUICommand();
        public static RoutedUICommand CmdDot = new RoutedUICommand();
        public static RoutedUICommand CmdBackspace = new RoutedUICommand();


        public static RoutedUICommand CmdEnter = new RoutedUICommand();

        public static RoutedUICommand CmdClear = new RoutedUICommand();
        public static RoutedUICommand CmdClose = new RoutedUICommand();



        public TouchScreenKeypad()
        {
            Width = WidthTouchKeyboard;
            Height = HeightTouchKeyboard;
        }

        static TouchScreenKeypad()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TouchScreenKeypad), new FrameworkPropertyMetadata(typeof(TouchScreenKeypad)));

            SetCommandBinding();
        }
        #endregion
        #region CommandRelatedCode
        private static void SetCommandBinding()
        {
            CommandBinding Cb1 = new CommandBinding(Cmd1, RunCommand);
            CommandBinding Cb2 = new CommandBinding(Cmd2, RunCommand);
            CommandBinding Cb3 = new CommandBinding(Cmd3, RunCommand);
            CommandBinding Cb4 = new CommandBinding(Cmd4, RunCommand);
            CommandBinding Cb5 = new CommandBinding(Cmd5, RunCommand);
            CommandBinding Cb6 = new CommandBinding(Cmd6, RunCommand);
            CommandBinding Cb7 = new CommandBinding(Cmd7, RunCommand);
            CommandBinding Cb8 = new CommandBinding(Cmd8, RunCommand);
            CommandBinding Cb9 = new CommandBinding(Cmd9, RunCommand);
            CommandBinding Cb0 = new CommandBinding(Cmd0, RunCommand);
            CommandBinding CbDot = new CommandBinding(CmdDot, RunCommand);
            CommandBinding CbBackspace = new CommandBinding(CmdBackspace, RunCommand);


            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeypad), Cb1);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeypad), Cb2);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeypad), Cb3);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeypad), Cb4);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeypad), Cb5);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeypad), Cb6);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeypad), Cb7);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeypad), Cb8);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeypad), Cb9);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeypad), Cb0);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeypad), CbDot);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeypad), CbBackspace);


            CommandBinding CbEnter = new CommandBinding(CmdEnter, RunCommand);

            CommandBinding CbClear = new CommandBinding(CmdClear, RunCommand);
            CommandBinding CbClose = new CommandBinding(CmdClose, RunCommand);

            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeypad), CbEnter);

            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeypad), CbClear);
            CommandManager.RegisterClassCommandBinding(typeof(TouchScreenKeypad), CbClose);
        }
        static void RunCommand(object sender, ExecutedRoutedEventArgs e)
        {
            if (e.Command == Cmd1)
            {
                TouchScreenKeypad.TouchScreenText += "1";
            }
            else if (e.Command == Cmd2)
            {
                TouchScreenKeypad.TouchScreenText += "2";

            }
            else if (e.Command == Cmd3)
            {
                    TouchScreenKeypad.TouchScreenText += "3";

            }
            else if (e.Command == Cmd4)
            {
                    TouchScreenKeypad.TouchScreenText += "4";
            }
            else if (e.Command == Cmd5)
            {
                    TouchScreenKeypad.TouchScreenText += "5";
            }
            else if (e.Command == Cmd6)
            {
                    TouchScreenKeypad.TouchScreenText += "6";
            }
            else if (e.Command == Cmd7)
            {
                    TouchScreenKeypad.TouchScreenText += "7";
            }
            else if (e.Command == Cmd8)
            {
                    TouchScreenKeypad.TouchScreenText += "8";
            }
            else if (e.Command == Cmd9)
            {
                    TouchScreenKeypad.TouchScreenText += "9";
            }
            else if (e.Command == Cmd0)
            {
                    TouchScreenKeypad.TouchScreenText += "0";
            }
            else if (e.Command == CmdDot)
            {
                TouchScreenText += ".";
            }
            else if (e.Command == CmdBackspace)
            {
                if (!string.IsNullOrEmpty(TouchScreenKeypad.TouchScreenText))
                {
                    TouchScreenKeypad.TouchScreenText = TouchScreenKeypad.TouchScreenText.Substring(0, TouchScreenKeypad.TouchScreenText.Length - 1);
                }

            }
            else if (e.Command == CmdEnter)
            {
                if (_InstanceObject != null)
                {
                    _InstanceObject.Close();
                    _InstanceObject = null;
                }
                _CurrentControl.MoveFocus(new TraversalRequest(FocusNavigationDirection.Next));
                //System.Windows.Input.Keyboard.ClearFocus();

            }
            else if (e.Command == CmdClear)//Last row
            {
                TouchScreenKeypad.TouchScreenText = "";
            }
            else if (e.Command == CmdClose)
            {
                OnLostFocus(_CurrentControl, null);
            }
        }
        #endregion
        #region Main Functionality

        private static void syncchild()
        {
            if (_CurrentControl != null && _InstanceObject != null)
            {

                Point virtualpoint = new Point(0, _CurrentControl.ActualHeight + 3);
                Point Actualpoint = _CurrentControl.PointToScreen(virtualpoint);

                if (WidthTouchKeyboard + Actualpoint.X > SystemParameters.VirtualScreenWidth)
                {
                    double difference = WidthTouchKeyboard + Actualpoint.X - SystemParameters.VirtualScreenWidth;
                    _InstanceObject.Left = Actualpoint.X - difference;
                }
                else if (!(Actualpoint.X > 1))
                {
                    _InstanceObject.Left = 1;
                }
                else
                {
                    _InstanceObject.Left = Actualpoint.X;
                }

                if(HeightTouchKeyboard + Actualpoint.Y > SystemParameters.VirtualScreenHeight)
                {
                    _InstanceObject.Top = _CurrentControl.PointToScreen(new Point(0, 0)).Y - HeightTouchKeyboard - 3;
                }
                else
                {
                    _InstanceObject.Top = Actualpoint.Y;
                }

                _InstanceObject.Show();
            }


        }

        public static bool GetTouchScreenKeypad(DependencyObject obj)
        {
            return (bool)obj.GetValue(TouchScreenKeypadProperty);
        }

        public static void SetTouchScreenKeypad(DependencyObject obj, bool value)
        {
            obj.SetValue(TouchScreenKeypadProperty, value);
        }

        public static readonly DependencyProperty TouchScreenKeypadProperty =
            DependencyProperty.RegisterAttached("TouchScreenKeypad", typeof(bool), typeof(TouchScreenKeypad), new UIPropertyMetadata(default(bool), TouchScreenKeypadPropertyChanged));

        static void TouchScreenKeypadPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            FrameworkElement host = sender as FrameworkElement;
            if (host != null)
            {
                host.GotFocus += new RoutedEventHandler(OnGotFocus);
                host.LostFocus += new RoutedEventHandler(OnLostFocus);
            }

        }



        static void OnGotFocus(object sender, RoutedEventArgs e)
        {
            Control host = sender as Control;

            //_PreviousTextBoxBackgroundBrush = host.Background;
            _PreviousTextBoxBorderBrush = host.BorderBrush;
            _PreviousTextBoxBorderThickness = host.BorderThickness;

            //host.Background = Brushes.Cyan;
            host.BorderBrush = Brushes.Blue;
            host.BorderThickness = new Thickness(4);


            _CurrentControl = host;

            if (_InstanceObject == null)
            {
                FrameworkElement ct = host;
                while (ct != null)
                {
                    if (ct is Window)
                    {
                        ((Window)ct).LocationChanged += new EventHandler(TouchScreenKeypad_LocationChanged);
                        ((Window)ct).Activated += new EventHandler(TouchScreenKeypad_Activated);
                        ((Window)ct).Deactivated += new EventHandler(TouchScreenKeypad_Deactivated);
                        break;
                    }
                    ct = (FrameworkElement)ct.Parent;
                }

                if(ct == null)
                {
                    host.GotFocus += new RoutedEventHandler(TouchScreenKeypad_Activated);
                    host.LostFocus += new RoutedEventHandler(TouchScreenKeypad_Deactivated);
                }

                _InstanceObject = new TouchScreenKeypad();
                _InstanceObject.AllowsTransparency = true;
                _InstanceObject.WindowStyle = WindowStyle.None;
                _InstanceObject.ShowInTaskbar = false;
                _InstanceObject.Topmost = true;

                host.LayoutUpdated += new EventHandler(tb_LayoutUpdated);
            }



        }

        static void TouchScreenKeypad_Deactivated(object sender, EventArgs e)
        {
            if (_InstanceObject != null)
            {
                _InstanceObject.Topmost = false;
            }
        }
        static void TouchScreenKeypad_Deactivated(object sender, RoutedEventArgs e)
        {
            if(_InstanceObject != null)
            {
                _InstanceObject.Topmost = false;
            }
        }

        static void TouchScreenKeypad_Activated(object sender, EventArgs e)
        {
            if (_InstanceObject != null)
            {
                _InstanceObject.Topmost = true;
            }
        }

        static void TouchScreenKeypad_Activated(object sender, RoutedEventArgs e)
        {
            if(_InstanceObject != null)
            {
                _InstanceObject.Topmost = true;
            }
        }


        static void TouchScreenKeypad_LocationChanged(object sender, EventArgs e)
        {
            syncchild();
        }

        static void tb_LayoutUpdated(object sender, EventArgs e)
        {
            syncchild();
        }

        static void OnLostFocus(object sender, RoutedEventArgs e)
        {

            Control host = sender as Control;
            //host.Background = _PreviousTextBoxBackgroundBrush;
            host.BorderBrush = _PreviousTextBoxBorderBrush;
            host.BorderThickness = _PreviousTextBoxBorderThickness;

            if (_InstanceObject != null)
            {
                _InstanceObject.Close();
                _InstanceObject = null;
            }
        }
    }
}
#endregion
