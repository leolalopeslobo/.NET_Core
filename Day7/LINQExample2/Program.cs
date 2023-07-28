using System;
using System.Diagnostics;

namespace LinqExample2
{
    internal class Program
    { 
        static List<Employee> lstEmp = new List<Employee>();
        static List<Department> lstDept = new List<Department>();

        public static void AddRecs()
        {
            lstDept.Add(new Department { DeptNo = 10, DeptName = "SALES" });
            lstDept.Add(new Department { DeptNo = 20, DeptName = "MKTG" });
            lstDept.Add(new Department { DeptNo = 30, DeptName = "IT" });
            lstDept.Add(new Department { DeptNo = 40, DeptName = "HR" });


            lstEmp.Add(new Employee { EmpNo = 1, Name = "Vikram", Basic = 10000, DeptNo = 10, Gender = "male" });
            lstEmp.Add(new Employee { EmpNo = 2, Name = "Vikas", Basic = 11000, DeptNo = 10, Gender = "male" });

            lstEmp.Add(new Employee { EmpNo = 3, Name = "Abhijit", Basic = 12000, DeptNo = 20, Gender = "male" });
            lstEmp.Add(new Employee { EmpNo = 4, Name = "Mona", Basic = 11000, DeptNo = 20, Gender = "female" });
            lstEmp.Add(new Employee { EmpNo = 5, Name = "Shweta", Basic = 12000, DeptNo = 20, Gender = "female" });

            lstEmp.Add(new Employee { EmpNo = 6, Name = "Sanjay", Basic = 11000, DeptNo = 30, Gender = "male" });
            lstEmp.Add(new Employee { EmpNo = 7, Name = "Arpan", Basic = 10000, DeptNo = 30, Gender = "male" });

            lstEmp.Add(new Employee { EmpNo = 8, Name = "Shraddha", Basic = 11000, DeptNo = 40, Gender = "female" });
        }
        static void Main1(string[] args)
        {
            //GroupBy
            //This allows you to create groups of data
            AddRecs();

            var emps = from emp in lstEmp group emp by emp.DeptNo;
            //emps is returned as a IGrouping

            foreach(var item in emps)  //item is IGrouping
            {
                Console.WriteLine(item.Key); //deptno
                foreach (var e in item)  //e is a Employee, item is a grouping of Employee
                {
                    Console.WriteLine(e);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        static void Main1a(string[] args)
        {
            //GroupBy with grpname
            //This allows you to create groups of data
            AddRecs();

            var emps = from emp in lstEmp group emp by emp.DeptNo into group1 select group1; //here we giving a name for the group            //emps is returned as a IGrouping



            foreach (var item in emps)  //item is IGrouping
            {
                Console.WriteLine(item.Key); //deptno
                foreach (var e in item)  //e is a Employee, item is a grouping of Employee
                {
                    Console.WriteLine(e);
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }


        static void Main1b(string[] args)
        {
            //GroupBy with grpname and Anonymous Type
            //This allows you to create groups of data
            AddRecs();

            var emps = from emp in lstEmp group emp by emp.DeptNo into group1 select new { group1, Count = group1.Count(), Max = group1.Max(x => x.Basic), Min = group1.Min(x => x.Basic)};
            //Count, Max and Min are the alias the names of the columns and it is mandatory

            foreach (var item in emps)  //item is Anonymous type
            {
                Console.WriteLine(item.group1.Key); //DeptNo
                Console.WriteLine(item.Count); //Count
                Console.WriteLine(item.Max); //Max
                Console.WriteLine(item.Min); //Min
                //emp.group1.Key;  //DeptNo

                foreach (var e in item.group1)  //e is an Employee
                {
                    Console.WriteLine(e);
                }
            }
            Console.ReadLine();
        }

        static void Main2(string[] args)
        {
            //Deferred Execution
            AddRecs();

            var emps = from emp in lstEmp select emp;  //here we 8 records
            
            Console.WriteLine();
            lstEmp.RemoveAt(0);  //here we 7 records

            foreach (var emp in emps)  //Here emps is affected due to deferred execution hence it will be only 7 records
            {
                Console.WriteLine(emp.Name + ", " + emp.EmpNo);
                Debug.WriteLine(emp.Name + ", " + emp.EmpNo);
            }
            Console.ReadLine();


            Console.WriteLine();
            lstEmp.Add(new Employee { EmpNo = 9, Name = "New", Basic = 11000, DeptNo = 40, Gender = "male" });
            foreach (var emp in emps)  //Here emps is affected due to deferred execution hence it will be 9 records
            {
                Console.WriteLine(emp.Name + ", " + emp.EmpNo);
            }
            Console.ReadLine();
        }

        static void Main3(string[] args)
        {
            //Immediate Execution
            AddRecs();

            var emps = from emp in lstEmp select emp;
            //var emps = (from emp in lstEmp select emp).ToList();
            //immediate execution
            emps = emps.ToList();  //.ToArray, .ToDictionary

            //Employee[] arrEmps = emps.ToArray();
            //Dictionary<int, Employee> d = emps.ToDictionary(e => e.EmpNo);

            Console.WriteLine();
            lstEmp.RemoveAt(0);

            foreach (var emp in emps)  //Here emps is not affected hence it will be only 8 records, due to the immediate execution
            {
                Console.WriteLine(emp.Name + ", " + emp.EmpNo);
                Debug.WriteLine(emp.Name + ", " + emp.EmpNo);
            }
            Console.ReadLine();


            Console.WriteLine() ;
            lstEmp.Add(new Employee { EmpNo = 9, Name = "New", Basic = 11000, DeptNo = 40, Gender = "male" });
            foreach (var emp in emps)  // Here also emps is not affected hence it will be only 8 records, due to the immediate execution
            {
                Console.WriteLine(emp.Name + ", " + emp.EmpNo);
            }
            Console.ReadLine();
        }

        static void Main()
        {
            AddRecs();
            //Single - [this says you must get exactly 1 record]
            Employee emp = lstEmp.Single(e => e.EmpNo == 1); //one record = okay
            //Employee emp = lstEmp.Single(e => e.EmpNo == 10); //no records = error  [this says you must get exactly 1 record]
            //Employee emp = lstEmp.Single(e => e.EmpNo > 5000); //multiple records = error

            //SingleOrDefault - [this says you must get exactly 1 record or the default]
            //Employee emp = lstEmp.SingleOrDefault(e => e.EmpNo == 1); //one record = okay
            //Employee emp = lstEmp.SingleOrDefault(e => e.EmpNo == 10); //no records = null
            //Employee emp = lstEmp.SingleOrDefault(e => e.EmpNo > 5000); //multiple records = error

            if (emp != null)
                Console.WriteLine(emp.Name + ", " + emp.EmpNo);
            else
                Console.WriteLine("not found");
            Console.ReadLine();
        }
    }
    public class Department
    {
        public int DeptNo { get; set; }
        public string? DeptName { get; set; }
    }

    public class Employee
    {
        public int EmpNo { get; set; }
        public string? Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
        public string? Gender { get; set; }

        public override string ToString()
        {
            string s = Name + "," + EmpNo.ToString() + "," + Basic.ToString() + "," + DeptNo.ToString() + "," + Gender;
            return s;
        }

    }
}
