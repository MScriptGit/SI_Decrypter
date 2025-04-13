using System;
using System.IO;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Shapes;

namespace SI_Decrypter
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void BruteforceRotationDecrypter(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///rotate_bruteforce");
        }
        private async void CharacterCounter(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///CharCount");
        }
        private async void WordLookup(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///wordLookupNL");
        }
        private async void WordPatternLookup(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///WordPatternNL");
        }
        private async void WordStartsWith(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///WordStartsWithNL");
        }
        private async void WordEndsWith(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///WordEndsWithNL");
        }
        private async void NumberSequenceAnalyzer(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///NumberSequenceAnalyzer");
        }
        private async void ColumnarShift(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("///ColumnarShift");
        }
    }
}