using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LispStyleExpressions;

namespace LispStyleExpressions.Functions {
    /// <summary>
    /// Degrees to Radians
    /// Takes Degree input and converts to radians.
    /// </summary>
    class Rad : LispStyleFunction {

        //pass to base class
        public Rad(LispStyleExpressionEvaluator lang) : base(lang) { }

        public override string key() {
            return "rad";
        }

        public override FunctionType type() {
            return FunctionType.Function;
        }

        public override float eval(string[] args) {

            //only 1 arg
            argumentCheck(args.Length, 1, ArgumentRestriction.MustEqual);

            float degree = lang.Evaluate(args[0]);

            float radian = (float)Math.PI * (degree / 180);

            return radian;
        }


    }
}
//(defun DTR (d)
//  (* pi (/ d 180.0))
//)