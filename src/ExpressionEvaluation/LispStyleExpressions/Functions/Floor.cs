using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LispStyleExpressions;

namespace LispStyleExpressions.Functions {
    class Floor : LispStyleFunction {

        //pass to base class
        public Floor(LispStyleExpressionEvaluator lang) : base(lang) { }

        public override string key() {
            return "floor";
        }

        public override FunctionType type() {
            return FunctionType.Function;
        }

        public override float eval(string[] args) {


            //only 1 arg
            argumentCheck(args.Length, 1, ArgumentRestriction.MustEqual);

            float floorVal = lang.Evaluate(args[0]);

            float floor = (float)Math.Floor(floorVal);

            return floor;

        }
    }
}
