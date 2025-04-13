using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Text.RegularExpressions;
using System.Linq;
using System.Reflection;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using Android.Content.Res;
using Java.Util;

namespace SI_Decrypter
{
    public partial class WordPatternNL : ContentPage
    {
        public WordPatternNL()
        {
            InitializeComponent();

        }

        public void EnsureResourceCopied(string resourceFilename, string destinationFilename)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = $"{assembly.GetName().Name}.Resources.Raw.txtFiles.{resourceFilename}";
            string destinationPath = Path.Combine(FileSystem.Current.AppDataDirectory, destinationFilename);

            // Controleer of het bestand al bestaat in de AppDataDirectory
            if (!File.Exists(destinationPath))
            {
                using (Stream resourceStream = assembly.GetManifestResourceStream(resourceName))
                {
                    if (resourceStream != null)
                    {
                        using (FileStream fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
                        {
                            resourceStream.CopyTo(fileStream);
                        }
                    }
                    else
                    {
                        throw new FileNotFoundException($"Resource '{resourceName}' not found.");
                    }
                }
            }
        }


        private void getEntry(object sender, EventArgs e)
        {
            string inputText = userInput.Text;
            int inputLen = inputText.Length;
            //var inputAL = new ArrayList();
            var numbersList = new List<string>();
            var positionList = new List<string>();
            StringBuilder tempStr = new StringBuilder();
            //search input for numbers
            for (int i = 0; i < inputLen; i++)
            {
                char c = inputText[i];
                if (Char.IsNumber(c))
                {
                    numbersList.Add(c.ToString());
                    positionList.Add(i.ToString());
                    tempStr.Append(".");
                }
                else
                {
                    tempStr.Append(c);
                }
            }
            int numListLen = numbersList.Count;

            string pattern = @"^" + tempStr + "$";
            StringBuilder outputText = new StringBuilder();

            // Instantiate the regular expression object.
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase);

            try
            {
                //EnsureResourceCopied("wordlistOpenTaalDutchComplete2-20-23.txt", "wordlistOpenTaalDutchComplete2-20-23.txt");
                //next line is var for testing purposes
                string wordFile = "Resources/Raw/txtFiles/OpenTaal-210G-basis-gekeurd.txt";
                //!!!!comment line above before release!!!
                //!!!!uncomment line below before release!!!!
                //var wordFile = Path.Combine(FileSystem.Current.AppDataDirectory, "wordlistOpenTaalDutchComplete2-20-23.txt");
                // Create a StreamReader
                using (StreamReader reader = new StreamReader(wordFile))
                {
                    string line;
                    // Read line by line
                    while ((line = reader.ReadLine()) != null)
                    {
                        int lineLen = line.Length;
                        bool lenMatch = lineLen == inputLen;
                        if (lenMatch)
                        {
                            Match m = r.Match(line);

                            if (m.Success)
                            {
                                //check if input had numbers. If not: output found word directly
                                if (numListLen != 0)
                                {
                                    bool hasDuplicates = numbersList.GroupBy(x => x).Any(g => g.Count() > 1);
                                    bool numPatternMatch = false;
                                    //check if there are duplicate numbers
                                    if (hasDuplicates)
                                    {
                                        foreach (string i in numbersList)
                                        {
                                            char j = i[0];

                                            //get index of every number and put them in a list
                                            List<int> indices = inputText
                                                .Select((c, index) => new { Character = c, Index = index })
                                                .Where(x => x.Character == j)
                                                .Select(x => x.Index)
                                                .ToList();

                                            // Select characters at the specified indices
                                            var characters = indices.Select(index => line[index]);

                                            // Check if all characters are the same
                                            bool tempMatch = characters.Distinct().Count() == 1;

                                            if (!tempMatch)
                                            {
                                                numPatternMatch = false;
                                                break;
                                            }
                                            else
                                            {
                                                numPatternMatch = true;
                                            }
                                        }
                                        if (numPatternMatch)
                                        {
                                            outputText.Append(line + "\n");
                                        }
                                    }
                                    else
                                    {
                                        outputText.Append(line + "\n");
                                    }
                                }
                                else
                                {
                                    outputText.Append(line + "\n");
                                }
                            }
                        }
                    }
                    outputTxt.Text = outputText.ToString();
                }

            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
                outputTxt.Text = exp.Message;
            }
        }
    }
}