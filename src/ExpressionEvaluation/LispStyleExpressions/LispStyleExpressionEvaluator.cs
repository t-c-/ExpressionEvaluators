using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Text.RegularExpressions;

using LispStyleExpressions.Functions;

namespace LispStyleExpressions {


    public class LispStyleExpressionEvaluator {

   
        private Dictionary<string, float> _variables;
        private Dictionary<string, LispStyleFunction> _functions;


        private Regex varNamePattern;
        private bool verbose;

        /// <summary>
        /// Basic constructor.
        /// </summary>
        public LispStyleExpressionEvaluator() {

            verbose = false;

            _variables = new Dictionary<string,float>();
            _functions = new Dictionary<string, LispStyleFunction>();


            //allow only alpha names - no numbers or special symbols
            varNamePattern = new Regex("^[a-zA-Z]+[0-9]*$");


            //define pi
            setVariable("pi", (float)Math.PI);

            //define half pi
            setVariable("hpi", (float)(Math.PI * 0.5));

            //define quarter pi
            setVariable("qpi", (float)(Math.PI * 0.25));

            //define tau ( 2 pi)
            setVariable("tau", (float)Math.PI * 2);

            //define e
            setVariable("e", (float)Math.E);

            //define golden ratio
            setVariable("phi", (float) ((1 + Math.Sqrt(5)) / 2));

            

            //load functions
            loadFunctions();

        }//end constructor

        /// <summary>
        /// Property to turn on debugging info to console.
        /// </summary>
        public bool Verbose {

            set {
                verbose = value;
            }//end set
            get {
                return verbose;
            }

        }//end verbose property



        /// <summary>
        /// Evaluate a string expression.
        /// </summary>
        /// <param name="code">String to evaluate.</param>
        /// <returns>Evaluted value of expression</returns>
        public float Evaluate(string code) {

            float result = float.NaN;

            //trim the string
            code = code.Trim();


           
            //search for opening and closing parantheses
            int op, cp;
            op = code.IndexOf('(');
            cp = code.LastIndexOf(')');

            //if it is contained within parantheses - treat as function
            if (op != -1 && cp != -1) {

                //grab innner string: ( ... ) 
                string inner = code.Substring(op + 1, cp - op - 1);

                //feedback
                if (verbose) {
                   // Console.WriteLine("Inner= " + inner);
                }//end if verbose

                //parse the string into chunks 
                string[] codeChunks = chunks(inner);


                if (codeChunks.Length == 0) {
                    throw new Exception("Empty function set: " + code);
                }


                //function name is first index
                string funcName = codeChunks[0];
                //LispStyleFunction f = null;

                //define array for arguments
                //copy of input array without function name
                string[] fArgs = new string[codeChunks.Length - 1];

                //copy arguments to new array
                Array.ConstrainedCopy(codeChunks, 1, fArgs, 0, codeChunks.Length -1);

                //check to see if it is functions
                if (_functions.ContainsKey(funcName)) {

                    LispStyleFunction f = _functions[funcName];

                    result = f.eval(fArgs);

                    try {
  
                        //send args to command
                       // result = f.eval(fArgs);
                        

                    } catch (Exception ex) {
                        //pass upwards - arguments checked internally to function
                        throw ex;
                        //old way before argument checking
                        //throw new Exception("Error in function: " + funcName + " : " + ex.Message);

                    }//end try/catch


                } else {

                    throw new Exception("Unknown Function: " + funcName);

                }//end if is in functions


            //no parantheses
            } else if (op == -1 && cp == -1) {

                //try to evaluate as number....
                try {

                    float temp = float.Parse(code);
                     result = temp;

                } catch  {

                    //got an error on parse
                    //see if it is a variable
                    if (_variables.ContainsKey(code)) {
                        float temp = _variables[code];
                        result =  temp;
                    } else {
                        throw new Exception("Undeclared variable: " + code);
                    }//end if else


                }//end try/catch



            } else {

                if (op == -1) {
                    throw new Exception("Missing Left Paranetheses.");
                }
                if (cp == -1) {
                    throw new Exception("Missing Right Paranetheses.");
                }


            }//end else if

            return result;


        }//end eval



        /// <summary>
        /// Checks to to see if variable name is valid
        /// Allow only alpha chars
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public bool IsValidName(string name) {

            return varNamePattern.IsMatch(name);

        }

        //wrapper to set variable with expression
        //used by define : a : 1 in file spec

        /// <summary>
        /// Set a variable in the language to the evaluation of a string expression.
        /// Expression nust be a single valid function.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="expression"></param>
        public void setVariable(string name, string expression) {

            float expressionValue = Evaluate(expression);
            setVariable(name, expressionValue);

        }


        /// <summary>
        /// Set a variable in the language to a value (float). 
        /// </summary>
        /// <param name="name">Name of variable to set</param>
        /// <param name="varValue">Value of variable</param>
        public void setVariable(string name, float varValue) {


            if (!IsValidName(name)) {
                throw new Exception("Invalid Variable Name:" + name);
            }

            //make sure no overlap
            if (_functions.ContainsKey(name)) {
                throw new Exception("Invalid variable name: " + name + ". Variable cannot have same name as Function");
            }

            //check to see if variable is defined
            if (_variables.ContainsKey(name)) {
                _variables.Remove(name);
            }
            //add variable to dictionary
            _variables.Add(name, varValue);


        }//end setVariable


        /// <summary>
        /// Check if variable is defined.
        /// </summary>
        /// <param name="name">Name of variable.</param>
        /// <returns>True if variable is defined in language, False if undefined.</returns>
        public bool IsVariableDefined(string name) {

            return _variables.Keys.Contains(name);


        }

        /// <summary>
        /// Get the value of a variable.
        /// 
        /// </summary>
        /// <param name="name">Name of variable to query.</param>
        /// <returns>Value of the variable.</returns>
        public float VariableValue(string name) {

            float a = float.NaN;

            a = _variables[name];

            return a;

        }




        /// <summary>
        /// Tokenize string into argument parts.
        /// </summary>
        /// <param name="code">String the tokenize.</param>
        /// <returns>Array of tokens.</returns>
        public static string[] chunks(string code) {

            string curChunk = "";
            List<string> parts = new List<string>();

            code = code.Trim();


            for (int i = 0; i < code.Length; i++) {

                char curChar = code[i];

                //if opening parentheses encountered
                //gobble string up until closing is found
                if (curChar == '(') {
                    int closeMark = -1;
                    int pMatch = 0;
                    for (int c = i + 1; c < code.Length; c++) {

                        char ch = code[c];

                        if (ch == '(') {
                            pMatch += 1;
                        } else if (ch == ')' && pMatch != 0) {
                            pMatch -= 1;

                        } else if (ch == ')' && pMatch == 0) {
                            closeMark = c;
                            break;
                        }


                    }//end for

                    if (closeMark == -1) {
                        throw new Exception("Missing Right Parentheses.");
                    } else if (pMatch < 0) {
                        throw new Exception("Extra Left Parentheses.");
                    } else {
                        string tmpChunk = code.Substring(i, closeMark - i + 1);
                        //see if there is a current part
                        if (!curChunk.Equals("")) {

                            parts.Add(curChunk);
                        }
                        curChunk = "";
                        parts.Add(tmpChunk);
                        i = closeMark;

                    }//end if/else closing
                } else if (curChar == ' ') {

                    //hit deliminator
                    if (!curChunk.Equals("")) {
                        parts.Add(curChunk);
                        curChunk = "";
                    }


                } else {
                    //add char to string....
                    curChunk += curChar;
                }//end if opening parentheses

            }//end for

            //post check
            if (!curChunk.Equals("")) {
                parts.Add(curChunk);
            }


            return parts.ToArray<string>();


        }//end chuncks

        /// <summary>
        /// Load the functions into the language.
        /// </summary>
        private void loadFunctions() {

            // ========== variable setting  ========== 

            //set variable (set <symbol> a <symbol> b ...)
            registerFunction(new Set(this));


            // ========== basic math operators  ========== 


            //addition (+ a b ...)
            registerFunction(new Add(this));

            //addition (- a b ...)
            registerFunction(new Sub(this));

            //multiplication (* a b ...)
            registerFunction(new Mult(this));

            //division (/ a b ...)
            registerFunction(new Div(this));



            // ========== other basic functions  ========== 

            //power (pow a b)
            registerFunction(new Pow(this));

            //square root (sqrt a)
            registerFunction(new Sqrt(this));

            //modulo (mod a b)
            registerFunction(new Mod(this));

            //ceiling (ceil a b)
            registerFunction(new Ceil(this));

            //floor (floor a b)
            registerFunction(new Floor(this));

            //exp (exp p)
            registerFunction(new Exp(this));


            // ========== trig functions  ========== 


            //sin (sin a)
            registerFunction(new Sin(this));

            //cos (cos a)
            registerFunction(new Cos(this));

            //tan (tan a)
            registerFunction(new Tan(this));

            //asin (asin a)
            registerFunction(new Asin(this));

            //acos (acos a)
            registerFunction(new Acos(this));

            //atan (atan2 a)
            registerFunction(new Atan(this));

            //atan2 (atan2 y x)
            registerFunction(new Atan2(this));


            // ==========     log     ========== 

            //log (log a)
            registerFunction(new Log(this));

            //log10 (log10 a)
            registerFunction(new Log10(this));

            // ========== angle conversion functions  ========== 


            //radians to degrees (deg rad)
            registerFunction(new Deg(this));

            //degrees to radians (rad deg)
            registerFunction(new Rad(this));



            // ========== utility functions  ========== 


            //random number (rn) = [0 to 1] or (rn min max)
            registerFunction(new Rand(this));



            // ========== logic functions  ========== 



            //equals test (= a b)
            registerFunction(new Equals(this));

            //greater than test (> a b)
            registerFunction(new Greater(this));

            //lesser than test (< a b)
            registerFunction(new Lesser(this));

            //greater or equal to test (>= a b)
            registerFunction(new GreaterEq(this));

            //lesser or equal to test (<= a b)
            registerFunction(new LesserEq(this));

            //not (not a)
            registerFunction(new Not(this));

            //and (and a)
            registerFunction(new And(this));

            //or (or a)
            registerFunction(new Or(this));

        }//end load functions


        /// <summary>
        /// Stub function for easy adding functions.
        /// </summary>
        /// <param name="f">Function to register.</param>
        private void registerFunction(LispStyleFunction f) {

            _functions.Add(f.key(), f);
        }//end registerFunction


        /// <summary>
        /// Prints the functions and variables defined in the language.
        /// </summary>
        /// <returns></returns>
        public override string ToString() {


            string stringVal = "##### 'Lisp' Style Expressions #####" + Environment.NewLine;


            stringVal += header("functions") + Environment.NewLine;

            foreach (KeyValuePair<string,LispStyleFunction> f in _functions) {

                LispStyleFunction funct = f.Value;
                stringVal += funct.ToString() + Environment.NewLine;
                //stringVal += f.Key + Environment.NewLine;
            }//end foreach

            stringVal += header("variables") +Environment.NewLine;

            foreach (KeyValuePair<string, float> v in _variables) {

                stringVal += v.Key.ToString() + " = " + v.Value.ToString() + Environment.NewLine;
            }//end foreach
            
            return stringVal;
        }


        private string header(string title) {
            return "______ " + title + " ______";
        }


    }//end class






}//end namespace
