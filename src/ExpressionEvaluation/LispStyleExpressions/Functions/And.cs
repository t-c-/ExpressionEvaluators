using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LispStyleExpressions;


namespace LispStyleExpressions.Functions {
    class And  : LispStyleFunction {


        //pass to base class
        public And(LispStyleExpressionEvaluator lang) : base(lang) { }


        public override string key() {
            return "and";
        }

        public override FunctionType type() {
            return FunctionType.Logical;
        }

        public override float eval(string[] args) {

            //only 2 arguments
            argumentCheck(args.Length, 2, ArgumentRestriction.MustEqual);
            //if (args.Length != 2) {
            //    throw new Exception("Invalid number of arguments in " + key());
            //}


            //grab args
            float a = lang.Evaluate(args[0]);
            float b = lang.Evaluate(args[1]);

            if (a == 1 && b == 1) {
                return 1;
            } else {
                return 0;
            } 

        }//end eval 

    }
}
