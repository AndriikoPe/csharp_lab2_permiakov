using permiakov_lab2.Command;
using permiakov_lab2.Model;
using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;

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

        private async void ShowStatistics()
        {
            await Task.Run(() =>
            {
                DateTime dob = DateOfBirth.Value;
                DateTime today = DateTime.Today;
                int age = today.Year - dob.Year;

                if (dob.Date > today.AddYears(-age)) age--;

                if (dob > today || age > 135)
                {
                    _ = MessageBox.Show("Invalid age. Please enter a correct date of birth.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (dob.Month == today.Month && dob.Day == today.Day)
                {
                    _ = MessageBox.Show("Happy Birthday!", "Congratulations", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                Person person = new(FirstName, LastName, EmailAddress, dob);

                _ = MessageBox.Show(
                    $"Name: {person.FirstName}\n" +
                    $"Surname: {person.LastName}\n" +
                    $"Email: {person.EmailAddress}\n" +
                    $"Date of Birth: {person.DateOfBirth.ToShortDateString()}\n" +
                    $"Is Adult: {person.IsAdult}\n" +
                    $"Is Birthday: {person.IsBirthday}\n" +
                    $"Chinese Sign: {person.ChineseSign}\n" +
                    $"Sun Sign: {person.SunSign}",
                    "Person Details", MessageBoxButton.OK, MessageBoxImage.Information);
            });
        }
    }
}
