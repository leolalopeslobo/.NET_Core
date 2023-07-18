namespace Properties2
{
    internal class Program
    {
        static void Main()
        {
            Class1 o = new Class1();
            o.Prop3 = "aaa";
            Console.WriteLine(o.Prop3);
        }
    }

    public class Class1
    {
        //PROPERTY
        private int i;  //int - C# datatype and int32 - CTS datatype

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

        public string Prop2;  //field

        //It is always better to create a property than a field since it is makes it easier to create validation incase required in the future
        //Always for consistency its better to have properties rather than fields
        //Also you can do more with properties than with fields

        //
        //Automatic / Auto Property
        //used when no validations are required
        //compiler generates the private variables
        //compiler generates the code for setter and getter

        //Here you can only access the get and set but not the private variable
        public string Prop3 { get; set; }



        //READ ONLY Property
        //This means you have only the get and NO set since we can only read the value and not change it

        private string prop4;
        public string Prop4
        {
            get
            {
                return prop4;
            }
        }

        //Write ONLY property
        private string prop5;
        public string Prop5
        {
            set
            {
                prop5 = value;
            }
        }
    }
}

//Why create a property?
//To write some sort of validation on the data that you have
