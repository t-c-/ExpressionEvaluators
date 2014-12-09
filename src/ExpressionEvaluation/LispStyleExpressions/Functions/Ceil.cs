using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LispStyleExpressions;

namespace LispStyleExpressions.Functions {
    class Ceil : LispStyleFunction {

         //pass to base class
        public Ceil(LispStyleExpressionEvaluator lang) : base(lang) { }


        public override string key() {
            return "ceil";
        }

        public override FunctionType type() {
            return FunctionType.Function;
        }

        public override float eval(string[] args) {

            //only one argument
            argumentCheck(args.Length, 1, ArgumentRestriction.MustEqual);

            float ceilVal = lang.Evaluate(args[0]);

            float ceil = (float)Math.Ceiling(ceilVal);

            return ceil;

        }

    }
}
