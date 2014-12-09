using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using LispStyleExpressions;


namespace LispStyleExpressions.Functions {
    class Not : LispStyleFunction {

        //pass to base class
        public Not(LispStyleExpressionEvaluator lang) : base(lang) { }


        public override string key() {
            return "not";
        }

        public override FunctionType type() {
            return FunctionType.Logical;
        }

        public override float eval(string[] args) {


            //only 1 arg
            argumentCheck(args.Length, 1, ArgumentRestriction.MustEqual);


            //grab args
            float a = lang.Evaluate(args[0]);

            if (a == 1) {
                return 0;
            } else if (a == 0) {
                return 1;
            } else {
                throw new Exception("Invlaid bit in logic:" + a);
            }

        }//end eval  



    }
}
