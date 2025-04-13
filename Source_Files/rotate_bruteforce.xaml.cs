//Made by MScript 2025
using System;
using System.IO;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace SI_Decrypter
{
    public partial class rotate_bruteforce : ContentPage
    {
        public rotate_bruteforce()
        {
            InitializeComponent();

        }
        private void getEntry(object sender, EventArgs e)
        {
            string userIn = userInput.Text;
            //change to all uppercase
            userIn = userIn.ToUpper();

            int inputLen = userIn.Length;

            //set arrays and temporary output string
            char[] charArray = new char[inputLen];
            int[] intArray = new int[inputLen];
            string tempOutput = "";
            char[] tempCharOutput = new char[inputLen];
            string[] outputArray = new string[26];
            string finalOutput = "";

            //fill first array with chars from input
            for (int i = 0; i < inputLen; i++)
            {
                char j = userIn[i];
                charArray[i] = j;
            }

            //fill second array with the ASCII value of the first array's entries
            //skip the entries if it's not a letter, but preserve spaces!
            for (int i = 0; i < inputLen; i++)
            {
                int j = (int)charArray[i];
                intArray[i] = j;
            }

            //fill outputArray with all 26 rotations of the string
            int x = 0;
            while (x < 26)
            {
                for (int i = 0; i < inputLen; i++)
                {
                    if (intArray[i] > 64 && intArray[i] < 91)
                    {
                        intArray[i] = intArray[i] + 1;
                        if (intArray[i] > 90)
                        {
                            intArray[i] = intArray[i] - 26;
                        }
                        tempCharOutput[i] = (char)intArray[i];
                    }
                    if (intArray[i] == 32)
                    {
                        tempCharOutput[i] = (char)intArray[i];
                    }
                }
                int h = 0;
                foreach (int s in intArray)
                {
                    tempOutput = string.Concat(tempOutput, tempCharOutput[h]);
                    h++;
                }
                int y = x + 1;
                string z = "";
                if (y < 10)
                {
                    z = "0" + y;
                }
                else
                {
                    z = "" + y + "";
                }
                outputArray[x] = "" + z + ": " + tempOutput;
                x++;
                tempOutput = "";
            }

            //fill final output string
            foreach (string s in outputArray)
            {
                finalOutput = finalOutput + s + "\n";
            }

            outputTxt.Text = finalOutput;
        }
    }
}
