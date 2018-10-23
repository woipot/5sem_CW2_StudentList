using System;
using System.Collections.ObjectModel;
using System.Windows;
using Prism.Commands;
using Prism.Mvvm;

namespace KR2_StudentList.Sources
{
    class StudentModel : BindableBase
    {
        public string AddData { get; set; } = "Enter Data here";

        public ObservableCollection<Student> Students { get;}


        public StudentModel()
        {
            Students = new ObservableCollection<Student>();

            AddCommand = new DelegateCommand(Add);
        }



        public DelegateCommand AddCommand { get; set; }

        private void Add()
        {
            if(string.IsNullOrEmpty(AddData)) return;

            var parts = AddData.Split(',');
            if(parts.Length != 2) return;

            var nameResult = NameConverter.ValidateName(parts[0]);
            var ageResult = AgeConverter.ValidateAge(parts[1]);

            if (!nameResult || !ageResult)
            {
                MessageBox.Show("Error input");
                return;
            }

            var sytudent = new Student(parts[0], Convert.ToInt32(parts[1]));
            Students.Add(sytudent);
            OnPropertyChanged("Students");

        }
    }
}
