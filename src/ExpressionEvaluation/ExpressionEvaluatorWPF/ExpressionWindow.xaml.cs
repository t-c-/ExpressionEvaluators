using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;


using CStyleExpressions;
using LispStyleExpressions;

namespace ExpressionEvaluatorWPFTest {

    public enum ExpressionStyle {
        C,
        Lisp
    }
    /// <summary>
    /// Interaction logic for TestWindow.xaml
    /// </summary>
    public partial class ExpressionEvalUI : Window {

        private CStyleExpressionEvaluator _c_eval;
        private LispStyleExpressionEvaluator _l_eval;

        private ExpressionStyle _style;
        private float _last_result;


        private InputTracker _input_tracker;

        private Point _last_resize_point;

        public ExpressionEvalUI() {
            InitializeComponent();

            _last_resize_point = new Point(0, 0);

            _style = ExpressionStyle.C;
            _last_result = float.NaN;


            _c_eval = new CStyleExpressionEvaluator();
            _l_eval = new LispStyleExpressionEvaluator();

            _input_tracker = new InputTracker();

            PrintIntro();
            PrintEvaluator();
        }


        private void PrintIntro() {

            HistoryBox.Text += Environment.NewLine;
            HistoryBox.Text += "\t'C' & 'Lisp' Style Expression Evaluators" + Environment.NewLine;
            HistoryBox.Text += "\tDeveloped by Tom C. 2011~2014, MIT License" + Environment.NewLine + Environment.NewLine;

            HistoryBox.Text += "Menu <Right Click> to show" + Environment.NewLine;


            HistoryBox.Text += "Use <Tab> for expression input" + Environment.NewLine;

        }


        /// <summary>
        /// Print the Evaluator in use
        /// </summary>
        private void PrintEvaluator() {

            //historyBox.Text += Environment.NewLine;
            //historyBox.Text += ":: ";

            switch (_style) {

                case ExpressionStyle.C:

                    HistoryBox.Text += ">: Using 'C' Style Expressions." + Environment.NewLine;
                    break;

                case ExpressionStyle.Lisp:

                    HistoryBox.Text += ">: Using 'Lisp' Style Expressions." + Environment.NewLine;
                    break;

            }//end switch


        }



        private void CloseButton_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void StyleButton_Click(object sender, RoutedEventArgs e) {

            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;

            return;

        }

        private void ExpressionBox_KeyUp(object sender, KeyEventArgs e) {

            //System.Diagnostics.Debug.Print("key up=" + e.KeyCode);

            string hQuestion = "";
            string hResult = "";
            float result;

            if (e.Key == Key.Enter) {

                string text = ExpressionBox.Text;

                if (text != String.Empty) {

                    try {

                        hQuestion = text;

                        if (_style == ExpressionStyle.C) {

                            result = _c_eval.Evaluate(text);

                        } else {

                            result = _l_eval.Evaluate(text);

                        }//end if/else

                        //result = (float)Math.Round(result, 6);

                        hResult = result.ToString();

                        _last_result = result;
                        //no error - print result
                        //resultBox.Text = hResult;


                    } catch (Exception ex) {

                        hResult = "Error: " + ex.Message;

                    }

                    //add input to tracker
                    _input_tracker.AddInput(hQuestion);


                    //record question & result or response on error
                    HistoryBox.Text += "?: " + hQuestion + Environment.NewLine;
                    HistoryBox.Text += "=: " + hResult + Environment.NewLine;


                    HistoryBox.SelectionStart = HistoryBox.Text.Length;

                    int lc = HistoryBox.LineCount;
                    if (lc > 0) {
                        HistoryBox.ScrollToLine(lc - 1);
                    }

                    ExpressionBox.Text = "";

                }//end if string empty



            }//end if key code enter

            if (e.Key == Key.Up) {

                string input_str = _input_tracker.NextUp;

                if (!String.IsNullOrEmpty(input_str)) {
                    ExpressionBox.Text = input_str;
                }



            } else if (e.Key == Key.Down) {

                string input_str = _input_tracker.NextDown;

                if (!String.IsNullOrEmpty(input_str)) {
                    ExpressionBox.Text = input_str;
                }
 

            } else if (e.Key == Key.Escape) {
                ExpressionBox.Text = "";
            }

        }//end ExpressionBox_KeyUp



        private void movePolygon_MouseEnter(object sender, MouseEventArgs e) {
            this.Cursor = Cursors.SizeAll;
        }

        private void movePolygon_MouseLeave(object sender, MouseEventArgs e) {
            this.Cursor = Cursors.Arrow;
        }

        private void movePolygon_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.LeftButton == MouseButtonState.Pressed) {
                DragMove();
            }
        }

        private void EditButton_Click(object sender, RoutedEventArgs e) {

            (sender as Button).ContextMenu.IsEnabled = true;
            (sender as Button).ContextMenu.PlacementTarget = (sender as Button);
            (sender as Button).ContextMenu.Placement = System.Windows.Controls.Primitives.PlacementMode.Bottom;
            (sender as Button).ContextMenu.IsOpen = true;

            return;

        }

        #region "Menu Click Handlers"

        private void CloseMenuItem_Click(object sender, RoutedEventArgs e) {

            this.Close();

        }

        private void UseCStyleMenuItem_Click(object sender, RoutedEventArgs e) {
            _style = ExpressionStyle.C;
            PrintEvaluator();
        }

        private void UseLispStyleMenuItem_Click(object sender, RoutedEventArgs e) {
            _style = ExpressionStyle.Lisp;
            PrintEvaluator();

        }


        

        private void CopyMenuItem_Click(object sender, RoutedEventArgs e) {

            string text = HistoryBox.SelectedText;
            if (!String.IsNullOrEmpty(text)) {
                System.Windows.Clipboard.SetText(text);
            }


        }

        private void CopyResultMenuItem_Click(object sender, RoutedEventArgs e) {
            System.Windows.Clipboard.SetText(_last_result.ToString());
        }

        private void CopyHistoryMenuItem_Click(object sender, RoutedEventArgs e) {
            System.Windows.Clipboard.SetText(HistoryBox.Text);
        }

        private void PasteMenuItem_Click(object sender, RoutedEventArgs e) {

            if (System.Windows.Clipboard.ContainsText(TextDataFormat.Text)) {

                string text = System.Windows.Clipboard.GetText(TextDataFormat.Text);

                if (text.IndexOf(Environment.NewLine) == -1) {

                    int pos = ExpressionBox.SelectionStart;
                    int len = text.Length;
                    string new_text = ExpressionBox.Text;

                    new_text = new_text.Insert(pos, text);

                    ExpressionBox.Text = new_text;
                    ExpressionBox.SelectionStart = pos + len;

                }

            }


        }


        #endregion



        private void FormClose_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }

        private void FormMinimize_Click(object sender, RoutedEventArgs e) {
            this.WindowState = System.Windows.WindowState.Minimized;
        }



        private void ClearHistoryMenuItem_Click(object sender, RoutedEventArgs e) {
            HistoryBox.Text = "";
        }

        private void PrintInfoMenuItem_Click(object sender, RoutedEventArgs e) {

            switch (_style) {

                case ExpressionStyle.C:

                    HistoryBox.Text += _c_eval.ToString();

                    break;

                case ExpressionStyle.Lisp:

                    HistoryBox.Text += _l_eval.ToString();

                    break;

            }//end switch



        }

        private void HistoryBox_TextChanged(object sender, TextChangedEventArgs e) {
            HistoryBox.ScrollToEnd();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            ExpressionBox.Focus();
        }


    }//end class
}
