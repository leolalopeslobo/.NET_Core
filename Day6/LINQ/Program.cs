//https://linqsamples.com/


namespace LinqExample1
{
    internal class Program
    {
        //creating a collection that is a list of departments and employees
        static List<Employee> lstEmp = new List<Employee>();
        static List<Department> lstDept = new List<Department>();

        public static void AddRecs()
        {
            lstDept.Add(new Department{ DeptNo=10, DeptName="SALES"});
            lstDept.Add(new Department { DeptNo = 20, DeptName = "MKTG" });
            lstDept.Add(new Department { DeptNo = 30, DeptName = "IT" });
            lstDept.Add(new Department { DeptNo = 40, DeptName = "HR" });


            lstEmp.Add(new Employee { EmpNo = 1, Name = "Vikram", Basic = 10000, DeptNo = 10, Gender = "male"});
            lstEmp.Add(new Employee { EmpNo = 2, Name = "Vikas", Basic = 11000, DeptNo = 10, Gender = "male"});

            lstEmp.Add(new Employee { EmpNo = 3, Name = "Abhijit", Basic = 12000, DeptNo = 20, Gender = "male"});
            lstEmp.Add(new Employee { EmpNo = 4, Name = "Mona", Basic = 11000, DeptNo = 20, Gender = "female"});
            lstEmp.Add(new Employee { EmpNo = 5, Name = "Shweta", Basic = 12000, DeptNo = 20, Gender = "female"});

            lstEmp.Add(new Employee { EmpNo = 6, Name = "Sanjay", Basic = 11000, DeptNo = 30, Gender = "male"});
            lstEmp.Add(new Employee { EmpNo = 7, Name = "Arpan", Basic = 10000, DeptNo = 30, Gender = "male"});

            lstEmp.Add(new Employee { EmpNo = 8, Name = "Shraddha", Basic = 11000, DeptNo = 40, Gender = "female"});
        }
        static void Main1(string[] args)
        {
            AddRecs();

            //Writing the first Query
            //var returnvalue = from single_object in collection select something
            var emps = from emp in lstEmp select emp; //therfore this will contain a collection of Employee objects
            //lstEmp is a List<Employee>
            //emp is a single object in the object and the datatype is Employee
            //foreach (Employee emp in lstEmp)
            //{

            //}

            //Therfore, the is like a foreach loop and will point to the first Employee object
            //For a LINQ to work then it must implement IEnumerable or IQueryable


            //displaying emps
            //var emps = from emp in lstEmp select emp;
            //IEnumerable<Employee> emps = from emp in lstEmp select emp;
            //foreach (Employee item in emps)
            foreach (var item in emps)
            {
                Console.WriteLine(item);
            }
        }

        static void Main2(string[] args)
        {
            AddRecs();

            //Selecting from a single column
            //var emps = from emp in lstEmp select emp.Name;
            //lstEmp - List<Employee>
            //emp - Employee
            //emp.Name - string
            //emps - IEnumerable<string>

            //var emps = from emp in lstEmp select emp.EmpNo;
            //lstEmp - List<Employee>
            //emp - Employee
            //emp.EmpNo - int (property)?
            //emps - IEnumerable<int>
            //foreach (var item in emps)
            //{//item - int
            //    Console.WriteLine(item);
                ///item. - will give all the properties and methods of an 'int'
            //}


            //if you want to select more than one property then you have to create an anonymous type which contains these property
            var emps = from emp in lstEmp select new { emp.Name, emp.EmpNo };  //creating an anonymous type
            //new { emp.Name, emp.EmpNo } - Anonymous Type
            //lstEmp - List<Employee>
            //emp - Employee
            //emps - IEnumerable<AnonymousType>
            foreach (var item in emps)
            {//item - AnonymousType
                Console.WriteLine(item);
                ///item. - will give all the properties and methods of an AnonymousType ie Name and EmpNo
            }


        }

        static void Main3()
        {
            AddRecs();
            //Using where clause

            //var emps = from emp in lstEmp where emp.Basic > 10000 select emp;

            //AND
            //var emps = from emp in lstEmp where emp.Basic > 10000 && emp.Basic < 12000 select emp;

            //OR
            //var emps = from emp in lstEmp where emp.Basic < 10000 || emp.Basic > 12000 select emp;


            //Starts With
            var emps = from emp in lstEmp where emp.Name.StartsWith("V") select emp;


            foreach (var item in emps)
            {
                Console.WriteLine(item);
                
            }
        }

        static void Main4()
        {
            AddRecs();
            //Using orderby clause

            //Sorting in the ascending order by default
            //var emps = from emp in lstEmp orderby emp.Name select emp;

            //Descending Order
            //var emps = from emp in lstEmp orderby emp.Name descending select emp;

            //Both Ascending and Descending
            var emps = from emp in lstEmp orderby emp.DeptNo ascending, emp.Name descending select emp;

            //First the DeptNo is sorted in ascending order and then if the DeptNo are the same then in ascending of the Name

            foreach (var item in emps)
            {
                Console.WriteLine(item);

            }
        }

        static void Main5()
        {
            //Joining
            AddRecs();

            var emps = from emp in lstEmp join dept in lstDept on emp.DeptNo equals dept.DeptNo select emp;
            //basis for joining - emp.DeptNo equals dept.DeptNo


            var emps1 = from emp in lstEmp join dept in lstDept on emp.DeptNo equals dept.DeptNo select dept;

            var emps2 = from emp in lstEmp join dept in lstDept on emp.DeptNo equals dept.DeptNo select new { emp, dept };


            var emps3 = from emp in lstEmp join dept in lstDept on emp.DeptNo equals dept.DeptNo select new { emp.Name, dept.DeptName };

            foreach (var item in emps)
            {
                Console.WriteLine(item);

            }
            Console.WriteLine();
            foreach (var item in emps1)
            {
                Console.WriteLine(item);

            }

            Console.WriteLine();
            foreach (var item in emps2)
            {
                Console.WriteLine(item.emp.Name);
                Console.WriteLine(item.dept.DeptName);

            }

            Console.WriteLine();
            foreach (var item in emps3)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class Department
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
    }

    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
        public string Gender { get; set; }

        public override string ToString()
        {
            string s = Name + "," + EmpNo.ToString() + "," + Basic.ToString() + "," + DeptNo.ToString() + "," + Gender;
            return s;
        }
    
    }

}

namespace LinqExample2
{
    internal class Program
    {
        //creating a collection that is a list of departments and employees
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
            AddRecs();

            //Query Syntax
            //var emps = from emp in lstEmp select emp; //therfore this will contain a collection of Employee objects

            //Function Syntax
            var emps = lstEmp.Select(GetEmps);  //lstEmp - is a collection of list of Employee
            //GetEmps is called for each object in lstEmp

            //When you write an Extension Method for IEnumerable what does it do?
            //This will be avaliable for all classes that implement IEnumerable
            //-------------------



            // Query Syntax
            //var emps1 = from emp in lstEmp select emp.Name; //therfore this will contain a collection of Employee objects

            //Function Syntax
            var emps1 = lstEmp.Select(GetEmps1);  //lstEmp - is a collection of list of Employee
            //GetEmps is called for each object in lstEmp

            //-------------------
            // Query Syntax
            //var emps2 = from emp in lstEmp select emp.Name; //therfore this will contain a collection of Employee objects

            //Function Syntax
            var emps2 = lstEmp.Select(delegate(Employee emp)
            {
                return emp;
            });  //lstEmp - is a collection of list of Employee
            //GetEmps is called for each object in lstEmp
            //-------------------



            //-------------------
            //Lambda
            var emps3 = lstEmp.Select(emp => emp);
            //-------------------


            var emps4 = lstEmp.Select(emp => new {emp.Name, emp.EmpNo});



            foreach (var item in emps)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            foreach (var item in emps1)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            foreach (var item in emps2)
            {
                Console.WriteLine(item);
            }
        }

        static Employee GetEmps(Employee emp)
        {
            return emp;
        }
        static string GetEmps1(Employee emp)
        {
            return emp.Name;
        }


        //A function cannot return an Anonymous Type
        

        static void Main2()
        {
            AddRecs();
            //Using where clause

            //var emps = from emp in lstEmp where emp.Basic > 10000 select emp;
            var emp = lstEmp.Where(emp => emp.Basic>1000); //return a bool

            //var emp = lstEmp.Where(emp => emp.Basic > 1000).Select(emp => emp);
            //var emp = lstEmp.Select(emp=>emp).Where(emp => emp.Basic>1000); 

            //-------------------------------------
            //var emp = lstEmp.Where(emp => emp.Basic > 1000); //return a bool
            //var emp = lstEmp.Where(emp => emp.Basic > 1000).Select(emp => emp);
            //var emp = lstEmp.Select(emp=>emp).Where(emp => emp.Basic>1000); 
            //All these 3 give the same output
            //-------------------------------------


            //var emps = lstEmp.Where(emp => emp.Basic > 10000).Select(emp => emp.Basic);  //correct
            //var emps = lstEmp.Select(emp => emp.Basic).Where(emp => emp.Basic > 10000).;  //wrong
            //var emps = lstEmp.Select(emp => emp.Basic).Where(emp => emp > 10000).;  //correct -> since we are only working on the decimal
            //Remember always give the WHERE first since it has the entire object to work on and then the SELECT


            //AND
            //var emps1 = from emp in lstEmp where emp.Basic > 10000 && emp.Basic < 12000 select emp;
            var emps1 = lstEmp.Where(emp => emp.Basic > 1000 && emp.Basic < 12000);
            //OR
            //var emps = from emp in lstEmp where emp.Basic < 10000 || emp.Basic > 12000 select emp;


            //Starts With
            var emps = from emqp in lstEmp where emqp.Name.StartsWith("V") select emqp;


            foreach (var item in emps)
            {
                Console.WriteLine(item);

            }
        }

        static void Main3()
        {
            AddRecs();
            //Using orderby clause

            //Sorting in the ascending order by default
            //var emps = from emp in lstEmp orderby emp.Name select emp;
            //var emps = lstEmp.OrderBy(emp => emp.Name);

            //Descending Order
            //var emps = from emp in lstEmp orderby emp.Name descending select emp;
            //var emps = lstEmp.OrderByDescending(emp => emp.Name);


            //Both Ascending and Descending
            var emps = from emp in lstEmp orderby emp.DeptNo ascending, emp.Name descending select emp;
            // var emps = lstEmp.OrderBy(emp => emp.DeptNo).ThenByDescending(emp => emp.Name);


            //First the DeptNo is sorted in ascending order and then if the DeptNo are the same then in ascending of the Name

            foreach (var item in emps)
            {
                Console.WriteLine(item);

            }
        }

        static void Main4()
        {
            //Joining
            AddRecs();

            var emps = from emp in lstEmp join dept in lstDept on emp.DeptNo equals dept.DeptNo select emp;
            //basis for joining - emp.DeptNo equals dept.DeptNo
            //var emps = lstEmp.Join(lstDept, emp=>emp.DeptNo, dept=>dept.DeptNo, (emp,dept)=>emp);

            //var emps = lstEmp.Join(lstDept, emp=>emp.DeptNo, dept=>dept.DeptNo, (emp,dept)=>dept);

            //var emps = lstEmp.Join(lstDept, emp=>emp.DeptNo, dept=>dept.DeptNo, (emp,dept)=>emp.Name);


            //var emps = lstEmp.Join(lstDept, emp=>emp.DeptNo, dept=>dept.DeptNo, (emp,dept)=>dept.DeptName);


            var emps4 = lstEmp.Join(lstDept, emp=>emp.DeptNo, dept=>dept.DeptNo, (emp,dept)=> new { emp, dept});

            //var emps = lstEmp.Join(lstDept, emp=>emp.DeptNo, dept=>dept.DeptNo, (emp,dept)=> new { emp.Name, dept.DeptName});

            var emps1 = from emp in lstEmp join dept in lstDept on emp.DeptNo equals dept.DeptNo select dept;

            var emps2 = from emp in lstEmp join dept in lstDept on emp.DeptNo equals dept.DeptNo select new { emp, dept };


            var emps3 = from emp in lstEmp join dept in lstDept on emp.DeptNo equals dept.DeptNo select new { emp.Name, dept.DeptName };

            foreach (var item in emps4)
            {
                Console.WriteLine(item);
                //item.emp.
                //item.dept.

            }
            Console.WriteLine();
            foreach (var item in emps1)
            {
                Console.WriteLine(item);

            }

            Console.WriteLine();
            foreach (var item in emps2)
            {
                Console.WriteLine(item.emp.Name);
                Console.WriteLine(item.dept.DeptName);

            }

            Console.WriteLine();
            foreach (var item in emps3)
            {
                Console.WriteLine(item);
            }
        }
    }

    public class Department
    {
        public int DeptNo { get; set; }
        public string DeptName { get; set; }
    }

    public class Employee
    {
        public int EmpNo { get; set; }
        public string Name { get; set; }
        public decimal Basic { get; set; }
        public int DeptNo { get; set; }
        public string Gender { get; set; }

        public override string ToString()
        {
            string s = Name + "," + EmpNo.ToString() + "," + Basic.ToString() + "," + DeptNo.ToString() + "," + Gender;
            return s;
        }

    }

}
