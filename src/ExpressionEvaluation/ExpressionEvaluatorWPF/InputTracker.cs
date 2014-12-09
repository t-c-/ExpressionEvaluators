using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ExpressionEvaluatorWPFTest {

    /// <summary>
    /// Input Tracker Class for recording input and being able to recall it (normally using the up/down keys).
    /// Designed to match up/down arrow keys feature of common OS Command Line windows
    /// </summary>
    public class InputTracker {

        private int _index;
        private List<string> _last_input_list;

        public InputTracker() {

            _index = -1;
            _last_input_list= new List<string>();


        }


        /// <summary>
        /// Walk up Input List Stack
        /// </summary>
        public string NextUp {
            get {

                string input = String.Empty;
                int list_cnt = _last_input_list.Count;

                //nothing in list to return
                if (list_cnt == 0) {
                    return input;
                }

                //validate index
                IncrementAndCheckIndex(true);

                input = _last_input_list[_index];


                return input;

            }
        }//end next up

        /// <summary>
        /// Walk down Input List Stack
        /// </summary>
        public string NextDown {
            get {

                string input = String.Empty;
                int list_cnt = _last_input_list.Count;


                //nothing in list to return
                if (list_cnt == 0) {
                    return input;
                }

                //validate index
                IncrementAndCheckIndex(false);

                input = _last_input_list[_index];

                return input;


            }
        }//end next down

        /// <summary>
        /// Check to internal index for initialization and bounds
        /// </summary>
        /// <param name="up"></param>
        private void IncrementAndCheckIndex(bool up) {

            int list_cnt = _last_input_list.Count;

            if (_index == -1) {

                //on non-intialized go to last item
                _index = list_cnt - 1;

            } else {
                //intialized - increment
                //direction
                _index = up ? _index - 1 : _index + 1;

                if (_index < 0) {
                    _index = 0;
                }

                if (_index >= list_cnt) {

                    _index = list_cnt - 1;
                }

            }//end if/else intialized

        }//end CheckIndex

        /// <summary>
        /// Adds an iput line tothe tracker
        /// </summary>
        /// <param name="line"></param>
        public void AddInput(string line) {

            _last_input_list.Add(line);

        }


        /// <summary>
        /// Clear all recorded inputs.
        /// </summary>
        public void ClearInput() {

            _last_input_list.Clear();
            _index = -1;
        }

        /// <summary>
        /// reset the Stack List Index
        /// </summary>
        public void ResetIndex() {
            _index = -1;
        }

    }//end class
}
