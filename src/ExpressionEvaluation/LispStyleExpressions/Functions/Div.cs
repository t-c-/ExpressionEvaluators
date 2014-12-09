using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using LispStyleExpressions;

namespace LispStyleExpressions.Functions {
    class Div  : LispStyleFunction {


    public Div(LispStyleExpressionEvaluator lang) : base(lang) { }

    public override string key() {
        return "/";
    }

    public override FunctionType type() {
        return FunctionType.MultiplicitiveOperator;
    }

        /// <summary>
        /// Divide, Allows division of arbitrary number of arguments
        /// </summary>
        /// <param name="args"></param>
        /// <returns></returns>
    public override float eval(string[] args) {

        //minimum tow arguments
        argumentCheck(args.Length, 2, ArgumentRestriction.Minimum);

        //grab first arguement
        float a = lang.Evaluate(args[0]);

        //divide each subsequent argument
        for (int i = 1; i < args.Length; i++) {
            float b = lang.Evaluate(args[i]);

            if (b == 0) { throw new Exception("Divide by zero."); }

            a /= b;
        }

        return a;
        

    }//end eval



    }
}
