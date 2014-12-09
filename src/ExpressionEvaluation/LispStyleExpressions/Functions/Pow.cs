using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LispStyleExpressions;

namespace LispStyleExpressions.Functions {
    class Pow : LispStyleFunction  {


        public Pow(LispStyleExpressionEvaluator lang) : base(lang) { }

        public override string key() {
            return "pow";
        }

        public override FunctionType type() {
            return FunctionType.Function;
        }


        public override float eval(string[] args) {


            //only 2 args
            argumentCheck(args.Length, 2, ArgumentRestriction.MustEqual);

            float a = lang.Evaluate(args[0]);
            float b = lang.Evaluate(args[1]);

            return (float) Math.Pow(a, b);

        }//end eval
        

    }
}
