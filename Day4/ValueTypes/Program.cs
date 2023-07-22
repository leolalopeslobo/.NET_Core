//Value Type - Struct
namespace ValueTypes1
{
    internal class Program
    {
        static void Main1()
        {
            //Using a struct
            MyPoint p = new MyPoint();
            Console.WriteLine(p.A);
        }
    }

    //Creating a struct

    //All things available in a class is also avalaible in a struct
    public struct MyPoint
    {
        public int A
        {
            get; set;
        }
        public int X;

        private int b;

        public int B
        {
            get { return b; }
            set { b = value; }
        }

        public MyPoint()
        {
            //this.X = 10;
            //this.A = 30;
            //this.b = 0;
            //this.B = 40;

            //Upto .Net 6 you had to initialize the values in the constructor otherwise you would get a compile error
            //But in .Net 7 you don't have to initialize the values in the constructor, since they get initialised to their initialised to default values
        }
    }

    //Difference between struct and class
    //struct is a value type and is created on the stack
    //Whereas when you instantiate a class the objects are created on the heap


    //if you have to compare a struct and a class, then the struct would be faster since its on the Stack

    //Limitations of struct
    //-No inheritance is not allowed/possible in a struct (so all inheritance concepts won't work) -> abstract, virtual, sealed -> nothing is possible
    //- You can't a protected member since its related to inheritance
    //Other than this there is no more difference



    //So if you want to store data that will not be inherited then the concept of struct works
}

//Value Type - Enum
namespace ValueTypes2
{
    //(Enum is set of constant values that you give)
    //is Enum like a switch?
    internal class Program
    {
        static void Main()
        {
            Display1(1);  //This kind of code is difficult to read, maintain
            //So we create ENUMS
            Display2(TimeOfDay.Morning);  //this helps to write code so much better
            //And the code is also maintainable since even if the value is changed
        }


        //In this function we don't know which number will call what greeting
        static void Display1(int t)
        {
            if (t == 0)
            {
                Console.WriteLine("Good Morning");
            }
            else if (t == 1)
            {
                Console.WriteLine("Good Afternoon");
            }
            if (t == 2)
            {
                Console.WriteLine("Good Evening");
            }
            if (t == 3)
            {
                Console.WriteLine("Good Night");
            }
        }


        //Using ENUM for the method
        static void Display2(TimeOfDay t)
        {
            if (t == TimeOfDay.Morning)
            {
                Console.WriteLine("Good Morning");
            }
            else if (t == TimeOfDay.Afternoon)
            {
                Console.WriteLine("Good Afternoon");
            }
            else if (t == TimeOfDay.Evening)
            {
                Console.WriteLine("Good Evening");
            }
            else if (t == TimeOfDay.Night)
            {
                Console.WriteLine("Good Night");
            }
        }
    }

    
    //Creating an ENUM
    //An ENUM is a set of constant values
    public enum TimeOfDay
    {
        //Constants in ENUM
        //By default values start with 0
        //And also you can give it a value if you want to
        Morning,
        Afternoon,
        Evening,
        Night
    }


    //Giving other values beside 'int'
    //and all ints are structs and therefore enums are technically structs
    public enum TimeOfDay1 : byte
    {
        //Constants in ENUM
        //By default values start with 0
        //And also you can give it a value if you want to
        Morning,
        Afternoon,
        Evening,
        Night
    }


    //An ENUM by default is an 'int'
    //But if you don't want that then you can give other numeric values besides int
}
