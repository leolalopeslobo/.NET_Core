//Passing Value Types
namespace FunctionCallingAndPassingValueChanges1
{
    internal class Program
    {
        static void Main1()
        {
            int i = 100;
            int j = 200;
            Swap(i, j);
            Console.WriteLine(i);  //100
            Console.WriteLine(j);  //200

            Swap1(ref i, ref j); //passing as a reference
            Console.WriteLine(i);  //200
            Console.WriteLine(j);  //100

            //There is no change since when you pass values to a function it doesn't change the values outside since it is LOCAL SCOPE and VALUE Type
        }


        static void Main2()
        {

            int i = 100;
            int j = 200;

            //int k;   //this gives an ERROR since a local variable (variable assigned inside a mathod) is unassigned
            Init(ref i, ref j); //passing as a reference
            Console.WriteLine(i);  //1000
            Console.WriteLine(j);  //2000

            //There is no change since when you pass values to a function it doesn't change the values outside since it is LOCAL SCOPE and VALUE Type
        }


        static void Main3()
        {
            //To solve the unassigned value issue we make use of 'out'
            //An out variable is similar to a ref variable but the difference if that initially it need not have an initial value
            int i;
            int j;

            //Console.WriteLine(i);  //ERROR since unassigned
            //Console.WriteLine(j);  

            Init1(out i, out j); //passing as a reference
            Console.WriteLine(i);  //1000
            Console.WriteLine(j);  //2000

            //There is no change since when you pass values to a function it doesn't change the values outside since it is LOCAL SCOPE and VALUE Type




            //in is optional ie if you want give it or not
            Print(in i);
            Print(j);
        }
        static void Swap(int a, int b)  //a = i, b = j (These are value types -> so the values are copied and not points)
        {
            int temp = a;
            a = b;
            b = temp;

            //It doesn't matter even if you use the same variable names also
            //int temp = i;
            //i = j;
            //j = temp;


        //Values types don't let changes done in the function to reflect in the calling code
        }




        //To make the changes Reflect in the calling code - you have to use the type 'ref'
        static void Swap1(ref int a, ref int b)  //a = i, b = j (These are value types -> so the values are copied and not points)
        {
            int temp = a;
            a = b;
            b = temp;

            //It doesn't matter even if you use the same variable names also
            //int temp = i;
            //i = j;
            //j = temp;


            //Here the value type is made into a ref
            //This means that the change made in the function is reflected in the calling code
        }


        static void Init(ref int a, ref int b)
        {
            a = 1000;
            b = 2000;
        }

        static void Init1(out int a, out int b)
        {
            //Also an out variable inside a function looses it's value when it gets into the function
            a = 1000;
            b = 2000;
            //Also if the varaible has no value then you compulsorily have to initialize otherwise ERROR
        }


        //This ref technique can be used to return more than one values


        

        //in variable
        static void Print(in int i) //read only variable
        {
            //i++ //ERROR since read only variable
            Console.WriteLine(i);
        }

    }



    //out is similar to ref - changes made in func reflect back in calling code
    //the initial value is discarded
    //out variables MUST be initialized in the function
}


//Passing Reference Types
namespace FunctionCallingAndPassingValueChanges2
{
    internal class Program
    {
        static void Main1()
        {
            Class1 o = new Class1();
            o.i = 100;
            DoSomething1(o);

            Console.WriteLine(o.i);  //200 -> since this is a reference type
        }

        static void Main2()
        {
            Class1 o = new Class1();
            o.i = 100;
            DoSomething2(o);

            Console.WriteLine(o.i);  //100 -> since the reference type point to a new object
        }

        static void Main3()
        {
            Class1 o = new Class1();
            o.i = 100;
            DoSomething3(ref o);

            Console.WriteLine(o.i);  //200 -> since the reference type point to each other
        }

        static void Main4()
        {
            Class1 o = new Class1();
            o.i = 100;
            DoSomething5(o);

            Console.WriteLine(o.i);  //100 -> since the reference type point to a new object
        }

        static void Main()
        {
            //Class1 o = new Class1();
            //o.i = 100;

            Class1 o;
            DoSomething4(out o);

            Console.WriteLine(o.i);  //100 -> since the reference type point to a new object
        }

        static void DoSomething1(Class1 obj)  //obj = o (obj points to what o points to)
        {
            obj.i = 200;
        }

        static void DoSomething2(Class1 obj)  //obj = o 
        {
            obj = new Class1();
            obj.i = 200;
        }


        //Here if we want the change to reflect inside and out
        static void DoSomething3(ref Class1 obj)  //obj = o (obj points to what o points to and vice versa)
        {
            obj = new Class1();
            obj.i = 200;
        }


        static void DoSomething4(out Class1 obj)  //obj = o (obj points to what o points to and vice versa)
        {
            //Here obj will loose its initial value
            //Therfore here you are forced to allocate memory
            obj = new Class1();
            obj.i = 200;
        }


        static void DoSomething5(in Class1 obj)  
        {
            //obj = new Class1(); //ERROR -> since here it cannot point to something else
            obj.i = 200;
        }

    }

    public class Class1
    {
        public int i;
    }
}
