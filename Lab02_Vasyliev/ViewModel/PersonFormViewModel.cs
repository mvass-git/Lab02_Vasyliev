using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Lab02_Vasyliev.Model;

namespace Lab02_Vasyliev.ViewModel
{
    internal class PersonFormViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private Person _person = new Person("","","",DateTime.Now);
        private bool _isButtonEnabled;
        private bool _isEnabled = true;

        public bool IsEnabled { get { return _isEnabled; } 
            set {
                _isEnabled = value;
                OnPropertyChanged(nameof(IsEnabled));
            } 
        }

        public bool IsProceedEnabled
        {
            get { return _isButtonEnabled; }
            set
            {
                _isButtonEnabled = value;
                OnPropertyChanged(nameof(IsProceedEnabled));
                
            }
        }
        public string FirstName
        {
            get
            {
                return _person.FirstName;
            }
            set { _person.FirstName = value;
                UpdateIsProceedEnabled();
            }
        }

        public string LastName
        {
            get { return _person.LastName; }
            set { _person.LastName = value;
                UpdateIsProceedEnabled();
            }
        }

        public string Email
        {
            get { return _person.Email; }
            set { _person.Email = value;
                UpdateIsProceedEnabled();
            }
        }

        public DateTime BirthDate
        {
            get { return _person.DateOfBirth; }
            set { _person.DateOfBirth = value;
                UpdateIsProceedEnabled();
            }
        }

        public string SunSign
        {
            get { return _person.SunSign; }
        }

        public string ChineseSign
        {
            get { return _person.ChineseSign;}
        }

        public bool IsAdult
        {
            get { return _person.IsAdult;}
        }

        public bool IsBirthday
        {
            get { return _person.IsBirthday;}
        }

        public int Age
        {
            get { return _person.CalculateAge(_person.DateOfBirth); }
        }


        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private void UpdateIsProceedEnabled()
        {
            IsProceedEnabled = !string.IsNullOrWhiteSpace(_person.FirstName) &&
                               !string.IsNullOrWhiteSpace(_person.LastName) &&
                               !string.IsNullOrWhiteSpace(_person.Email) &&
                               _person.DateOfBirth != null;
            
        }

        public async void Proceed()
        {
            if (this.Age > 135 || this.BirthDate > DateTime.Today)
            {
                MessageBox.Show("Incorrect date.");
            }
            else
            {
                if (this.IsBirthday == true)
                {
                    MessageBox.Show("Happy birthday!");
                }
                IsEnabled = false;
                await Task.Run(() => MessageBox.Show($" First name:{this.FirstName}\n Last name:{this.LastName}\n E-mail:{this.Email}\n Birh date:{this.BirthDate}\n Is adult:{this.IsAdult}\n IsBirthday:{this.IsBirthday}\n Sun sign:{this.SunSign}\n ChineseSign:{this.ChineseSign}"));
            }
            
            IsEnabled = true;
            
        }

    }
}
