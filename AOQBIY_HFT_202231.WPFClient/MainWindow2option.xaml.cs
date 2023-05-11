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

namespace AOQBIY_HFT_202231.WPFClient
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

        private void Processor_Click(object sender, RoutedEventArgs e)
        {
            ProcessorWindow proc=new ProcessorWindow();
            proc.Show();    
        }

        private void Chipsets_Click(object sender, RoutedEventArgs e)
        {
            ChipsetWindow chip=new ChipsetWindow();
            chip.Show();
        }

        private void Brand_Click(object sender, RoutedEventArgs e)
        {
            BrandWindow brand=new BrandWindow();
            brand.Show();
        }

        private void NonCRUD_Click(object sender, RoutedEventArgs e)
        {
            NonCrudWindow nonCrud=new NonCrudWindow();
            nonCrud.Show();
        }
    }
}
