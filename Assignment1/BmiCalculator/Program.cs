using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BmiCalculator
{
    internal class Program
    {
        //function to print MBI Ranges

        static void printBMIRanges()
        {
            //display BMI Ranges

            Console.WriteLine("");
            Console.WriteLine("---------------BMI Calculator----------------");
            Console.WriteLine("| Category             | BMI Range(kg / m2) |");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("| Severe Thinness      | < 16               |");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("| Moderate Thinness    | 16 - 17            |");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("| Mild Thinness        | 17 - 18.5          |");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("| Normal               | 18.5 - 25          |");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("| Overweight           | 25 - 30            |");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("| Obese Class I        | 30 - 35            |");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("| Obese Class II       | 35 - 40            |");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("| Obese Class III      | > 40               |");
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("      Welcome to BMI Calculator!             ");
        }

        //function to map meaning of BMI 
        static string meaningOfBMI(double bmi)
        {
            string category="";
            if (bmi < 16)
            {
                category = "Severe Thinness";
            }
            else if (bmi >= 16 && bmi < 17)
            {
                category = "Moderate Thinness";
            }
            else if (bmi >= 17 && bmi < 18.5)
            {
                category = "Mild Thinness";
            }
            else if (bmi >= 18.5 && bmi < 25)
            {
                category = "Normal";
            }
            else if (bmi >= 25 && bmi < 30)
            {
                category = "Overweight";
            }
            else if (bmi >= 30 && bmi < 35)
            {
                category = "Obese Class I";
            }
            else if (bmi >= 35 && bmi < 40)
            {
                category = "Obese Class II";
            }
            else if (bmi >= 40)
            {
                category = "Obese Class III";
            }
            return category;
        }
        static void Main(string[] args)
        {
            //vars to get info from user
            string name, gender;
            int age;
            double weight, heightInFeets, heightInInches, totalHeightInInches, BMI;

            printBMIRanges();
            Console.Write("\nPlease enter your name: ");
            name= Console.ReadLine();
            Console.Write("\nPlease enter your age: ");
            age=Convert.ToInt32(Console.ReadLine());
            Console.Write("\nPlease enter your Gender: ");
            gender = Console.ReadLine(); 
            Console.Write("\nPlease enter your height in feet: ");
            heightInFeets = Convert.ToDouble(Console.ReadLine());
            Console.Write("\nPlease enter your height in inches: ");
            heightInInches = Convert.ToDouble(Console.ReadLine());
            Console.Write("\nPlease enter your weight in pounds: ");
            weight = Convert.ToDouble(Console.ReadLine());
            //calculate BMI
            totalHeightInInches = heightInFeets * 12 + heightInInches;
            BMI = 703 * (weight / (totalHeightInInches * totalHeightInInches));
            Console.WriteLine();
            Console.WriteLine("Hi " + name + ",You are a " + gender + ".");
            Console.WriteLine("You are " + age + " years old. You are currently " + heightInFeets+ " feet, " + heightInInches + " inches and you currently weight " + weight + " pounds.");
            
            Console.WriteLine("Your BMI is " + BMI.ToString("0.00") + ", which is " + meaningOfBMI(BMI) + ".");
            Console.WriteLine("Thank you for using the BMI Calculator!");


            // Wait for the user to respond before closing.
            Console.WriteLine("");
            Console.Write("Press any key to close the Calculator console app...");
            Console.ReadKey();
        }
    }
}
