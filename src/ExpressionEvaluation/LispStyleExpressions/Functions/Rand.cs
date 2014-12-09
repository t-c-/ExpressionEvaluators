using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LispStyleExpressions;

namespace LispStyleExpressions.Functions {
    class Rand : LispStyleFunction {

        private Random _random;

        public Rand(LispStyleExpressionEvaluator lang) : base(lang) {
            _random = new Random();
        }

        public override string key() {
            return "rand";
        }

        public override FunctionType type() {
            return FunctionType.Function;
        }

        public override float eval(string[] args) {

            //0 or two args (min, max)
            if (args.Length !=0) {
                //only 2 args if not 0
                argumentCheck(args.Length, 2, ArgumentRestriction.MustEqual);
            }


            float rand = (float)_random.NextDouble();

            if (args.Length == 2) {
                float min = lang.Evaluate(args[0]);
                float max = lang.Evaluate(args[1]);
                float q = (float)_random.NextDouble();
                rand = min + q * (max - min);
            }


            return rand;

        }//end eval


    }
}
