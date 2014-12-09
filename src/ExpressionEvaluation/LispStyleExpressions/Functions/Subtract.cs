using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LispStyleExpressions;

namespace LispStyleExpressions.Functions {
    class Sub : LispStyleFunction {

       public Sub(LispStyleExpressionEvaluator lang) : base(lang) { }

        public override  string key() {
            return "-";
        }

        public override FunctionType type() {
            return FunctionType.AdditiveOperator;
        }

        public override float eval(string[] args) {

            //at least two arguments - allow multiple
            argumentCheck(args.Length, 2, ArgumentRestriction.Minimum);

            //grab first arguement
            float a = lang.Evaluate(args[0]);

            //subtract each subsequent argument
            for (int i = 1; i < args.Length; i++) {
                float b = lang.Evaluate(args[i]);
                a -= b;
            }

            return a;

        }//end eval


    }
}
