namespace ConstructorsAndObjectInitializers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1 obj = new Class1();
            Console.WriteLine(obj.P1);  //prints the initial values ie 0
            Console.WriteLine(obj.P2);
            Console.WriteLine(obj.P3);


            //Class1 obj2 = new Class1(10,20,30);  //not available

            //therefore since the constructor is not available
            //you can write the same with properties
            Class1 obj2 = new Class1();
            obj2.P1 = 10;
            obj2.P2 = 20;
            obj2.P3 = 30;


            //But then what if there were 10 values, then the code becomes too lengthy
            //therefore to shorten it we make use of 'Object Initializer'
            //Class1 obj3 = new Class1() { P1=10, P2=20, P3=30 };  //this line is equal to the 3 lines above
            //to make the above still shorter
            Class1 obj3 = new Class1 { P1=10, P2=20, P3=30}; //here any order is allowed and not even neccessary to pass all values
            Class1 obj4 = new Class1 { P3 = 30 };

            //Line 13 is more preferred than line 27, since in line 13 you are directly in the constructor you are initializing the values
            //while in line 27 you are doing double work since first you are calling the no para const where default values are initialized and then you are again calling the properties
            //Therefore first choice should always be a constructor and then an object initializer
            //Object Initializer is used when the particular constructor is not avaliable

            Console.WriteLine(obj2.P1);  
            Console.WriteLine(obj2.P2);
            Console.WriteLine(obj2.P3);

        }
    }

    public class Class1
    {
        public int P1 { get; set; }
        public int P2 { get; set; }
        public int P3 { get; set; }


        //constructor
        public Class1()
        {
            Console.WriteLine("no param cons called");
            P1 = 1;
                P2 = 2;
                    P3 = 3;
        }

        //constructor overloading
        //public Class1(int P1, int P2, int P3)
        //{
        //    Console.WriteLine("param cons called");
        //    this.P1 = P1;  //this - refers to the current object
        //    this.P2 = P2;
        //    this.P3 = P3;
        //}


        //optional parameters with default values
        //public Class1(int P1=1, int P2=2, int P3=3)
        //{
        //    Console.WriteLine("param cons called");
        //    this.P1 = P1;  //this - refers to the current object
        //    this.P2 = P2;
        //    this.P3 = P3;
        //}
    }
}
