using ShellLessonStep2.NewFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShellLessonStep2.Models;

namespace ShellLessonStep2.ViewModels
{
    
        [QueryProperty(nameof(SelectedAnimal), "selectedAnimal")]
        public class AnimalDetailsViewModel : ViewModelBase
        {
            private Animal selectedAnimal;
            public Animal SelectedAnimal
            {
                get
                {
                    return this.selectedAnimal;
                }
                set
                {
                    this.selectedAnimal = value;
                    OnPropertyChanged();
                }
            }
        }
    
}
