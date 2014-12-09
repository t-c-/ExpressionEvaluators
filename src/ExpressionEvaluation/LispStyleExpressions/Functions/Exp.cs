using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LispStyleExpressions;

namespace LispStyleExpressions.Functions {
    class Exp : LispStyleFunction {

        public Exp(LispStyleExpressionEvaluator lang) : base(lang) { }


        public override string key() {
            return "exp";
        }

        public override FunctionType type() {
            return FunctionType.Function;
        }

        public override float eval(string[] args) {

            //only 1 arg
            argumentCheck(args.Length, 1, ArgumentRestriction.MustEqual);

            float exp = lang.Evaluate(args[0]);

            return (float)Math.Exp(exp);

        }//end eval


    }
}
