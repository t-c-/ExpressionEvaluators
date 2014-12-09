using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LispStyleExpressions;

namespace LispStyleExpressions.Functions {
    /// <summary>
    /// Radians to Degrees
    /// Takes Radian input and converts to degrees.
    /// </summary>
    class Deg : LispStyleFunction {


        //pass to base class
        public Deg(LispStyleExpressionEvaluator lang) : base(lang) { }

        public override string key() {
            return "deg";
        }

        public override FunctionType type() {
            return FunctionType.Function;
        }

        public override float eval(string[] args) {

            //only 1 argument
            argumentCheck(args.Length, 1, ArgumentRestriction.MustEqual);

            float radian = lang.Evaluate(args[0]);

            float degree = 180 * (radian / (float)Math.PI);

            return degree;
        }    

    }
}

//(defun RTD (r)
//  (* 180.0 (/ r pi))

//)