using System;
using System.Collections.Generic;
using System.Text;

namespace Delegates
{
    public class UsingDelegates
    {
        // This is the delegate type 'MyDelegate'
        public delegate void MyDelegate(string message);

        // This is the method that will be delegated to from 'MyDelegate'
        public static void DelegateMethod(string message)
        {
            Console.WriteLine(message);
        }

        public static void DelegateMethod2(string message)
        {
            Console.WriteLine(message.ToUpper());
        }

        public static void MethodWithCallback(int num1, int num2, MyDelegate callback)
        {
            callback($"The number is: {num1 + num2}");
        }
    }
}
