using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OOPsBmiCalculator
{
    class BmiCalculator
    {
        //vars to get info from user
        string name; //field
        string gender;
        int age;
        double weight, heightInFeets, heightInInches;

        //properties with get set methodes
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string Gender
        {
            get { return gender; }
            set { gender = value; }
        }
        public int Age
        {
            get { return age; }
            set { age = value; }
        }
        public double Weight
        {
            get { return weight; }
            set { weight = value; }
        }
        public double HeightInFeets
        {
            get { return heightInFeets; }
            set { heightInFeets = value; }
        }
        public double HeightInInches
        {
            get { return heightInInches; }
            set { heightInInches = value; }
        }
        //default constructor
        public BmiCalculator()
        {
            //constructor is used to initialize variables
            Name="";
            Gender="";
            Age=0;
            Weight=0;
            HeightInFeets=0;
            HeightInInches=0;
        }
        //Method to get user information
        public void getUserInformation()
        {
            //printBMIRanges();
            Console.Write("\nPlease enter your name: ");
            Name = Console.ReadLine();
            Console.Write("\nPlease enter your age: ");
            Age = Convert.ToInt32(Console.ReadLine());
            Console.Write("\nPlease enter your Gender: ");
            Gender = Console.ReadLine();
            Console.Write("\nPlease enter your height in feet: ");
            HeightInFeets = Convert.ToDouble(Console.ReadLine());
            Console.Write("\nPlease enter your height in inches: ");
            HeightInInches = Convert.ToDouble(Console.ReadLine());
            Console.Write("\nPlease enter your weight in pounds: ");
            Weight = Convert.ToDouble(Console.ReadLine());
        }
        //Method to calculate BMI
        public double calculateBMI()
        {
            double totalHeightInInches, BMI;
            totalHeightInInches = HeightInFeets * 12 + HeightInInches;
            BMI = 703 * (Weight / (totalHeightInInches * totalHeightInInches));
            return BMI;
        }
        //Method to print MBI Ranges
        public void printBMIRanges()
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
        //Method to map meaning of BMI 
        public string meaningOfBMI(double bmi)
        {
            string category = "";
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
    }
}
