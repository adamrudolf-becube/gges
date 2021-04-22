﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Data;
using System.IO;

namespace fileProcess
{
    // Class reads a list of users with degrees and generates a heatmap in degree space
    class UserListToHeatMap
    {
        public string lineToTuple(System.IO.StreamReader reader, string line)
        {
            string result;
            Regex anySpaces = new Regex("[ ]+"); // One or more spaces as separator
            string line_ = line; // Temporary container
            string[] arrWords = new string[3]; // The container of split line
            int proba = -1; // The two int values. -1 is invalid: we seek for lines until we find valid pair
            if (line_ != null)
            {
                while (proba == -1) // Do it until we find a valid pair
                {
                    try // If we can convert, do it
                    {
                        arrWords = anySpaces.Split(line_);
                        proba = Convert.ToInt32(arrWords[0].ToString().Trim());
                    }
                    catch (Exception e) // If we can't, read the next line instead
                    {
                        if ((line_ = reader.ReadLine()) == null)
                        {
                            arrWords = new string[1];
                            arrWords[0] = " ";
                            return string.Join(" ", arrWords);
                        }
                    }
                }
            }
            result = string.Join(" ", arrWords);
            return result;
        }

        public void run(string filename)
        {
            StreamReader testFile = new StreamReader(@"\\QSO\Public\rudolf\My Documents\degree_correlation.txt");
            StreamWriter outFile = new StreamWriter(@"\\QSO\Public\rudolf\My Documents\heatmap.txt");
            string line;
            string temp1;
            int counter = 0;

            while ((line = testFile.ReadLine()) != null)
            {
                temp1 = lineToTuple(testFile, line);
                Console.WriteLine(temp1 + "\t{0}", (counter + 1));
                outFile.WriteLine(temp1);
                counter++;
            }

            testFile.Close();
            outFile.Close();
            System.Console.WriteLine("There were {0} lines.", counter);
            // Suspend the screen.
            System.Console.ReadLine();
        }
    }
}
