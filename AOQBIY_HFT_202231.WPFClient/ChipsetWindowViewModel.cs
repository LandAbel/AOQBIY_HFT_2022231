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
    public class ChipsetWindowViewModel:ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

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
                        ChipsetId= value.ChipsetId,
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


        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public ChipsetWindowViewModel()
        {
            if (!IsInDesignMode)
            {
                ChipsetsColl = new RestCollection<Chipset>("http://localhost:25922/", "chipset", "hub");
                CreateChipsetsCollCommand = new RelayCommand(() =>
                {
                    ChipsetsColl.Add(new Chipset()
                    {
                        Name = SelectedChipsetsColl.Name
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
            }
        }
    }
}
