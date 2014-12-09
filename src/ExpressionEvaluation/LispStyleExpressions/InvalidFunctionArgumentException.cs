using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LispStyleExpressions {
   public class InvalidFunctionArgumentException : System.Exception {

       private LispStyleFunction _function;

       public InvalidFunctionArgumentException(string mssg, LispStyleFunction function) : base(mssg) {
           _function = function;

       }

       /// <summary>
       /// Override message
       /// </summary>
       public override string Message {
           get {
               return "Invalid Number of Arguments in : " + _function.key() + " :: " + base.Message;
           }
       }

    }//end class
}
