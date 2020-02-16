using System;
using System.IO;

namespace SummarizeTempsLab
{
    class Program
    { // temperature data is in temps.txt
        static void Main(string[] args)
        {
            Console.WriteLine("Hello User, Welcome to Summarize Temps");
            //wright out prompt to the console
            string filename;
            Console.WriteLine("Enter Filename");
            filename = Console.ReadLine();

            if (File.Exists(filename))
            {
                Console.WriteLine("File Exists");
                //Ask user to enter temp threshold
                Console.WriteLine("Enter the Temperature Threshold");
                string input;
                int threshold;
                input = Console.ReadLine();
                threshold = int.Parse(input);

                int test;
                int sumTemps = 0;
                int numabove = 0;
                int numbelow = 0;
                int tempCount = 0;

                using (StreamReader sr = File.OpenText(filename))
                {
                    string line = sr.ReadLine();
                    int temp;
                    while (line != null)
                    {
                        temp = int.Parse(line);
                        sumTemps += temp;

                        tempCount += 1;

                        if (temp >= threshold)
                        {
                            numabove += 1;
                        }
                        else
                        {
                            numbelow += 1;
                        }
                        line = sr.ReadLine();
                    }

                }
                Console.WriteLine("Temperatures Above = " + numabove);

                Console.WriteLine("Temperatures Below =" + numbelow);

                int average = sumTemps / tempCount;

                Console.WriteLine("Average Temperature =" + average);

                using (StreamWriter sw = new StreamWriter("output.txt"))
                {
                    sw.WriteLine(System.DateTime.Now.ToString());
                    sw.WriteLine("Temperatures above = " + numabove);
                    sw.WriteLine("Temperatures below = " + numbelow);
                    sw.WriteLine("Average Temperature" + average);

                }
            }
            else
            {
                Console.WriteLine("File does not exist");
            }
        }
    }
}
