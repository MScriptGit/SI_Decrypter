using System.IO;
using Microsoft.Maui.Storage;
using Android.Content.Res;

public class FileHelper
{
    public static void CopyFileToAppData()
    {
        var assets = Android.App.Application.Context.Assets;
        using (var stream = assets.Open("wordlistOpenTaalDutchComplete2-20-23.txt"))
        {
            //var destinationPath = Path.Combine(FileSystem.Current.AppDataDirectory, "OpenTaal-210G-basis-gekeurd.txt");
            var destinationPath = Path.Combine(FileSystem.Current.AppDataDirectory, "wordlistOpenTaalDutchComplete2-20-23.txt");

            using (var fileStream = File.Create(destinationPath))
            {
                stream.CopyTo(fileStream);
            }
        }
    }
}


/*using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Maui.Storage;

namespace App_setup;

public class FileHelper
{
    public static void CopyFileToAppData()
    {
        // Pad naar het bronbestand (dit wordt gekopieerd tijdens build)
        var sourceFile = Path.Combine(FileSystem.Current.AppPackageDirectory, "Raw/txtFiles/OpenTaal-210G-basis-gekeurd.txt");

        // Doelmap (in de app-specifieke data directory)
        var destinationPath = Path.Combine(FileSystem.Current.AppDataDirectory, "Raw/txtFiles/OpenTaal-210G-basis-gekeurd.txt");

        // Bestand kopiëren
        if (File.Exists(sourceFile))
        {
            File.Copy(sourceFile, destinationPath, true);
        }
    }
}*/
