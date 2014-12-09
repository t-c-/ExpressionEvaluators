using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LispStyleExpressions;

namespace LispStyleExpressions.Functions {

    class Log : LispStyleFunction {

        public Log(LispStyleExpressionEvaluator lang) : base(lang) { }


        public override string key() {
            return "log";
        }


        public override FunctionType type() {
            return FunctionType.Function;
        }


        public override float eval(string[] args) {

            int arg_len = args.Length;
            //minimum 1 arg
            argumentCheck(arg_len, 1, ArgumentRestriction.Minimum);

            //maximum 2 args
            argumentCheck(arg_len, 2, ArgumentRestriction.Maximum);

            float log = float.NaN;

            if (arg_len == 1) {

                log = lang.Evaluate(args[0]);
                log = (float)Math.Log(log);

            } else if (arg_len == 2) {

                float a = lang.Evaluate(args[0]);
                float b = lang.Evaluate(args[1]);
                log = (float)Math.Log(a, b);

            } 

            return log;

        }//end eval

    }//end class

    class Log10 : LispStyleFunction {

        public Log10(LispStyleExpressionEvaluator lang) : base(lang) { }


        public override string key() {
            return "log10";
        }

        public override FunctionType type() {
            return FunctionType.Function;
        }

        public override float eval(string[] args) {

            //only 1 arg
            argumentCheck(args.Length, 1, ArgumentRestriction.MustEqual);

            float log = lang.Evaluate(args[0]);

            return (float)Math.Log10(log);

        }//end eval

    }//end class

}
