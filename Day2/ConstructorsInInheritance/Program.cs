namespace InheritanceConstructors
{

    //How to call constructors of the base class
    internal class Program
    {
        static void Main(string[] args)
        {
            //DerivedClass o = new DerivedClass();
            DerivedClass o1 = new DerivedClass(123,456);
        }
    }

    public class BaseClass
    {
        public int i;

        public BaseClass()
        {
            Console.WriteLine("Base class no params cons");
            i = 10;
        }

        public BaseClass(int i)
        {
            Console.WriteLine("Base Class int cons");
            this.i = i;
        }
    }

    public class DerivedClass : BaseClass
    {
        public int j;

        public DerivedClass()
        {
            Console.WriteLine("Derived Class no params cons");
            //i = 10;  //don't reinitialise the same thing again
            j = 20;
        }

        ////this below constructor will call the Base Class constructor with no params only
        //public DerivedClass(int i, int j) 
        //{
        //    Console.WriteLine("Derived Class int, int cons");
        //    //this.i = i //no need to reinitialise again
        //    this.j = j;
        //}


        //this below constructor will call the Base Class constructor with params using 'base()'
        public DerivedClass(int i, int j) : base(i)
        {
            Console.WriteLine("Derived Class int, int cons");
            //this.i = i //no need to reinitialise again
            this.j = j;
        }
    }
}

//if you don't specify the constructor that needs to be called then the no params constructor is called
//the baseclass initialises all the baseclass members and the derivedclass initializes all the derived class members
//the derived class doesn't initialise the base class members
