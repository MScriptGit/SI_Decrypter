# SI_Decrypter
Helpfull tool for use with crypto-puzzles and Geo-caching puzzles

Made with C# and .NET MAUI.


-rotate_bruteforce: A bruteforce rotation decrypter. It gives a bruteforce decryption of a text encrypted by the Ceasar cipher (also known as ROT13 or ROTX). It gives all 26 different rotations.
-CharCount: A character counter. It counts every letter, number, point, comma, question mark, etc. and gives a list of how many times it occurs in the entered text.
-wordLookupNL: A word lookup tool. Input a pattern by entering known letters and dots for unknown letters. It is made with a Dutch wordlist, but will work with other languages. Just add it to the Resources/Raw/txtFiles folder and change the filename in the project file
-WordPatternNL: Another word lookup tool. It works the same as wordLookupNL, but this time you can enter numbers for known pairs. So for APPLE you could enter A11.E, so the script knows that the second and third letters are the same. It works with multiple pairs too. So for APPLESAUCE you could enter 122L3.1..3  At this time this script too is only available in Dutch, but can be altered for other languages the same way as the previous.
-WordStartsWithNL: search a word that starts with the pattern you enter. Also in Dutch, but alterable like the previous scripts.
-WordEndsWithNL: search a word that ends with the pattern you enter. Also in Dutch, but alterable like the previous scripts.
-NumberSequenceAnalyzer: Analyzes a sequence of numbers to generate a list of numbers and the difference between them from 1 to 4 levels. Used to identify a pattern to determine the next number in the sequence
-ColumnarShift: A script made in JavaScript and HTML and shown in webview. Enter multiple words with the same length and the script generates a table of which you can shift each column up or down.
