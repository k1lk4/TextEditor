using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TextEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void SubmitText_Click(object sender, RoutedEventArgs e)
        {
            string filePath = @"C:\TextEditor\";
            string fileName = "text.txt";

            DirectoryInfo filesDirectoryInfo = new(filePath);

            if (!filesDirectoryInfo.Exists)
            {
                filesDirectoryInfo.Create();
            }

            FileStream writeFile = File.OpenWrite(filePath + fileName);
            byte[] userEditorTextBytes = Encoding.Default.GetBytes(Text.Text);

            writeFile.Write(userEditorTextBytes, 0, userEditorTextBytes.Length);

            writeFile.Dispose();

            FileStream readFile = File.OpenRead(filePath + fileName);

            byte[] userFileTextBytes = new byte[readFile.Length];

            readFile.Read(userFileTextBytes, 0, userFileTextBytes.Length);

            string textFromFile = Encoding.Default.GetString(userFileTextBytes);

            Text.Text = textFromFile;
        }
    }
}
