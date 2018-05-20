using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommonTasksDLL;

namespace Ch6_Program3
{
    class Ch6_Program3 : CT
    {
        //DONT FORGET TO ADD COMMENTS
        static void Main(string[] args)
        {
            Header(out CT.LengthOfTopLine, "Ch.6 Program 3",
                "to use loops and collections for finding the average test scores");

            List<double> Numbers = new List<double>();

            bool flag = true;
            do
            {
                Numbers.Add(AskUserForDouble("a test score", ref flag));
            }
            while (flag);

            Numbers.Remove(-911);
            double average = Numbers.Average();
            char letterGrade = CalcLetterGrade(average);
            
            CT.Color("magenta");
            Console.WriteLine("\nThe average score of the tests is: {0}."
                +"\nThe letter grade associated with the score is: {1}", average, letterGrade);

            CT.Footer();
        }

        public static double AskUserForDouble(string x, ref bool flag)
        {
            Console.Write("\nPlease enter {0} ", x);
            CT.Color("Green");
            var input = Console.ReadLine();
            for (int i = 0; i < 1; i++)
            {
                try
                {
                    double.Parse(input);
                }
                catch (FormatException)
                {
                    CT.Color("red");
                    Console.WriteLine("\nYOU GOOBER ---> FOLLOW DIRECTIONS");
                    CT.Color("white");
                    Console.Write("\nPlease enter {0} ", x);
                    CT.Color("green");
                    input = Console.ReadLine();
                    i--;
                }
            }
            Color("white");
            double convertInput = Convert.ToDouble(input);
            
            if (convertInput == -911)
                flag = false;
            else if (convertInput < 0 || convertInput > 100)
            {
                AskUserForDouble("a VALID test score", ref flag);
            }
            else
            {
                CT.Color("red");
                Console.Write("To exit please enter \"-911\"\n");
            }
            CT.Color("WHITE");
            return convertInput;
        }

        public static char CalcLetterGrade(double average)
        {
            int x = Convert.ToInt32(average);
            char letterGrade;
            if (x < 60)
                letterGrade = 'F';
            else if (x < 70)
                letterGrade = 'D';
            else if (x < 80)
                letterGrade = 'C';
            else if (x < 90)
                letterGrade = 'B';
            else if (x < 100)
                letterGrade = 'A';
            else
                letterGrade = '?';
            return letterGrade;
        }

        
    }
}
