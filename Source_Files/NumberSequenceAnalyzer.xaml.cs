using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace SI_Decrypter
{
    public partial class NumberSequenceAnalyzer : ContentPage
    {
        public NumberSequenceAnalyzer()
        {
            InitializeComponent();

        }

        private void getEntry(object sender, EventArgs e)
        {
            string userIn = userInput.Text;
            userIn = userIn.Replace(" ", "");
            List<string> inputString = new List<string>();
            inputString = userIn.Split(',').ToList();

            //convert listitems fro. string to int before entering in array
            int listLen = inputString.Count;

            int[] inputArray = new int[listLen];
            int x = 0;

            foreach (string i in inputString)
            {
                inputArray[x] = Int32.Parse(i);
                x++;
            }
            /*
                        //set lvl 1 difference
                        int[] lvl1Array = new int[listLen - 1];

                        for (int i = 0; i < listLen - 1; i++)
                        {
                            //calculate the difference between two consequtive inputArray items
                            int j = i + 1;
                            int diff = inputArray[j] - inputArray[i];
                            lvl1Array[i] = diff;
                        }

                        //set lvl 2 difference
                        int[] lvl2Array = new int[listLen - 2];

                        for (int i = 0; i < listLen - 2; i++)
                        {
                            //calculate the difference between two consequtive inputArray items
                            int j = i + 1;
                            int diff = lvl1Array[j] - lvl1Array[i];
                            lvl2Array[i] = diff;
                        }
            */

            List<int> lvl1Diff = new List<int>();
            List<int> lvl2Diff = new List<int>();
            List<int> lvl3Diff = new List<int>();
            List<int> lvl4Diff = new List<int>();
            int y = listLen - 1;

            //step 1: loop over inputArray to get lvl1 difference
            for (int i = 0; i < y; i++)
            {
                int diff = System.Math.Abs(inputArray[i] - inputArray[i + 1]);
                lvl1Diff.Add(diff);
            }

            //step 2: loop over lvl1 to get lvl2 difference
            for (int i = 0; i < y - 1; i++)
            {
                int diff = System.Math.Abs(lvl1Diff[i] - lvl1Diff[i + 1]);
                lvl2Diff.Add(diff);
            }

            //step 3: loop over lvl2 to get lvl3 difference
            for (int i = 0; i < y - 2; i++)
            {
                int diff = System.Math.Abs(lvl2Diff[i] - lvl2Diff[i + 1]);
                lvl3Diff.Add(diff);
            }

            //step 4: loop over lvl3 to get lvl4 difference
            for (int i = 0; i < y - 3; i++)
            {
                int diff = System.Math.Abs(lvl3Diff[i] - lvl3Diff[i + 1]);
                lvl4Diff.Add(diff);
            }

            //fill output string
            StringBuilder outputString = new StringBuilder();

            for (int i = 0; i < listLen; i++)
            {
                string tabShort = "\t\t\t\t\t";
                string tabLong = "\t\t\t\t\t\t\t\t\t";
                if (i == 0)
                {
                    string tempOdd = tabShort + lvl1Diff[i] + "\n";
                    outputString.Append("" + inputArray[i] + "\n" + tempOdd);
                }
                else if (i == 1)
                {
                    string tempEven = "" + inputArray[i] + tabLong + lvl2Diff[i - 1] + "\n";
                    string tempOdd = tabShort + lvl1Diff[i] + tabLong + lvl3Diff[i - 1] + "\n";
                    outputString.Append(tempEven + tempOdd);
                }
                else if (i == 2)
                {
                    string tempEven = "" + inputArray[i] + tabLong + lvl2Diff[i - 1] + tabLong + lvl4Diff[i - 2] + "\n";
                    string tempOdd = tabShort + lvl1Diff[i] + tabLong + lvl3Diff[i - 1] + "\n";
                    outputString.Append(tempEven + tempOdd);
                }
                else if (i == listLen - 3)
                {
                    string tempEven = "" + inputArray[i] + tabLong + lvl2Diff[i - 1] + tabLong + lvl4Diff[i - 2] + "\n";
                    string tempOdd = tabShort + lvl1Diff[i] + tabLong + lvl3Diff[i - 1] + "\n";
                    outputString.Append(tempEven + tempOdd);
                }
                else if (i == listLen - 2)
                {
                    string tempEven = "" + inputArray[i] + tabLong + lvl2Diff[i - 1] + "\n";
                    string tempOdd = tabShort + lvl1Diff[i] + "\n";
                    outputString.Append(tempEven + tempOdd);
                }
                else if (i == listLen - 1)
                {
                    outputString.Append("" + inputArray[i]);
                }
                else
                {
                    string tempEven = "" + inputArray[i] + tabLong + lvl2Diff[i - 1] + tabLong + lvl4Diff[i - 2] + "\n";
                    string tempOdd = "tabShort" + lvl1Diff[i] + tabLong + lvl3Diff[i - 1] + "\n";
                    outputString.Append(tempEven + tempOdd);
                }
            }

            outputTxt.Text = outputString.ToString();

            /*foreach (int i in lvl4Diff)
            {
                System.Console.WriteLine(i);
            }*/


            //string exampleOutput = "0\t|\n\t\t\t>\t1\n1\t|\n\t\t\t>\t0\n1\t|";
            //outputTxt.Text = exampleOutput;
        }
    }
}