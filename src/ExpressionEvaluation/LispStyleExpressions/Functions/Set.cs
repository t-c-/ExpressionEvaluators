using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LispStyleExpressions;

namespace LispStyleExpressions.Functions {
    class Set : LispStyleFunction  {


        public Set(LispStyleExpressionEvaluator lang) : base(lang) { }



        public override string key() {
            return "set";
        }

        public override FunctionType type() {
            return FunctionType.Assignment;
        }

        public override float eval(string[] args) {

            //need an even amount of args (var value var value ...)
            argumentCheck(args.Length, 2, ArgumentRestriction.SetsOf);

            int var = 0;
            int val = 1;
            string varName ="";
            float varValue = float.NaN;


            while (val < args.Length) {

                varName = args[var].Trim();
                varValue = lang.Evaluate(args[val]);

                lang.setVariable(varName, varValue);

                var += 2;
                val += 2;

            }//end while

            return varValue;
        }//end eval

    }//end class

}
