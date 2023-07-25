Things I learnt on Day5

Day 5 - S1
----------

to delegate - means to assign

Delegates
Delegates in .Net allow you to call functions

They allow you to call a function indirectly (using a delegates)

The better option is to call a function is directly but sometimes its not possible therfore you can use delegates

Delegates are used in
- Event handling
- Used to write Asynchronous Code
- which function to call is decided at runtime


Delegates are function pointers


----------------------------------------
Delegates is actually a class
and it is a reference type

----------------------------------------

Action, Func, Predicate are in-built Delegate functions that are used for create common delegate classes


Action: Delegate with Return Type: void and Parameters: 0-16
Func: Delegate with Return Type: Any and Parameters: 0-16
Predicate: Delegate with Return Type: bool and Parameters: 1

----------------------------------------

Anonymous Methods
Methods without a name and we call it using Delegates

---
Lambda
A lambda is also an anonymous function but in a more concised
The syntax is more compact (much shorter) than an anonymous




Day5 S2
--------
Exception Handling & Event Handling

Remember here the information needs to pass from the developer to the user and then to the end user

Developer -> User -> End User

How the developer informs the user 
This can be done in 2 ways
1. In a critical way (Here the user is forced to take action)
Here the developer 'throws an Exception'
And the user will try to catch the exception, incase caught it will be handled else the program will crash

2. In the non-critical way (Here the user is just notified that something has happened but will not force them to take action)
This is 'raising an Event'



NullReferenceException
FormatException
DivideByZeroException



All these inherit from the Exception Class either directly or indirectly

			        Exception

System Exception			Application Exception

All .Net exceptions inherit from       These are used for all non .Net exceptions (Here this is used to create your own exceptions)
system exception


Arithmetic Exception

DivideByZeroException


Finally is used to close all connections incase the program crashes




What is the actual advantage to inherit from application exception than exception?
Since this is a more specific exception


-------------------------------
Events are a non-critical way of informing the user that an exception has occured
Here you don't force the user to take an action
