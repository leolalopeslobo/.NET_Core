namespace EventHandling1
{
    internal class Program
    {
        static void Main0()
        {
            //User Part
            Class1 objClass1 = new Class1();

            //making the event point to the delegate reference (event)
            //make InvalidP1 delegate reference (event) defined in Class1 refer to our function objClass1_InvalidP1
            objClass1.InvalidP1 += objClass1_InvalidP1;   //+= for Multicast Delegates
            objClass1.P1 = 10; //event won't occur
            objClass1.P1 = 101; //event will occur
        }


        static void Main1()
        {
            //Simpler way than Main0

            Class1 objClass2 = new Class1();
            objClass2.InvalidP1 += objClass1_InvalidP1;  //+= adds a handler
            objClass2.InvalidP1 += Handler2;
            //object.event += delegate reference


            //code to fire off the event
            objClass2.P1 = 102;

            Console.WriteLine();
            objClass2.InvalidP1 -= Handler2;
            objClass2.P1 = 102;
        }

                static void objClass1_InvalidP1()  //ObjectName_EventName()
        {
            Console.WriteLine("InvalidP1 event raised - eventhandlingcode here");
        }

        private static void Handler2()
        {
            Console.WriteLine("Handler 2");
        }
    }

    //The delegate signature must match the signature as the event handling function
    //If event was X
    //Then delegate is X_eventHandler
    //for an event handler delegate the return type is always void
    //you can have events with parameters or without

    //step1: Create a delegate class having the same signature
    //as the event handling function
    public delegate void InvalidP1EventHandler(); //all events generally return void

    //Developer Part
    public class Class1
    {
        //step2: declare the event of the delegate type
        //event is a delegate reference
        public event InvalidP1EventHandler? InvalidP1;
        private int p1;

        public int P1
        {
            get { return p1; }
            set
            {
                if (value < 100)
                    p1 = value;
                else
                {
                    //Raising an Event
                    //step3: Whenever required
                    //to raise the event call the delegate reference
                    if (InvalidP1 != null)  //will be null if there are no handlers
                        InvalidP1();
                }

            }
        }
    }
}

namespace EventHandling2
{
    //What if the event has parameters
    //Eg: Key Press, Mouse Move (Coordinates)
    internal class Program
    {
        static void Main()
        {
            //Simpler way than Main0

            Class1 objClass2 = new Class1();
            objClass2.InvalidP1 += ObjClass2_InvalidP1;
            objClass2.P1 = 210;
            
        }

        private static void ObjClass2_InvalidP1(int InvalidValue)
        {
            Console.WriteLine("InvalidP1 event raised - eventhandlingcode here AND value was -> "+InvalidValue);
        }

        private static void Handler2()
        {
            Console.WriteLine("Handler 2");
        }
    }

    //The delegate signature must match the signature as the event handling function
    //If event was X
    //Then delegate is X_eventHandler
    //for an event handler delegate the return type is always void
    //you can have events with parameters or without

    //step1: Create a delegate class having the same signature
    //as the event handling function
    public delegate void InvalidP1EventHandler(int InvalidValue); //all events generally return void, passing parameters to the event

    //Developer Part
    public class Class1
    {
        //step2: declare the event of the delegate type
        //event is a delegate reference
        public event InvalidP1EventHandler? InvalidP1;
        private int p1;

        public int P1
        {
            get { return p1; }
            set
            {
                if (value < 100)
                    p1 = value;
                else
                {
                    //Raising an Event
                    //step3: Whenever required
                    //to raise the event call the delegate reference
                    if (InvalidP1 != null)  //will be null if there are no handlers
                        InvalidP1(value);
                }

            }
        }
    }
}
