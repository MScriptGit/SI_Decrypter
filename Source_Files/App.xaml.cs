using System;
using System.IO;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace SI_Decrypter
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // Roep de method aan om het bestand te kopiëren
            //FileHelper.CopyFileToAppData();

            MainPage = new AppShell();
        }
    }
}