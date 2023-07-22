namespace NullableTypes
{
    internal class Program
    {
        static void Main()
        {
            int? i;
            i = 10;
            i = null;

            int j;
            //j = i;  //ERROR since different types

            //Method1
            if(i != null)
            {
                j = (int)i;
            }
            else
            { j = 0; }

            //Method2
            //this return true if not null, else returns false
            if (i.HasValue)
            {
                j = i.Value;
            }else { j = 0; }


            //Method3
            j = i.GetValueOrDefault();
            j = i.GetValueOrDefault(5);


            //Method4
            j = i ?? 0;  //?? - null coalescing opertaor
            //if i has value then assign it to j
            //else assign i as 0

            Console.WriteLine(j);
            
        }
    }


    public class Employee1
    {
        private string? name; //nullable ref type

        public string? Name
        {
            get
            {
                return name;
            }
            set
            {
                if (!string.IsNullOrEmpty(value))
                    name = value;
                else
                    Console.WriteLine("Invalid Name");
            }
        }

        public decimal Basic { get; set; }
        public int DeptNo { get; set; }

        private static int lastEmpNo;

        private int empNo;
        public int EmptNo
        {
            get { return empNo; }
        }

        public Employee1(string Name = "noname", decimal Basic = 10000, int deptNo = 10)
        {
            this.Name = Name;
            this.Basic = Basic;
            this.DeptNo = DeptNo;
        }
    }
}
