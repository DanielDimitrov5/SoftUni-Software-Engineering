using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings : Stack<string>
    {
        public bool IsEmpty()
        {
            if (this.Any())
            {
                return false; 
            }

            return true;
        }

        public void AddRange(Stack<string> stack)
        {
            while (stack.Any())
            {
                 this.Push(stack.Pop());
            }
        }
    }
}
