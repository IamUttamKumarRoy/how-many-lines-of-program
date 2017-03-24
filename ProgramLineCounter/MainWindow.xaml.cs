using System;
using System.Collections.Generic;
using System.Linq;
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

namespace ProgramLineCounter
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

        private void line_count_btn_Click(object sender, RoutedEventArgs e)
        {                        
            string directory_address = directory_address_tbox.Text;
            ComboBoxItem fileTypeCB = (ComboBoxItem)file_type_cbox.SelectedItem;
            string file_type = fileTypeCB.Name.ToString();
            
            bool is_input_ok = true;
            if ( String.IsNullOrEmpty(file_type) )
            {
                is_input_ok = false;
                file_type_cbox.Focus();
            }
            if (String.IsNullOrEmpty(directory_address))
            {
                is_input_ok = false;
                directory_address_tbox.Focus();
            }
            int line_count = 0;
            int total_line = 0;
            if (is_input_ok )
            {
                FileManagement fmClassObj = new FileManagement();
                string[] files_list = fmClassObj.getFileList(directory_address, file_type);
                string file_line_details = "";
                foreach (string file in files_list)
                {
                    line_count = fmClassObj.getLineCountOfFile(@""+directory_address+"\\"+ file);
                    file_line_details = file_line_details + file + " = " + line_count  + "\n";
                    total_line += line_count;
                }
                line_count_number_label.Content = total_line;
                file_list_rtbox.Document.Blocks.Clear();
                file_list_rtbox.AppendText(file_line_details);
            }
        }

        private void about_btn_Click(object sender, RoutedEventArgs e)
        {
            About about = new About();
            about.ShowDialog();
        }
    }
}
