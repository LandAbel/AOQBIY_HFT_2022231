using AOQBIY_HFT_2022231.Models;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using Microsoft.Toolkit.Mvvm.ComponentModel;

namespace AOQBIY_HFT_202231.WPFClient
{
    public class ProcessorWindowViewModel:ObservableRecipient
    {
        private string errorMessage;
/*        static RestService rest;
        List<Processor> processorsCRUD1;*/

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Processor> Processors { get; set; }

        private Processor selectedProcessor;

        public Processor SelectedProcessor
        {
            get { return selectedProcessor; }
            set
            {
                if (value != null)
                {
                    selectedProcessor = new Processor()
                    {
                        Name = value.Name,
                        PerformanceCores=value.PerformanceCores,
                        MaxTurboFrequency=value.MaxTurboFrequency,
                        ProcessorId = value.ProcessorId,
                    };
                    OnPropertyChanged();
                    (DeleteProcessorCommand as RelayCommand).NotifyCanExecuteChanged();
                }
                /*SetProperty(ref selectedProcessor, value);*/
            }
        }


        public ICommand CreateProcessorCommand { get; set; }
        public ICommand DeleteProcessorCommand { get; set; }
        public ICommand UpdateProcessorCommand { get; set; }


        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public ProcessorWindowViewModel()
        {
/*            rest = new RestService("http://localhost:25922/");
            processorsCRUD1 = rest.Get<Processor>("Statistics/z790ProcessorsWith10Core");*/
            if (!IsInDesignMode)
            {
                Processors = new RestCollection<Processor>("http://localhost:25922/", "processor", "hub");
                CreateProcessorCommand = new RelayCommand(() =>
                {
                    Processors.Add(new Processor()
                    {
                        Name = SelectedProcessor.Name
                    });
                });

                UpdateProcessorCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Processors.Update(SelectedProcessor);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });

                DeleteProcessorCommand = new RelayCommand(() =>
                {
                    Processors.Delete(SelectedProcessor.ProcessorId);
                }
                , () =>
                {
                    return SelectedProcessor != null;
                }
                );
                SelectedProcessor = new Processor();
            }
        }
    }
}
