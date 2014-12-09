using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;



using CStyleExpressions;
using LispStyleExpressions;



namespace ExpressionEvaluation {

    public enum ExpressionStyle {
        C,
        Lisp
    }


    public partial class ExpressionConsole : Form {

        private CStyleExpressionEvaluator _c_eval;
        private LispStyleExpressionEvaluator _l_eval;
        private ExpressionStyle _style;

        private float _last_result;

        private int _last_input_index;
        private List<string> _last_input_list;

        private InputTracker _input_tracker;

        System.Drawing.Color _bg_color;
        System.Drawing.Color _fg_color;

        private const string FORM_TITLE = "Expression Evaluator Console";

        public ExpressionConsole() {
            InitializeComponent();

            _c_eval = new CStyleExpressionEvaluator();
            _l_eval = new LispStyleExpressionEvaluator();


            _style = ExpressionStyle.C;

            _last_result = float.NaN;

            _input_tracker = new InputTracker();


            //black
            //_bg_color = System.Drawing.Color.Black; // System.Drawing.Color.FromArgb(20, 20, 20);

            //jet gray
            _bg_color = System.Drawing.Color.FromArgb(20, 20, 43);

            //white
            _fg_color = System.Drawing.Color.WhiteSmoke;

            this.BackColor = _bg_color;

            historyBox.BackColor = _bg_color;
            historyBox.ForeColor = _fg_color;

            expressionBox.BackColor = _bg_color;
            expressionBox.ForeColor = _fg_color;


            PrintIntro();
            PrintEvaluator();


        }

        private void PrintIntro() {

            historyBox.Text +=  Environment.NewLine;
            historyBox.Text += "\t'C' & 'Lisp' Style Expression Evaluators" + Environment.NewLine;
            historyBox.Text += "\tDeveloped by Tom C. 2011~2014, MIT License" + Environment.NewLine + Environment.NewLine;

            historyBox.Text += "Use <F1> to print evaluator information (language dump)" + Environment.NewLine;
            historyBox.Text += "Use <F2> for 'C' format." + Environment.NewLine;
            historyBox.Text += "Use <F3> for 'Lisp' format." + Environment.NewLine;

            historyBox.Text += "Use <Tab> for expression input" + Environment.NewLine;

            historyBox.SelectionStart = historyBox.Text.Length - 1;
            historyBox.ScrollToCaret();

        }


        /// <summary>
        /// Print the Evaluator in use
        /// </summary>
        private void PrintEvaluator() {

            //historyBox.Text += Environment.NewLine;
            //historyBox.Text += ":: ";

            switch (_style) {

                case ExpressionStyle.C :

                    historyBox.Text += ">: Using 'C' Style Expressions." + Environment.NewLine;
                    this.Text = FORM_TITLE + " : 'C' Style Mode";
                    break;

                case ExpressionStyle.Lisp:

                    historyBox.Text += ">: Using 'Lisp' Style Expressions." + Environment.NewLine;
                    this.Text = FORM_TITLE + " : 'Lisp' Style Mode";
                    break;

            }//end switch

            //historyBox.Text += Environment.NewLine;
            //scroll to end
            historyBox.SelectionStart = historyBox.Text.Length - 1;
            historyBox.ScrollToCaret();


        }


        private void ExpressionConsole_Shown(object sender, EventArgs e) {

            expressionBox.Focus();

        }


        /// <summary>
        /// KeyUp Event handler for hitting "Enter" in expressionBox (Input text Box)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void expressionBox_KeyUp(object sender, KeyEventArgs e) {

            //System.Diagnostics.Debug.Print("key up=" + e.KeyCode);

            string hQuestion = "";
            string hResult = "";
            float result;

            if (e.KeyCode == Keys.Enter) {

                string text = expressionBox.Text;

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

                        //add input on success
                        //_last_input_list.Add(hQuestion);
                        //_last_input_index += 1;
                        //checkLastInputIndex();

                    } catch (Exception ex) {

                        hResult = "Error: " + ex.Message;

                    }


                    //add input to tracker
                    _input_tracker.AddInput(hQuestion);

                    //record question & result or response on error
                    historyBox.Text += "?: " + hQuestion + Environment.NewLine;
                    historyBox.Text += "=: " + hResult + Environment.NewLine;


                    historyBox.SelectionStart = historyBox.Text.Length;
                    historyBox.ScrollToCaret();

                    expressionBox.Text = "";

                }//end if string empty



            }//end if key code enter

            if (e.KeyCode == Keys.Up) {

                string input_str = _input_tracker.NextUp;

                if (!String.IsNullOrEmpty(input_str)) {
                    expressionBox.Text = input_str;
                }

            } else if (e.KeyCode == Keys.Down) {

                string input_str = _input_tracker.NextDown;

                if (!String.IsNullOrEmpty(input_str)) {
                    expressionBox.Text = input_str;
                }

            } else if (e.KeyCode == Keys.Escape) {
                expressionBox.Text = "";
            }


        }//end expressionBox_KeyUp


        private void expressionBox_KeyDown(object sender, KeyEventArgs e) {

            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Escape) {
                e.SuppressKeyPress = true;
            }

        }

        //chack the last input index for cycling through input strings
        private void checkLastInputIndex() {

            int input_cnt = _last_input_list.Count;
            //check number of inputs
            if (input_cnt == 0) {
                _last_input_index = -1;
            } else {
                //check for range on index
                if (_last_input_index < 0) {
                    _last_input_index = 0;
                } else if ( _last_input_index > input_cnt - 1) {
                    _last_input_index = input_cnt - 1;
                }

            }

        }// end checkLastInputIndex



#region "Menu Items"
        /// <summary>
        /// Print the Langauge Summary
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void printExpressionInformationToolStripMenuItem_Click(object sender, EventArgs e) {


            switch (_style) {

                case ExpressionStyle.C:

                    historyBox.Text += _c_eval.ToString();

                    break;

                case ExpressionStyle.Lisp:

                    historyBox.Text += _l_eval.ToString();

                    break;

            }//end switch

            historyBox.SelectionStart = historyBox.Text.Length;
            historyBox.ScrollToCaret();

        }

        private void useCStyleExpressionsToolStripMenuItem_Click(object sender, EventArgs e) {
            _style = ExpressionStyle.C;
            
            PrintEvaluator();

        }

        private void useLispStyleExpressionsToolStripMenuItem_Click(object sender, EventArgs e) {
            _style = ExpressionStyle.Lisp;
            
            PrintEvaluator();
        }

        private void copyResultToolStripMenuItem_Click(object sender, EventArgs e) {
            System.Windows.Forms.Clipboard.SetText(_last_result.ToString());
        }

        private void copyHistoryToolStripMenuItem_Click(object sender, EventArgs e) {
            System.Windows.Forms.Clipboard.SetText(historyBox.Text);
        }

        private void pasteExpressionToolStripMenuItem_Click(object sender, EventArgs e) {

            if (System.Windows.Forms.Clipboard.ContainsText( TextDataFormat.Text)) {

                string text = System.Windows.Forms.Clipboard.GetText( TextDataFormat.Text);

                if (text.IndexOf(Environment.NewLine) == -1) {

                    int pos = expressionBox.SelectionStart;
                    int len = text.Length;
                    string new_text = expressionBox.Text;

                    new_text = new_text.Insert(pos, text);

                    expressionBox.Text = new_text;
                    expressionBox.SelectionStart = pos + len ;

                }

            }


        }

        private void expressionBox_Leave(object sender, EventArgs e) {
            //expressionBox.BorderStyle = BorderStyle.None;
            expressionBox.BackColor = _bg_color;
        }

        private void expressionBox_Enter(object sender, EventArgs e) {
            //expressionBox.BorderStyle = BorderStyle.FixedSingle;
            expressionBox.BackColor = Color.FromArgb(20, 20, 20);
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();

        }

        private void clearHistoryToolStripMenuItem_Click(object sender, EventArgs e) {
            historyBox.Text = "";
            expressionBox.Focus();
        }//end print





#endregion


    }//end class
}
