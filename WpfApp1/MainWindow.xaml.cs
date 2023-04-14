using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
using ClassLibrary1;
using Microsoft.Win32;
using WpfApp1;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewData viewData = new ViewData();
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = viewData;
            function_list.ItemsSource = Enum.GetValues(typeof(ClassLibrary1.FRawEnum));
        }
        private void From_Controls_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                viewData.InitRawData();
                viewData.InitSplineData();
                viewData.CreateSpline();
                DataContext = null;
                DataContext = viewData;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void From_File_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            //RawData temp = new RawData(viewData.raw_a, viewData.raw_b, viewData.raw_notes_number, viewData.raw_is_uniform, viewData.raw_selected_function);
            if (openFileDialog.ShowDialog() == true)
            {
                viewData.Load(openFileDialog.FileName);//, ref temp);
            }

            viewData.InitSplineData();
            viewData.CreateSpline();

            DataContext = null;
            DataContext = viewData;
        }
        /*private void listbox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            current_spline_item.Text = spline_listbox.SelectedItem.ToString();
        }*/
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog(); 
            if (saveFileDialog.ShowDialog() == false)
                return;
            string filename = saveFileDialog.FileName;
            viewData.Save(filename);
            MessageBox.Show("Файл сохранен");
        }
    }
}