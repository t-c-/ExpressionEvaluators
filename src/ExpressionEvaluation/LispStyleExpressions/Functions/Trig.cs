using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LispStyleExpressions;


namespace LispStyleExpressions.Functions {

    class Sin : LispStyleFunction {

        public Sin(LispStyleExpressionEvaluator lang) : base(lang) { }


        public override string key() {
            return "sin";
        }

        public override FunctionType type() {
            return FunctionType.Function;
        }

        public override float eval(string[] args) {

            //only one argument
            argumentCheck(args.Length, 1, ArgumentRestriction.MustEqual);

            float theta = lang.Evaluate(args[0]);

            return (float)Math.Sin(theta);

        }//end eval

    }//end class


    class Cos : LispStyleFunction {

        public Cos(LispStyleExpressionEvaluator lang) : base(lang) { }


        public override string key() {
            return "cos";
        }

        public override FunctionType type() {
            return FunctionType.Function;
        }


        public override float eval(string[] args) {

            //only one argument
            argumentCheck(args.Length, 1, ArgumentRestriction.MustEqual);

            float theta = lang.Evaluate(args[0]);

            return (float)Math.Cos(theta);

        }//end eval


    }//end class 


    class Tan : LispStyleFunction {

        public Tan(LispStyleExpressionEvaluator lang) : base(lang) { }


        public override string key() {
            return "tan";
        }

        public override FunctionType type() {
            return FunctionType.Function;
        }

        public override float eval(string[] args) {

            //only one argument
            argumentCheck(args.Length, 1, ArgumentRestriction.MustEqual);

            float theta = lang.Evaluate(args[0]);

            return (float)Math.Tan(theta);

        }//end eval

    }//end class

    class Asin :LispStyleFunction {
        //pass to base class
        public Asin(LispStyleExpressionEvaluator lang) : base(lang) { }

        public override  string key() {
            return "asin";
        }

        public override FunctionType type() {
            return FunctionType.Function;
        }

        public override float eval(string[] args) {

            //only one argument
            argumentCheck(args.Length, 1, ArgumentRestriction.MustEqual);

            return (float)Math.Asin(lang.Evaluate(args[0]));
        }

    }//end class

    class Acos : LispStyleFunction {
        //pass to base class
        public Acos(LispStyleExpressionEvaluator lang) : base(lang) { }

        public override string key() {
            return "acos";
        }

        public override FunctionType type() {
            return FunctionType.Function;
        }

        public override float eval(string[] args) {

            //only one argument
            argumentCheck(args.Length, 1, ArgumentRestriction.MustEqual);

            return (float)Math.Acos(lang.Evaluate(args[0]));
        }

    }//end class


    class Atan : LispStyleFunction {
        //pass to base class
        public Atan(LispStyleExpressionEvaluator lang) : base(lang) { }

        public override string key() {
            return "atan";
        }

        public override FunctionType type() {
            return FunctionType.Function;
        }

        public override float eval(string[] args) {

            //only one argument
            argumentCheck(args.Length, 1, ArgumentRestriction.MustEqual);

            return (float)Math.Atan(lang.Evaluate(args[0]));
        }

    }//end class


    class Atan2 : LispStyleFunction {
        //pass to base class
        public Atan2(LispStyleExpressionEvaluator lang) : base(lang) { }

        public override string key() {
            return "atan2";
        }

        public override FunctionType type() {
            return FunctionType.Function;
        }

        public override float eval(string[] args) {

            //two arguments
            argumentCheck(args.Length, 2, ArgumentRestriction.MustEqual);

            float a = lang.Evaluate(args[0]);
            float b = lang.Evaluate(args[1]);

            return (float)Math.Atan2(a, b);
        }

    }//end class

}//end namespace
