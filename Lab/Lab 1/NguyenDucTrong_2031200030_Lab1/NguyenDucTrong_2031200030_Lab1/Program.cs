using System;

namespace NguyenDucTrong
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World");

            // The sum of two integer
            //Question3();

            // Swap two integer
            //Question4();

            // Determine the classification of a student's average score
            //Question5();

            // Print the corresponding month name
            //Question6();

            // Sum of all numbers from 1 to the a positive integer
            Question7();

        }

        static void Question3()
        {
            Console.WriteLine("Enter your first integer:");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter your second integer:");
            int b = Convert.ToInt32(Console.ReadLine());

            int resulf = SumOfTwoInteger(a, b);
            Console.WriteLine("The sum of two integer is: " + resulf);
        }

        static int SumOfTwoInteger(int a, int b)
        {
            return a + b;
        }

        static void Question4()
        {
            Console.WriteLine("Enter your first number to swap:");
            int a = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter your second number to swap:");
            int b = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Your number before swapping: a = " + a);
            Console.WriteLine("Your number before swapping: b = " + b);

            SwapTwoNumbers(a, b);
        }

        static void SwapTwoNumbers(int a, int b)
        {
            int swap = a;
            a = b;
            b = swap;

            Console.WriteLine("Your number after swapping: a = " + a);
            Console.WriteLine("Your number after swapping: b = " + b);
        }

        static void Question5()
        {
            Console.WriteLine("Enter the average score: ");
            int averageScore = Convert.ToInt32(Console.ReadLine());

            if (averageScore >= 90 && averageScore <= 100)
            {
                Console.WriteLine("Excellent");
            }
            else if (averageScore >= 80 && averageScore <= 89)
            {
                Console.WriteLine("Good");
            }
            else if (averageScore >= 70 && averageScore <= 79)
            {
                Console.WriteLine("Fair");
            }
            else
            {
                Console.WriteLine("Average");
            }

        }

        static void Question6()
        {
            Console.WriteLine("Enter your month: ");
            int month = Convert.ToInt32(Console.ReadLine());

            if (month <= 0 || month >= 12)
            {
                Console.WriteLine("The month input is invalid");
            }
            else
            {
                switch (month)
                {
                    case 1:
                        Console.WriteLine("January - Have 31 days.");
                        break;
                    case 2:
                        Console.WriteLine("February - Have 28 or 29 days.");
                        break;
                    case 3:
                        Console.WriteLine("March - Have 31 days.");
                        break;
                    case 4:
                        Console.WriteLine("April - Have 30 days.");
                        break;
                    case 5:
                        Console.WriteLine("May - Have 31 days.");
                        break;
                    case 6:
                        Console.WriteLine("June - Have 30 days.");
                        break;
                    case 7:
                        Console.WriteLine("July - Have 31 days.");
                        break;
                    case 8:
                        Console.WriteLine("August - Have 31 days.");
                        break;
                    case 9:
                        Console.WriteLine("September - Have 30 days.");
                        break;
                    case 10:
                        Console.WriteLine("October - Have 31 days.");
                        break;
                    case 11:
                        Console.WriteLine("November - Have 30 days.");
                        break;
                    case 12:
                        Console.WriteLine("December - Have 31 days.");
                        break;
                }
            }

        }

        static void Question7()
        {
            Console.WriteLine("Enter a positive number: ");
            int input = Convert.ToInt32(Console.ReadLine());

            if (input < 1)
            {
                Console.WriteLine("Your number is invalid");
            }
            else
            {
                int sum = 0;
                for (int i = 1; i <= input; i++)
                {
                    sum += i;
                }

                Console.WriteLine("The sum of all numbers from 1 to " + input + " is: " + sum);
            }
        }
    }
}