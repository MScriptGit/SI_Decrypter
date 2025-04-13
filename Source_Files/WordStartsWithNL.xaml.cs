//Made by MScript 2025
using System;
using System.IO;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using System.Text.RegularExpressions;
using System.Reflection;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Storage;
using Android.Content.Res;

namespace SI_Decrypter
{
    public partial class WordStartsWithNL : ContentPage
    {
        public WordStartsWithNL()
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
            string pattern = @"^" + inputText + "";
            int counter = 0;
            string finalOutput;
            StringBuilder outputText = new StringBuilder();

            // Instantiate the regular expression object.
            Regex r = new Regex(pattern, RegexOptions.IgnoreCase);

            try
            {
                EnsureResourceCopied("wordlistOpenTaalDutchComplete2-20-23.txt", "wordlistOpenTaalDutchComplete2-20-23.txt");
                //next line is var for testing purposes
                //string wordFile = "Resources/Raw/txtFiles/OpenTaal-210G-basis-gekeurd.txt";
                var wordFile = Path.Combine(FileSystem.Current.AppDataDirectory, "wordlistOpenTaalDutchComplete2-20-23.txt");
                // Create a StreamReader
                using (StreamReader reader = new StreamReader(wordFile))
                {
                    string line;
                    // Read line by line
                    while ((line = reader.ReadLine()) != null)
                    {
                        Match m = r.Match(line);

                        if (m.Success)
                        {
                            outputText.Append(line + "\n");
                            counter++;
                        }
                    }

                    finalOutput = "Number of hits: " + counter + "\n\n" + outputText.ToString();
                    outputTxt.Text = finalOutput;
                }
            }
            catch (Exception exp)
            {
                Console.WriteLine(exp.Message);
            }
        }
    }
}
