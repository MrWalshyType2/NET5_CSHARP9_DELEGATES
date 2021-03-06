# Delegates
A delegate is a type representing a reference to a method with a specific parameter list and return type.
When a delegate is instantiated, it can be associated with any method with a compatible signature and return type. The method
can then be called/invoked from the delegate.

A delegate is used to pass methods as arguments to other methods. An event handler is a method that is invoked through a delegate.

Delegates can be declared with the `delegate` keyword:
```
public delegate int PerformCalculation(int x, int y);
```

## Overview
- Delegates are similar to C++ function pointers except delegates are fully OOP and point to member functions instead. Delegates
encapsulate an object instance and a method.
- Allow method parameters.
- Can be used to define callback methods.
- Supports method chaining.
- Anonymous methods and lambda expressions (in specific contexts) are compiled to delegate types, together known as *anonymous functions*.
- Delegates are derived from the `Delegate` class in .NET.
- Delegate types are `sealed`.

## Using Delegates
Create a delegate object with the name of the method to be wrapped or an anonymous function. Once instantiated, method calls to the delegate
will be passed to the wrapped method; this includes arguments provided to the delegate, return values from the wrapped method are returned
via the delegate.

A delegate can also be used as an argument to a method parameter, this is as simple as listing the type and name as usual for writing the method signature.
The delegate is an abstraction as it does not need to make console calls itself in the example shown, this is deferred to the callback delegate.

- Delegates can also call more than one method, a technique called *multicasting*. 
- Add methods the delegates invocation list with either the addition or addition-assignment operators. 
- Remove methods from the invocation list with either the subtraction or subtraction-assignment operators.
- If a delegate uses reference parameters, each multicasted method will receive the reference parameter in turn with all changes visible to the next method.
- If any method throws an exception that is not caught, the exception is passed to the delegates caller and no subsequent methods in the invocation list are called.
- If the delegate returns a value and/or `out` parameters, it returns the value and parameters of the last method invoked.

The `System.Delegate` base class gives some methods and properties that are callable by its derived delegates. Finding the number of
methods in a delegate's invocation list for example:
```
int invocationCount = delegateHandler.GetInvocationList().GetLength(0);
```

Delegates with multiple methods are derived from `MulticastDelegate`, a subclass of `System.Delegate`, and are often used in event handling.
- An event source object sends notifications to recipient objects that have registered to receive that event.
- Registering for an event requires the recipient to create method to handle the event, and a delegate for that method which is passed to the event source.
- The delegate can call the event handling method on the recipient, delivering event data.

Delegates of two different types being compared at compile-time will cause a compilation error; statically available `Delegate` instances can
be compared, but will return false.
### Example
See UsingDelegates.cs

## How to declare, instantiate and use Delegates
From C# 1.0 and onwards, delegates can be declared like so:
```
{
	// Create and instantiate the delegate
	delegate void MyDelegate(string str);
	MyDelegate myDelegate = new MyDelegate(Notify);
}

// Method with same signature as the delegate 'MyDelegate'
static void Notify(string name) { ... };
```

A simpler way of declaring delegate instances was introduced in C# 2.0:
```
MyDelegate myDelegate = Notify;
```

### Declare and initialise with an Anonymous Method or Lambda expression
C# 2.0 brought the power of anonymous-method delegates:
```
MyDelegate myDelegate = delegate(string name)
{
	Console.WriteLine("Notification received for " + name);
}
```

C# 3.0 brought delegates the power of lambda expressions:
```
MyDelegate myDelegate = name => { Console.WriteLine("Notification received for " + name); };
```
