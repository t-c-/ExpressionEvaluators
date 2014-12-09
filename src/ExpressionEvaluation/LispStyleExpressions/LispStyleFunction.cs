using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LispStyleExpressions {

    public enum ArgumentRestriction {
        Minimum,
        Maximum,
        MustEqual,
        SetsOf,
        None
    }

    public enum FunctionType {
        Null,
        Assignment,
        AdditiveOperator,
        MultiplicitiveOperator,
        Function,
        Logical

    }

    public class LispStyleFunction {

        protected LispStyleExpressionEvaluator lang;

        protected LispStyleFunction(LispStyleExpressionEvaluator lang) {

            this.lang = lang;

        }//end constructor

 
        public virtual string key() {
            return "_function_base_class";
        }

        public virtual FunctionType type() {
            return FunctionType.Null;
        }


        /// <summary>
        /// Evaluate the function with the passed arguements
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
         public virtual float eval(string[] args) {
            return 0;
        }//end eval


        /// <summary>
        /// Internal Argument Check each derived function can use for consistancy.
        /// Throws Exception on fail.
        /// </summary>
        /// <param name="n_args">Number of passed arguments</param>
        /// <param name="n_check">Required number of arguments or -1 when uasing no restriction</param>
        /// <param name="restriction">Number requirement: Minimum, Maximum, None</param>
         public void argumentCheck(int n_args, int n_check, ArgumentRestriction restriction) {

  
             switch (restriction) {

                 case ArgumentRestriction.Maximum:

                     if (n_args > n_check) {
                         throw new InvalidFunctionArgumentException("Expecting " + n_check + " arguments maximum", this);
                     }


                     break;

                 case ArgumentRestriction.Minimum:

                     if (n_args < n_check) {
                         throw new InvalidFunctionArgumentException("Expecting " + n_check + " arguments minimum", this);
                     }

                     break;

                 case ArgumentRestriction.MustEqual:

                     if (n_args != n_check) {
                         throw new InvalidFunctionArgumentException("Expecting " + n_check + " arguments only", this);
                     }

                     break;

                 case ArgumentRestriction.SetsOf:

                     if (n_args % n_check != 0) {
                         throw new InvalidFunctionArgumentException("Expecting one or more sets of " +  n_check + " arguments", this);
                     }

                     break;

                 case ArgumentRestriction.None:
                     //default:

                     break;

             }//end switch


             //return passes;

         }


         public override string ToString() {
             return key() + " :: " + type().ToString();
         }

    }//end class

}
