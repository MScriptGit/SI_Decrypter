//Made by MScript 2025
using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace SI_Decrypter
{
    public partial class CharCount : ContentPage
    {
        public CharCount()
        {
            InitializeComponent();
        }
        private void getEntry(object sender, EventArgs e)
        {
            string userIn = userInput.Text;
            //change to all uppercase
            userIn = userIn.ToUpper();

            int totalChars = userIn.Length;

            //divide input into an array
            int[] inputArray = new int[totalChars];
            for (int i = 0; i < totalChars; i++)
            {
                int j = (int)userIn[i];
                inputArray[i] = j;
            }

            //make a hashset to get unique entries
            HashSet<int> getUniques = new HashSet<int>();

            foreach (int j in inputArray)
            {
                getUniques.Add(j);
            }

            //fill uniques array with unique values from hashset
            int uniquesLen = getUniques.Count;
            int[] uniquesArray = new int[uniquesLen];
            /*for (int i = 0; i < uniquesLen; i++)
            {
                uniquesArray[i] = getUniques[i];
            }*/
            int s = 0;
            foreach (int j in getUniques)
            {
                uniquesArray[s] = j;
                s++;
            }

            //sort ascending
            Array.Sort(uniquesArray);

            //set dictionairy for key-value pairs
            Dictionary<char, int> outputDict = new Dictionary<char, int>();

            //count occurences in array
            for (int i = 0; i < uniquesLen; i++)
            {
                int count = 0;
                foreach (int j in inputArray)
                {
                    if (j == uniquesArray[i])
                    {
                        count++;
                    }
                }
                char countKey = (char)uniquesArray[i];
                int countVal = count;
                outputDict.Add(countKey, countVal);
            }

            //set and fill output string
            string outputStr = "";

            foreach (KeyValuePair<char, int> entry in outputDict)
            {
                // do something with entry.Value or entry.Key
                outputStr = outputStr + entry.Key + " :\t" + entry.Value + "\n";
            }

            outputTxt.Text = outputStr;
        }
    }
}
