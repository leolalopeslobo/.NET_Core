namespace Delegates
    //Delegates PART1
{
    //Step1: Create a Delegate Class having the same signature as the function to call
    public delegate void Del1(); //Del1 has same signature as Display()


    public delegate int DelAdd(int a, int b);

    internal class Program
    {
        static void Main1()
        {
            //Display();  //calling function directly

            //using Delegates
            //Step2: Declare a delegate reference and a delegate object
            //the delegate object has the function name as the parameter
            Del1 objDel = new Del1(Display);

            //Step3: Call the function indirectly via the delegate reference
            objDel();

        }

        static void Main2()
        {
            //Del1 objDel = new Del1(Display);
            Del1 objDel = Display;  //line 24 and 23 are the same
            objDel();

            objDel = Show;
            objDel();

        }

        //Delegates inherites
        //Object
        //Delegates
        //MulticastDelegate   -  Multicast means the ability to call/cast more than one function
        //Del1
        static void Main3()
        {
            //Del1 objDel = new Del1(Display);
            Del1? objDel = Display;  //line 24 and 23 are the same
            objDel();
            Console.WriteLine();
            objDel += Show;  //+= adds Show to Display
            objDel();

            Console.WriteLine();
            objDel += Display;
            objDel();


            Console.WriteLine();
            objDel += Display;
            objDel();


            Console.WriteLine();
            objDel += Show;
            objDel();



            Console.WriteLine();
            Console.WriteLine();
            objDel -= Display;  //the last Display is removed
            objDel!();

            Console.WriteLine();
            Console.WriteLine();
            objDel -= Display;
            //objDel!();   //exception -> null reference exception
        }

        static void Main4()
        {
            //DelAdd objDelAdd = new DelAdd(Add);
            DelAdd objDelAdd = Add;
            //int sum = objDelAdd(2, 4);
            //Console.WriteLine(sum);

            objDelAdd += Subtract;

            Console.WriteLine(objDelAdd(10, 5));  //only one return value is returned which of the last function call



        }

        static void Main5()
        {
            //Calling methods from different classes
            Del1 objDel = Class1.Display;
            objDel();

            Class1 c1 = new Class1();
            objDel = c1.Show;
            objDel();
        }


        static void Main6()
        {
            Console.WriteLine(CallMathOperation(Add,10,5));
            Console.WriteLine(CallMathOperation(Subtract,16,7));
        }

        static int CallMathOperation(DelAdd objDelAdd, int a, int b) //will call Add or Subtract and which one to call will be passed as parameter
        {
            //function to call is being received as a parameter (using the delegate.reference)

            //The function to call can be passed as a parameter using delegates
            //Delegates are function pointers
            return objDelAdd(a,b);

            //2 things possible
            //objDelAdd = Add;
            //objDelAdd = Subtract;
        }


        static void Main()
        {
            //Delegate class has methods
            Del1 objDel = (Del1)Delegate.Combine(new Del1(Display), new Del1(Show));  //this is like doing a += to
            objDel();

            Console.WriteLine();
            objDel = (Del1)Delegate.Combine(objDel, new Del1(Display));
            objDel();

            Console.WriteLine();
            objDel = (Del1)Delegate.Remove(objDel, new Del1(Display));
            objDel!();

            Console.WriteLine();
            objDel = (Del1)Delegate.RemoveAll(objDel, new Del1(Display));
            objDel!();
        }

        static void Display()
        {
            Console.WriteLine("Display Called");
        }

        static void Show()
        {
            Console.WriteLine("Show Called");
        }

        static int Add(int a, int b)
        {
            return a + b;
        }
        static int Subtract(int a, int b)
        {
            return a - b;
        }


        //The problem with Multicast Delegates is that they call all the function but only returns the last called function

    }

    public class Class1
    {
        public static void Display()
        {
            Console.WriteLine("Class1.Display Called");
        }

        public void Show()
        {
            Console.WriteLine("Class1.Show Called");
        }
    }
}
