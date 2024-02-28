using ShellLessonStep2.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShellLessonStep2.Models;
using System.Collections.ObjectModel;
using ShellLessonStep2.Services;
using System.Windows.Input;

namespace ShellLessonStep2.ViewModels
{
    public class CatsViewModel: ViewModelBase
    {
        private ObservableCollection<Animal> cats;
        public ObservableCollection<Animal> Cats
        {
            get
            {
                return this.cats;
            }
            set
            {
                this.cats = value;
                OnPropertyChanged();
            }
        }

        private AnimalService animalService;

        public CatsViewModel(AnimalService service)
        {
            this.animalService = service;
            Cats = new ObservableCollection<Animal>();
            Cats = (ObservableCollection<Animal>)this.animalService.GetCats();
            IsRefreshing = false;
        }

        public ICommand DeleteCommand => new Command<Animal>(RemoveCat);

        void RemoveCat(Animal cat)
        {
            if (Cats.Contains(cat))
            {
                Cats.Remove(cat);
            }
        }

        #region Refresh View
        public ICommand RefreshCommand => new Command(Refresh);
        private async void Refresh()
        {

            Bears = (ObservableCollection<Animal>)this.animalService.GetBears();

            IsRefreshing = false;
        }

        private bool isRefreshing;
        public bool IsRefreshing
        {
            get
            {
                return this.isRefreshing;
            }
            set
            {
                this.isRefreshing = value;
                OnPropertyChanged();
            }
        }
        #endregion


        private object selectedBear;
        public object SelectedBear
        {
            get
            {
                return this.selectedBear;
            }
            set
            {
                this.selectedBear = value;
                OnPropertyChanged();
            }
        }

        public ICommand SingleSelectCommand => new Command(OnSingleSelectBear);

        async void OnSingleSelectBear()
        {
            if (SelectedBear != null)
            {
                var navParam = new Dictionary<string, object>()
            {
                { "selectedAnimal",SelectedBear}
            };

                await Shell.Current.GoToAsync("animalDetails", navParam);

                SelectedBear = null;
            }
        }
    }
}
