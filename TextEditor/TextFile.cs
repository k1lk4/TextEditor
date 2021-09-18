using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace TextEditor
{
    class TextFile
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0063:Использовать простой оператор using", Justification = "<Ожидание>")]
        public static void ReadFile(string filePath, ref TextBox text, string fileName = "text.txt")
        {

            DirectoryInfo filesDirectoryInfo = new(filePath);

            if (!filesDirectoryInfo.Exists)
            {
                MessageBox.Show("Директория с файлом, который вы пытаетесь открыть, не существует!");
            }

            using (FileStream readFile = File.OpenRead(filePath + fileName))
            {

                byte[] userFileTextBytes = new byte[readFile.Length];

                readFile.Read(userFileTextBytes, 0, userFileTextBytes.Length);

                string textFromFile = Encoding.Default.GetString(userFileTextBytes);

                text.Text = textFromFile;

            }
        }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0063:Использовать простой оператор using", Justification = "<Ожидание>")]
        public static void WriteFile(string filePath, ref TextBox text, string fileName = "text.txt")
        {
            DirectoryInfo filesDirectoryInfo = new(filePath);

            if (!filesDirectoryInfo.Exists)
            {
                filesDirectoryInfo.Create();
            }

            using (FileStream writeFile = File.OpenWrite(filePath + fileName))
            {
                byte[] userEditorTextBytes = Encoding.Default.GetBytes(text.Text);

                writeFile.Write(userEditorTextBytes, 0, userEditorTextBytes.Length);
            }
        }
    }
}
