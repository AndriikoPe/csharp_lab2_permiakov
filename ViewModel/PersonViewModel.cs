using permiakov_lab2.Command;
using System;
using System.ComponentModel;
using System.Windows.Input;

namespace permiakov_lab2.ViewModel
{
    internal class PersonViewModel : INotifyPropertyChanged
    {
        private string firstName;
        private string lastName;
        private string emailAddress;
        private DateTime? dateOfBirth;

        public event PropertyChangedEventHandler PropertyChanged;

        public string FirstName
        {
            get => firstName;
            set { firstName = value; OnPropertyChanged(nameof(CanProceed)); }
        }

        public string LastName
        {
            get => lastName;
            set { lastName = value; OnPropertyChanged(nameof(CanProceed)); }
        }

        public string EmailAddress
        {
            get => emailAddress;
            set { emailAddress = value; OnPropertyChanged(nameof(CanProceed)); }
        }

        public DateTime? DateOfBirth
        {
            get => dateOfBirth;
            set { dateOfBirth = value; OnPropertyChanged(nameof(CanProceed)); }
        }

        public bool CanProceed => !string.IsNullOrWhiteSpace(FirstName)
            && !string.IsNullOrWhiteSpace(LastName)
            && !string.IsNullOrWhiteSpace(EmailAddress)
            && DateOfBirth.HasValue;

        public RelayCommand ProceedCommand => new(
            execute => ShowStatistics(),
            canExecute => { return true; });

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ShowStatistics() {
            
        }
    }
}
