using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;


namespace AppDemo.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private string textLabel;

        public string TextLabel
        {
            get { return textLabel; }
            set { Set(ref textLabel, value); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = default(string))
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand NavigateFirstCommand { get { return new RelayCommand(NavigateFirst); } }

        private async void NavigateFirst()
        {
            await App.Current.MainPage.Navigation.PushAsync(new FirstPage());
        }

        protected void Set<T>(ref T field, T value, [CallerMemberName] string propertyName = default(string))
        {
            if (!EqualityComparer<T>.Default.Equals(field, value))
            {
                field = value;
                OnPropertyChanged(propertyName);
            }
        }
    }
}
