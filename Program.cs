using System;

namespace Delegates
{
    class Program
    {
        static void Main(string[] args)
        {
            // Delegate handler to call a method
            UsingDelegates.MyDelegate myDelegateHandler = UsingDelegates.DelegateMethod;
            myDelegateHandler("Hello World");
            UsingDelegates.MethodWithCallback(20, 30, myDelegateHandler);

            // Using a single delegate to call other delegates to call multiple methods (multicasting)
            UsingDelegates.MyDelegate myDelegateHandler2 = UsingDelegates.DelegateMethod2;
            UsingDelegates.MyDelegate myGroupedDelegateHandler = myDelegateHandler + myDelegateHandler2;
            myGroupedDelegateHandler("Hello Bob");

            // Removing a delegate from the grouped delegate handler
            myGroupedDelegateHandler -= myDelegateHandler;
            myGroupedDelegateHandler("Hello Fred");
        }
    }
}
