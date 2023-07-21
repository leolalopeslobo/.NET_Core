namespace Boxing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }

        static void Boxing()
        {
            int i = 100;  //Value Type

            object o;
            o = i;  //Boxing  -> here we are storing a value type inside a reference type
            //Here the value type is copied from the stack to the heap
            int j;
            j = (int)o;   //Unboxing
            //Here we typecasting since it doesn;t know what type of data is present in the object
            //We want to read an int data
        }
    }

    public class Class1
    {
        public int i;
    }
}


//Why would you want to store a value type inside a reference type?


//Boxing and Unboxing are slowing the code since we are copying from Stack to Heap and vice-versa
//An therefore you should avoid boxing and unboxing for better performance since it is an Expensive Process
