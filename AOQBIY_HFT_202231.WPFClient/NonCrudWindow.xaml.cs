using AOQBIY_HFT_2022231.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AOQBIY_HFT_202231.WPFClient
{
    /// <summary>
    /// Interaction logic for NonCrudWindow.xaml
    /// </summary>
    
    public partial class NonCrudWindow : Window
    {
        static RestService rest;
        public List<Processor> processorsCRUD { get; set; }
        public List<Processor.ProcessorInfo> processorInfosCRUD { get; set; }
        public ObservableCollection<Processor> collection { get; set; }
        public ObservableCollection<Processor.ProcessorInfo> collection2 { get; set; }
        //public CompositeCollection compositeCollection { get; set; }
        public NonCrudWindow()
        {
            InitializeComponent();
            DataContext = this;
            //rest = new RestService("http://localhost:25922/");
            //processorsCRUD = rest.Get<Processor>("Statistics/z790ProcessorsWith10Core");
            collection = new ObservableCollection<Processor>();
            collection2 = new ObservableCollection<Processor.ProcessorInfo>();
            rest = new RestService("http://localhost:25922/");
            //compositeCollection = new CompositeCollection();
            //compositeCollection.Add(new CollectionContainer() { Collection = collection });
            //foreach (var item in processorsCRUD)
            //{
            //    collection.Add(item);
            //}
        }

        private void NONCRUD1_Click(object sender, RoutedEventArgs e)
        {
            this.collection.Clear();
            processorsCRUD = rest.Get<Processor>("Statistics/z790ProcessorsWith10Core");
            foreach (var item in processorsCRUD)
            {
                collection.Add(item);
            }
        }

        private void NONCRUD2_Click(object sender, RoutedEventArgs e)
        {
            this.collection.Clear();
            processorsCRUD = rest.Get<Processor>("Statistics/INTELProcessorsWithMorethan30mbCache");
            foreach (var item in processorsCRUD)
            {
                collection.Add(item);
            }
        }

        private void NONCRUD3_Click(object sender, RoutedEventArgs e)
        {
            this.collection.Clear();
            processorsCRUD = rest.Get<Processor>("Statistics/INTELProcessorsWithIntegratedGraph");
            foreach (var item in processorsCRUD)
            {
                collection.Add(item);
            }
        }

        private void NONCRUD5_Click(object sender, RoutedEventArgs e)
        {
            this.collection.Clear();
            processorsCRUD = rest.Get<Processor>("Statistics/MaxTurboFreqMoreThen49ProcessorFromAMD");
            foreach (var item in processorsCRUD)
            {
                collection.Add(item);
            }
        }

        private void NONCRUD6_Click(object sender, RoutedEventArgs e)
        {
            this.collection.Clear();
            processorsCRUD = rest.Get<Processor>("Statistics/MobileProcessorsWithMoreThan6Core");
            foreach (var item in processorsCRUD)
            {
                collection.Add(item);
            }
        }

        private void NONCRUD7_Click(object sender, RoutedEventArgs e)
        {
            this.collection.Clear();
            processorsCRUD = rest.Get<Processor>("Statistics/IntelProcessorsWithMoreTh30Threads");
            foreach (var item in processorsCRUD)
            {
                collection.Add(item);
            }

        }

        private void NONCRUD8_Click(object sender, RoutedEventArgs e)
        {
            this.collection2.Clear();
            processorInfosCRUD = rest.Get<Processor.ProcessorInfo>("Statistics/ProcessorsByBrands");
            foreach (var items in processorInfosCRUD)
            {
                collection2.Add(items);
            }
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            processorInfosCRUD = rest.Get<Processor.ProcessorInfo>("Statistics/ProcessorsByBrands");
            foreach (var items in processorInfosCRUD)
            {
                collection2.Add(items);
            }
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            collection2.Clear();
        }
    }
}
