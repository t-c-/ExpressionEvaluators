using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LispStyleExpressions;

namespace LispStyleExpressions.Functions {
    class Equals : LispStyleFunction {

        //pass to base class
        public Equals(LispStyleExpressionEvaluator lang) : base(lang) { }


        public override string key() {
            return "eq";
        }

        public override FunctionType type() {
            return FunctionType.Logical;
        }

        public override float eval(string[] args) {

            //only 2 arguments
            argumentCheck(args.Length, 2, ArgumentRestriction.MustEqual);

            //grab args
            float a = lang.Evaluate(args[0]);
            float b = lang.Evaluate(args[1]);

            if (a == b) {
                return 1;
            } else {
                return 0;
            }

        }//end eval        


    }
}
