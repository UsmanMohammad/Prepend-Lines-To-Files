using System;
using System.IO;

namespace PrependLineToFile
{
    public class PrependLineToFile
    {
        public static void Main(string[] args)
        {
            const string directory = @"Add Directory";
            var files = System.IO.Directory.GetFiles(directory, "*", SearchOption.AllDirectories);
            for (var i = 0; i < files.Length; i++)
            {
                var file = files[i];
                PrependLine(file);
                Console.Title = $"{i} / {files.Length - 1} ";
            }
        }

        private static void PrependLine(string filePath)
        {
            const string lineToPrepend = "";
            using (var input = new StreamReader($"{filePath}"))
            using (var output = new StreamWriter($"{filePath}.temp"))
            {
                output.WriteLine($"{lineToPrepend}");

                output.Write(input.ReadToEnd());

                output.Flush();
                output.Close();
                input.Close();
            }

            //Replaces existing file with temp file. Existing file is renamed backup
            File.Replace($"{filePath}.temp", $"{filePath}", $"{filePath}.backup");
        }
    }
}

