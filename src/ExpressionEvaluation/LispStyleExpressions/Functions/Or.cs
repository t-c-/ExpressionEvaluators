using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using LispStyleExpressions;

namespace LispStyleExpressions.Functions {
    class Or : LispStyleFunction {


        //pass to base class
        public Or(LispStyleExpressionEvaluator lang) : base(lang) { }


        public override string key() {
            return "or";
        }

        public override FunctionType type() {
            return FunctionType.Logical;
        }

        public override float eval(string[] args) {


            //only 2 args
            argumentCheck(args.Length, 2, ArgumentRestriction.MustEqual);


            //grab args
            float a = lang.Evaluate(args[0]);
            float b = lang.Evaluate(args[1]);

            if (a != 0 && a != 1) {
                throw new Exception("Invlaid bit in logic:" + a);
            }

            if (b != 0 && b != 1) {
                throw new Exception("Invlaid bit in logic:" + b);
            }

            if (a == 1 || b == 1) {
                return 1;
            } else {
                return 0;
            } 

        }//end eval 


    }
}
