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
        private string FilePath { get; set; } = @"C:\TextEditor\";
        private string FileName { get; set; } = "text.txt";

        public MainWindow()
        {
            InitializeComponent();
            TextFile.ReadFile(FilePath, ref Text);
        }
        private void SubmitText_Click(object sender, RoutedEventArgs e)
        {
            TextFile.WriteFile(FilePath, ref Text);
            TextFile.ReadFile(FilePath, ref Text);
        }

        /*
        private void DeleteFile_Click(object sender, RoutedEventArgs e)
        {

        }
        */
    }
}
