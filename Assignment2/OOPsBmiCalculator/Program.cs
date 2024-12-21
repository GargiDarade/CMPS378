using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPsBmiCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            //create class object
            BmiCalculator objBMI = new BmiCalculator();
            //print table
            objBMI.printBMIRanges();
            //get input information from user.
            objBMI.getUserInformation();
            //calculate BMI
            double BMI = objBMI.calculateBMI();

            Console.WriteLine("Hi " + objBMI.Name + ",You are a " + objBMI.Gender + ".");
            Console.WriteLine("You are " + objBMI.Age + " years old. You are currently " + objBMI.HeightInFeets + " feet, " + objBMI.HeightInInches + " inches and you currently weight " + objBMI.Weight + " pounds.");
            Console.WriteLine("Your BMI is " + BMI.ToString("0.00") + ", which is " + objBMI.meaningOfBMI(BMI) + ".");
            Console.WriteLine("Thank you for using the BMI Calculator!");

            // Wait for the user to respond before closing.
            Console.WriteLine("");
            Console.Write("Press any key to close the Calculator console app...");
            Console.ReadKey();

        }
    }
}
