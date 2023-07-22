namespace Arrays
{
    internal class Program
    {
        static void Main1()
        {
            //Creating an Array
            int[] arr = new int[5];

            //All arrays inherit from the System.Array class
            //This is an abstract class


            //arr[0] ... arr[4]

            //accessing the elements
            for(int i=0; i<arr.Length; i++)  //therefore arr.Length() comes from the System.Array class
            {
                //Using String Concatenation
                //Console.WriteLine("Enter value for arr["+i+"]: ");


                //Using Placeholder
                //Console.WriteLine("Enter value for arr[{0}]: ",i);


                //Using String Interpolation
                //Console.WriteLine($"Enter value for arr[{i}]: ");


                //Reading data OR Accepting values from the User
                //arr[i] = int.Parse(Console.ReadLine());

                //arr[i] = Convert.ToInt32(Console.ReadLine());

                for(int i = 0; i < arr.Length; i++)
                {
                    Console.WriteLine(arr[i]);
                }

                //ForEach is a readOnly Loop
                //Therefore you can't use it for accepting value, you can only use it for displaying values
                foreach(int x in arr)
                {
                    Console.WriteLine(x);
                }
            }
        }

        static void Main2()
        {
            //Different ways of creating an Array
            //1.
            int[] arr = new int[5];

            //2.
            int[] arr1 = { 10, 20, 30, 40, 50 };


            //3.
            int[] arr2 = new int[5] { 10, 20, 30, 40, 50 }; //here you fix the elements ie the size of the elements



            //Methods of the Array class
            int[] arr3 = (int[])Array.CreateInstance(typeof(int), 6); //creating an array of size 6


            //allows to search for an element at a position
            //if found returns the position
            //if not found returns -1
            int pos = Array.IndexOf(arr1, 20);  

            //Returns the last index where this element is present (last occurance of that value)
            pos = Array.LastIndexOf(arr1, 20);

            //Here you can do a BinarySearch for large array
            //also the array must be in sorted order
            pos = Array.BinarySearch(arr1, 20);


            //Resets to the default values
            Array.Clear(arr1);


            //Copy Elements from one array to another and what is the length to be copied
            Array.Copy(arr1, arr2, arr.Length);

            //Here either the entire array is copied or nothing is copied at all
            //Array.ConstrainedCopy();




            //Generics in Array and they are used in LINQ Queries
            //Array.<>


            Array.Reverse(arr1);
            //Array.Sort();


            //ALL THESE METHODS WORK ON FOR 1D ARRAY
        }

        static void Main3()
        {
            //Multiple Dimentional Arrays



            //int[,,,,,,] arr;
            //The number of commas is one less than the dimentions we are creating

            int[] arr = new int[5];  //5 marks
            int[,] arr1 = new int[7, 5];  //7 students and each having 5 subjects

            int[,,] arr2 = new int[2, 7, 5]; //2 classrooms, 7 students and each having 5 subjects


            int[,,,] arr3 = new int[5, 2, 7, 5]; //5 centers, 2 classrooms, 7 students and each having 5 subjects


            //2D Arrays
            int[,] arr4 = new int[5, 2];
            //arr4[0,0] arr[0,1] arr[0,2]
            //arr4[1,0] arr[1,1] arr[1,2]
            //arr4[2,0] arr[2,1] arr[2,2]
            //arr4[3,0] arr[3,1] arr[3,2]
            //arr4[4,0] arr[4,1] arr[4,2]


            //Properties to find details of an array
            Console.WriteLine(arr4.Rank);  //returns the dimention of array  - 2
            Console.WriteLine(arr4.Length);  //retuens the number of elements  - 15
            Console.WriteLine(arr4.GetLength(0)); //returns the length of the first dimention
            Console.WriteLine(arr4.GetLength(1)); //returns the length of the second dimention

            Console.WriteLine(arr4.GetUpperBound(0));  //upper bound of first dimention  (ie 1 less than the length)
            Console.WriteLine(arr4.GetUpperBound(1));  //upper bound of second dimention

            //There is also Lower Bound
            //But in the C# it always returns 0


            //Looping through a 2D Array
            for (int i=0; i<arr4.GetLength(0); i++)
            {
                for (int j = 0; j < arr4.GetLength(1); j++)
                {
                    Console.WriteLine($"Value for arr4[{i},{j}] is {arr4[i,j]}");
                }
            }
        }

        static void Main4()
        {
            //Making Arrays more Flexible using ArrayOfArrays
            //Called as a Jagged Array

            int[][] arr = new int[4][];  //there are 4 students and every student has different number of subjects
            //arr is an Array of Array of integers

            Console.WriteLine(arr.Rank);  //this gives 1 since since it is a singleton array
            //Rank prints the number of dimentions

            //In each array element we store another array, since this an array of arrays
            arr[0] = new int[3]; //arr[0][0], arr[0][1], arr[0][2] -> storing 3 subjects
            arr[1] = new int[4]; //arr[1][0], arr[1][1], arr[1][2], arr[1][3] 
            arr[2] = new int[2]; //arr[2][0], arr[2][1] 
            arr[3] = new int[3]; //arr[3][0], arr[3][1], arr[3][2] 


            //Accepting Values
            for(int i=0; i<arr.Length; i++)
            {
                for(int j=0; j < arr[i].Length; j++)
                {
                    Console.Write($"Enter value for subscript[{0}][{1}]: ", i, j);
                    arr[i][j] = Convert.ToInt32(Console.ReadLine());
                }

                Console.WriteLine();
                Console.WriteLine();


            }

            //Display Values
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.WriteLine("Value for subscript[{0}][{1}] is {2}: ", i, j, arr[i][j]);
                }

                Console.ReadLine();

            }
        }


        static void Main()
        {
            //Creating an Array for Employee class
            Employee[] arr = new Employee[4];  //the 'new' is for what should be the size of the array
            //Each of the emplyee objects is initially null
            //arr[0] = new Employee(); //allocates memory for the memory object at the first location of the array
            //arr[1] = new Employee();
            //arr[2] = new Employee();
            //arr[3] = new Employee();
            //It is important that after you create an array of objects you have to allocated memory for then otherwise they will be null
            

            //Doing the above in a loop
            for(int i=0; i<arr.Length; i++)
            {
                //arr[i].Name
            }


            foreach(Employee e in arr)
            {
                //e.Name  //Works!
                //Since we can access and its readonly and you are not changing what e points to
                e.Name = "a";  //This is also OK! since we are not changing what e points to

                //But
                //e = new Employee();  //ERROR
                //e = SomeEmpObject;  //ERROR
                //Since item is only 'Read-only'
            }
        }
    }



    //Creating an array for employee class
    public class Employee
    {
        public int EmpNo { get; set; }
        public string? Name { get; set; }
    }
}
