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
using AOQBIY_HFT_2022231.Models;
using System.Collections.ObjectModel;
using Microsoft.VisualBasic;

namespace AOQBIY_HFT_202231.WPFClient
{
    class MainWindowViewModel:ObservableRecipient
    {
        #region ErrorHand
        private string errorMessage;
        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }
        #endregion

        #region Processor
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
                        PerformanceCores = value.PerformanceCores,
                        MaxTurboFrequency = value.MaxTurboFrequency,
                        TotalThreads=value.TotalThreads,
                        ProcessorId = value.ProcessorId,
                        BrandId= value.BrandId,
                        ChipsetId= value.ChipsetId,
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
        #endregion

        #region Brands
        public RestCollection<Brand> Brands { get; set; }

        private Brand selectedBrand;

        public Brand SelectedBrand
        {
            get { return selectedBrand; }
            set
            {
                if (value != null)
                {
                    selectedBrand = new Brand()
                    {
                        Name = value.Name,
                        BrandId = value.BrandId,
                    };
                    OnPropertyChanged();
                    (DeleteBrandCommand as RelayCommand).NotifyCanExecuteChanged();
                }
                /*SetProperty(ref selectedProcessor, value);*/
            }
        }


        public ICommand CreateBrandCommand { get; set; }
        public ICommand DeleteBrandCommand { get; set; }
        public ICommand UpdateBrandCommand { get; set; }
        #endregion

        #region Chipset
        public RestCollection<Chipset> ChipsetsColl { get; set; }

        private Chipset selectedChipsetsColl;

        public Chipset SelectedChipsetsColl
        {
            get { return selectedChipsetsColl; }
            set
            {
                if (value != null)
                {
                    selectedChipsetsColl = new Chipset()
                    {
                        Name = value.Name,
                        ChipsetId = value.ChipsetId,
                    };
                    OnPropertyChanged();
                    (DeleteChipsetsCollCommand as RelayCommand).NotifyCanExecuteChanged();
                }
                /*SetProperty(ref selectedProcessor, value);*/
            }
        }


        public ICommand CreateChipsetsCollCommand { get; set; }
        public ICommand DeleteChipsetsCollCommand { get; set; }
        public ICommand UpdateChipsetsCollCommand { get; set; }
        #endregion

        #region NONCRUD
        static RestService rest;
        public List<Processor> processorsCRUD { get; set; }
        public List<Processor.ProcessorInfo> processorInfosCRUD { get; set; }
        public ObservableCollection<Processor> collection1 { get; set; }
        public ObservableCollection<Processor> collection2 { get; set; }
        public ObservableCollection<Processor> collection3 { get; set; }
        public ObservableCollection<Processor> collection4 { get; set; }
        public ObservableCollection<Processor> collection5 { get; set; }
        public ObservableCollection<Processor> collection6 { get; set; }
        public ObservableCollection<Processor.ProcessorInfo> collection7 { get; set; }

        public ICommand NONCRUDSTART1Command { get; set; }
        public ICommand NONCRUDSTART2Command { get; set; }
        public ICommand NONCRUDSTART3Command { get; set; }
        public ICommand NONCRUDSTART4Command { get; set; }
        public ICommand NONCRUDSTART5Command { get; set; }
        public ICommand NONCRUDSTART6Command { get; set; }
        public ICommand NONCRUDSTART7Command { get; set; }

        #endregion

        #region DesignHelp
        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        #endregion

        public MainWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                #region Processor
                Processors = new RestCollection<Processor>("http://localhost:25922/", "processor", "hub");
                CreateProcessorCommand = new RelayCommand(() =>
                {
                    Processors.Add(new Processor()
                    {
                        Name = SelectedProcessor.Name,
                        PerformanceCores= SelectedProcessor.PerformanceCores,
                        MaxTurboFrequency= SelectedProcessor.MaxTurboFrequency,
                        TotalThreads=SelectedProcessor.TotalThreads,
                        BrandId= SelectedProcessor.BrandId,
                        ChipsetId= SelectedProcessor.ChipsetId,
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
                #endregion

                #region Brand

                Brands = new RestCollection<Brand>("http://localhost:25922/", "brand", "hub");
                CreateBrandCommand = new RelayCommand(() =>
                {
                    Brands.Add(new Brand()
                    {
                        Name = SelectedBrand.Name,
                        BrandId= SelectedBrand.BrandId,
                        
                    });
                });

                UpdateBrandCommand = new RelayCommand(() =>
                {
                    try
                    {
                        Brands.Update(SelectedBrand);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });

                DeleteBrandCommand = new RelayCommand(() =>
                {
                    Brands.Delete(SelectedBrand.BrandId);
                }
                , () =>
                {
                    return SelectedBrand != null;
                }
                );
                SelectedBrand = new Brand();
                #endregion

                #region Chipset
                ChipsetsColl = new RestCollection<Chipset>("http://localhost:25922/", "chipset", "hub");
                CreateChipsetsCollCommand = new RelayCommand(() =>
                {
                    ChipsetsColl.Add(new Chipset()
                    {
                        Name = SelectedChipsetsColl.Name,
                        ChipsetId= SelectedChipsetsColl.ChipsetId,
                    });
                });

                UpdateChipsetsCollCommand = new RelayCommand(() =>
                {
                    try
                    {
                        ChipsetsColl.Update(SelectedChipsetsColl);
                    }
                    catch (ArgumentException ex)
                    {
                        ErrorMessage = ex.Message;
                    }
                });

                DeleteChipsetsCollCommand = new RelayCommand(() =>
                {
                    ChipsetsColl.Delete(SelectedChipsetsColl.ChipsetId);
                }
                , () =>
                {
                    return SelectedChipsetsColl != null;
                }
                );
                SelectedChipsetsColl = new Chipset();
                #endregion

                #region NONCRUD
                collection1 = new ObservableCollection<Processor>();
                collection2 = new ObservableCollection<Processor>();
                collection3 = new ObservableCollection<Processor>();
                collection4 = new ObservableCollection<Processor>();
                collection5 = new ObservableCollection<Processor>();
                collection6 = new ObservableCollection<Processor>();
                collection7 = new ObservableCollection<Processor.ProcessorInfo>();
                rest = new RestService("http://localhost:25922/");

                NONCRUDSTART1Command = new RelayCommand(() => 
                {
                    collection1.Clear();
                    processorsCRUD = rest.Get<Processor>("Statistics/z790ProcessorsWith10Core");
                    foreach (var item in processorsCRUD)
                    {
                        collection1.Add(item);
                    }
                });
                NONCRUDSTART2Command = new RelayCommand(() =>
                {
                    collection2.Clear();
                    processorsCRUD = rest.Get<Processor>("Statistics/INTELProcessorsWithMorethan30mbCache");
                    foreach (var item in processorsCRUD)
                    {
                        collection2.Add(item);
                    }
                });
                NONCRUDSTART3Command = new RelayCommand(() =>
                {
                    collection3.Clear();
                    processorsCRUD = rest.Get<Processor>("Statistics/INTELProcessorsWithIntegratedGraph");
                    foreach (var item in processorsCRUD)
                    {
                        collection3.Add(item);
                    }
                });
                NONCRUDSTART4Command = new RelayCommand(() =>
                {

                    collection4.Clear();
                    processorsCRUD = rest.Get<Processor>("Statistics/MaxTurboFreqMoreThen49ProcessorFromAMD");
                    foreach (var item in processorsCRUD)
                    {
                        collection4.Add(item);
                    }
                });
                NONCRUDSTART5Command = new RelayCommand(() =>
                {
                    collection5.Clear();
                    processorsCRUD = rest.Get<Processor>("Statistics/MobileProcessorsWithMoreThan6Core");
                    foreach (var item in processorsCRUD)
                    {
                        collection5.Add(item);
                    }
                });
                NONCRUDSTART6Command = new RelayCommand(() =>
                {
                    collection6.Clear();
                    processorsCRUD = rest.Get<Processor>("Statistics/IntelProcessorsWithMoreTh30Threads");
                    foreach (var item in processorsCRUD)
                    {
                        collection6.Add(item);
                    }
                });
                NONCRUDSTART7Command = new RelayCommand(() =>
                {
                    collection7.Clear();
                    processorInfosCRUD = rest.Get<Processor.ProcessorInfo>("Statistics/ProcessorsByBrands");
                    foreach (var items in processorInfosCRUD)
                    {
                        collection7.Add(items);
                    }
                });
                #endregion
            }
        }
    }
}
