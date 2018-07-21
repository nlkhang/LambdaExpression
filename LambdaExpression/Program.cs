using System;

namespace LambdaExpression
{
    // declard delegate
    delegate void SalaryChanged(Employee sender, double salary);

    class Employee
    {
        // declard event
        private event SalaryChanged _salaryChanged;
        public event SalaryChanged SalaryChanged
        {
            add
            {
                _salaryChanged += value;
            }
            remove
            {
                _salaryChanged -= value;
            }
        }

        private double _salary;
        public double Salary
        {
            get
            {
                return _salary;
            }
            set
            {
                _salary = value;

                _salaryChanged(this, _salary);
            }
        }

        public override string ToString()
        {
            return Salary.ToString(); 
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var employee = new Employee();

            // C# 1.0 Call a function
            employee.SalaryChanged += Employee_SalaryChanged;

            // C# 2.0 Anonymous Method
            employee.SalaryChanged += delegate (Employee sender, double salary)
            {
                Console.WriteLine($"C# 2.0 Anonymous Method: {sender.ToString()}");
            };

            // C# 3.0 Lambda Expression
            employee.SalaryChanged += (sender, salary) => Console.WriteLine($"C# 3.0 Lambda Expression: {sender.ToString()}");

            employee.Salary = 1000;
            employee.Salary = 1200;

            Console.ReadLine();
        }

        /// <summary>
        /// // C# 1.0 Call a function
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="salary"></param>
        private static void Employee_SalaryChanged(Employee sender, double salary)
        {
            Console.WriteLine($"C# 1.0 Call a function: {sender.ToString()}");
        }
    }
}
