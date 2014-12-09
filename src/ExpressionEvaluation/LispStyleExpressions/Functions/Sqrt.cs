using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LispStyleExpressions;

namespace LispStyleExpressions.Functions {
    class Sqrt : LispStyleFunction {

        public Sqrt(LispStyleExpressionEvaluator lang) : base(lang) { }


        public override string key() {
            return "sqrt";
        }

        public override FunctionType type() {
            return FunctionType.Function;
        }

        public override float eval(string[] args) {


            //only one argument
            argumentCheck(args.Length, 1, ArgumentRestriction.MustEqual);

            float a = lang.Evaluate(args[0]);

            return (float) Math.Sqrt(a);

        }//end eval

    }
}
