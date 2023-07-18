using System.Reflection.Metadata.Ecma335;

namespace Properties
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Class1 o = new Class1();
            //o.SetI(1000);
            //o.i = 1000;  // -> this makes i accessible only inside the class and not outside
            //Console.WriteLine(o.i);
            //Console.WriteLine(o.GetI());


            //o.i = ++o.i + o.i++ - o.i-- - --o.i;


            o.I = 100; //assign a value - set
            Console.WriteLine(o.I); //read a value - get

        }
    }

    public class Class1
    {
        //private int i; //class level varible OR field
        ////all fields are intialised with the default values

        ////setting the value with validation
        //public void SetI(int VALUE)
        //{
        //    if(VALUE < 100)
        //        i = VALUE;
        //    else
        //    {
        //        Console.WriteLine("Invalid i");
        //        //throw new Exception("Invalid i");  // -> this is the correct way of doing it
        //    }
        //}

        //public int GetI()
        //{
        //    return i;
        //}

        //PROPERTY
        private int i;

        public int I //Property
        {
            set
            {
                if (value < 100)
                    i = value;
                else
                    Console.WriteLine("Invalid i");
            }
            get
            {
                return i;
            }
        }


        //string property
        private string prop1;

        public string Prop1
        {
            set
            {
                prop1 = value;
            }
            get
            {
                return prop1;
            }
        }
    }
}


//Properties
//this gives the best of both worlds, a method and a variable
//A property is a combination of setter and getter

//The syntax of using a property is like using a variable, but when you use the property ot goes and calls the respective method
