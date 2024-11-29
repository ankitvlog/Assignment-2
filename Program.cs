using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assignment2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Assignment-2");
            Console.ReadLine();

            Console.WriteLine("Question 1 Solution");
            A2Q1 a2Q1 = new A2Q1();
            a2Q1.ShoppingCart();
            Console.ReadLine();

            Console.WriteLine("Question 2 Solution");
            A2Q2 a2Q2 = new A2Q2();
            a2Q2.TemperatureConverter();
            Console.ReadLine();

            Console.WriteLine("Question 3 Solution");
            A2Q3 a2Q3 = new A2Q3();
            a2Q3.SimpleATM();
            Console.ReadLine();

            Console.WriteLine("Question 4 Solution");
            A2Q4 a2Q4 = new A2Q4();
            a2Q4.AverageMarks();
            Console.ReadLine();

            Console.WriteLine("Question 5 Solution");
            A2Q5 a2Q5 = new A2Q5();
            a2Q5.PasswordValid();
            Console.ReadLine();

            Console.WriteLine("Question 6 Solution");
            A2Q6 a2Q6 = new A2Q6();
            a2Q6.TaxiRide();
            Console.ReadLine();

            Console.WriteLine("Question 7 Solution");
            A2Q7 a2Q7 = new A2Q7();
            a2Q7.Attendance();
            Console.ReadLine();

            Console.WriteLine("Question 8 Solution");
            A2Q8 a2Q8 = new A2Q8();
            a2Q8.Month();
            Console.ReadLine();

            Console.WriteLine("Question 9 Solution");
            A2Q9 a2Q9 = new A2Q9();
            a2Q9.AddItem("Apple", 10.50m);
            a2Q9.AddItem("Banana", 5.75m);
            a2Q9.ViewCart();

            a2Q9.RemoveItem("Banana");
            a2Q9.ViewCart();

            a2Q9.AddItem("Orange", 7.25m);
            a2Q9.ViewCart();
            Console.ReadLine();

            Console.WriteLine("Question 10 Solution");
            A2Q10 a2Q10 = new A2Q10();
            a2Q10.Salary();
            Console.ReadLine();
        }
    }

    class A2Q1
    {
        public void ShoppingCart()
        {
            double[] prices = { 1200.50, 850.00, 1250.75, 600.30, 450.00 };
            double totalPrice = 0;

            foreach (double price in prices)
            {
                totalPrice += price;
            }
            if (totalPrice > 3000)
            {
                double discount = totalPrice * 0.10;
                totalPrice -= discount;
                Console.WriteLine($"After 10% discount Price is {discount}");
            }
            Console.WriteLine($"Total price of item {totalPrice}");
        }
    }


    class A2Q2
    {
        public void TemperatureConverter()
        {
            Console.Write("Enter the temperature in Celsius: ");
            string input = Console.ReadLine();

            if (double.TryParse(input, out double celsius))
            {
                double fahrenheit = (celsius * 9 / 5) + 32;
                Console.WriteLine($"Temperature {fahrenheit}°F");

                if (celsius < 0)
                {
                    Console.WriteLine("Below freezing point");
                }
            }
            else
            {
                Console.WriteLine("Enter a valid number.");
            }
        }
    }


    class A2Q3
    {
        public void SimpleATM()
        {
            double balance = 1000.00;
            int choice;

            do
            {
                Console.WriteLine("Check Balance press 1");
                Console.WriteLine("Deposit Money press 2");
                Console.WriteLine("Withdraw Money press 3");
                Console.WriteLine("Exit press 4");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine($"Your current balance is: Rs. {balance}");
                        break;

                    case 2:
                        Console.Write("Enter the amount to deposit: Rs. ");
                        double depositAmount = double.Parse(Console.ReadLine());
                        if (depositAmount > 0)
                        {
                            balance += depositAmount;
                            Console.WriteLine($"Rs.{depositAmount} deposited New balance is {balance}");
                        }
                        else
                        {
                            Console.WriteLine("Invalid! amount must be greater than zero.");
                        }
                        break;

                    case 3:
                        Console.Write("Enter withdraw amount ");
                        double withdrawAmount = double.Parse(Console.ReadLine());
                        if (withdrawAmount > 0)
                        {
                            if (withdrawAmount <= balance)
                            {
                                balance -= withdrawAmount;
                                Console.WriteLine($"Rs. {withdrawAmount} withdrawn New balance Rs. {balance}");
                            }
                            else
                            {
                                Console.WriteLine("Insufficient Balance");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid! Withdrawal amount greater than zero.");
                        }
                        break;

                    case 4:
                        Console.WriteLine("Thanks For visit Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Please choose valid option");
                        break;
                }

            } while (choice != 4);
        }
    }


    class A2Q4
    {
        public void AverageMarks()
        {
            int[] marks = new int[5];
            int totalMarks = 0;

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Enter the marks {i + 1}: ");
                marks[i] = int.Parse(Console.ReadLine());
                totalMarks += marks[i];
            }
            double average = totalMarks / 5.0;
            char grade;
            if (average >= 90)
            {
                grade = 'A';
            }
            else if (average >= 80)
            {
                grade = 'B';
            }
            else if (average >= 70)
            {
                grade = 'C';
            }
            else if (average >= 60)
            {
                grade = 'D';
            }
            else
            {
                grade = 'F';
            }
            Console.WriteLine($"Average Marks {average}");
            Console.WriteLine($"Grade {grade}");
        }
    }


    class A2Q5
    {
        public void PasswordValid()
        {
            Console.Write("Enter password ");
            string password = Console.ReadLine();

            if (IsValidPassword(password))
            {
                Console.WriteLine("Password is valid");
            }
            else
            {
                Console.WriteLine("Password invalid! make sure that the password least 8 characters at least one uppercase letter, one lowercase letter, and one number.");
            }
        }

        static bool IsValidPassword(string password)
        {
            if (password.Length < 8)
            {
                return false;
            }

            bool hasUpperCase = Regex.IsMatch(password, @"[A-Z]");
            bool hasLowerCase = Regex.IsMatch(password, @"[a-z]");
            bool hasNumber = Regex.IsMatch(password, @"[0-9]");

            return hasUpperCase && hasLowerCase && hasNumber;
        }
    }


    class A2Q6
    {
        public void TaxiRide()
        {
            const double baseFare = 20.0;
            const double additionalFarePerKm = 10.0;
            const int initialDistance = 2;
            const double nightSurchargeRate = 1.2;

            Console.Write("Enter distance traveled km");
            double distance = double.Parse(Console.ReadLine());

            Console.Write("Enter time of travel in 24-hour format ");
            int hour = int.Parse(Console.ReadLine());

            double fare = baseFare;

            if (distance > initialDistance)
            {
                fare += (distance - initialDistance) * additionalFarePerKm;
            }
            if (hour >= 22)
            {
                fare *= nightSurchargeRate;
            }
            Console.WriteLine($"The total fare taxi ride is {fare:F2}");
        }
    }
    class A2Q7
    {
        public void Attendance()
        {
            Dictionary<string, bool[]> attendanceRecords = new Dictionary<string, bool[]>();

            attendanceRecords["A"] = new bool[] { true, true, true, true, true };
            attendanceRecords["B"] = new bool[] { true, false, true, true, true };
            attendanceRecords["C"] = new bool[] { true, true, true, true, true };

            foreach (var student in attendanceRecords)
            {
                string name = student.Key;
                bool[] attendance = student.Value;

                int totalDaysAttended = 0;
                foreach (bool attended in attendance)
                {
                    if (attended)
                    {
                        totalDaysAttended++;
                    }
                }

                bool hasPerfectAttendance = totalDaysAttended == 5;

                Console.WriteLine($"Student: {name}");
                Console.WriteLine($"Total Days Attended: {totalDaysAttended}");
                Console.WriteLine($"Perfect Attendance: {hasPerfectAttendance}");
                Console.WriteLine();
            }
        }
    }
    class A2Q8
    {
        public void Month()
        {
            double[] expenses = new double[12];
            string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

            for (int i = 0; i < 12; i++)
            {
                Console.Write($"Enter the expenses {months[i]}");
                expenses[i] = double.Parse(Console.ReadLine());
            }

            double totalExpenses = 0;
            for (int i = 0; i < 12; i++)
            {
                totalExpenses += expenses[i];
            }
            double highestExpense = expenses[0];
            double lowestExpense = expenses[0];
            int highestMonthIndex = 0;
            int lowestMonthIndex = 0;

            for (int i = 1; i < 12; i++)
            {
                if (expenses[i] > highestExpense)
                {
                    highestExpense = expenses[i];
                    highestMonthIndex = i;
                }
                if (expenses[i] < lowestExpense)
                {
                    lowestExpense = expenses[i];
                    lowestMonthIndex = i;
                }
            }
            Console.WriteLine($"Total expenses of year {totalExpenses:F2}");
            Console.WriteLine($"Highest expenses {months[highestMonthIndex]} Rs. {highestExpense:F2}");
            Console.WriteLine($"Lowest expenses {months[lowestMonthIndex]} Rs. {lowestExpense:F2}");
        }
    }
    class A2Q9
    {
        private Dictionary <string, decimal> items = new Dictionary <string, decimal>();
        public void AddItem(string name, decimal price)
        {
            if (items.ContainsKey(name))
            {
                Console.WriteLine($"Item {name} is already");
            }
            else
            {
                items[name] = price;
                Console.WriteLine($"Added {name} to the cart.");
            }
        }

        public void RemoveItem(string name)
        {
            if (items.Remove(name))
            {
                Console.WriteLine($"Removed {name}");
            }
            else
            {
                Console.WriteLine($"Item {name} not found");
            }
        }
        public decimal CalculateTotalPrice()
        {
            decimal total = 0;
            foreach (var price in items.Values)
            {
                total += price;
            }
            return total;
        }
        public void ViewCart()
        {
            if (items.Count == 0)
            {
                Console.WriteLine("Cart is empty.");
            }
            else
            {
                Console.WriteLine("Items in the cart");
                foreach (var item in items)
                {
                    Console.WriteLine($"{item.Key}: Rs. {item.Value}");
                }
                Console.WriteLine($"Total Price Rs. {CalculateTotalPrice()}");
            }
        }
    }
    class A2Q10
    {
        public void Salary()
        {
            try
            {
                Console.Write("Enter the hourly wage: ");
                double hourlyWage = Convert.ToDouble(Console.ReadLine());

                Console.Write("Enter the number of hours worked in a week");
                double hoursWorkedPerWeek = Convert.ToDouble(Console.ReadLine());

                double weeklySalary = hourlyWage * hoursWorkedPerWeek;
                double monthlySalary = weeklySalary * 4;

                Console.WriteLine($"Monthly salary Rs.{ monthlySalary}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Please enter a valid number.");
            }
        }
    }
}
