using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OxVidco.Models
{
    /// <summary>
    /// Kelas yang merepresentasikan item bantuan untuk panduan pengguna
    /// </summary>
    public sealed class HelpItem : INotifyPropertyChanged
    {
        private string _id = string.Empty;
        private readonly string _title = string.Empty;
        private string _imagePath = string.Empty;
        private string _icon = string.Empty;
        private HelpCategory _category;
        private bool _isExpanded;

        public enum HelpCategory
        {
            Basic,
            Tips,
            Faq
        }

        public string Title
        {
            get => _title;
            init
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        public string Description
        {
            get;
            init
            {
                field = value;
                OnPropertyChanged();
            }
        } = string.Empty;

        public string Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }

        public HelpCategory Category
        {
            get => _category;
            set => SetProperty(ref _category, value);
        }

        public ObservableCollection<string> Steps
        {
            get;
            init => SetProperty(ref field, value);
        } = new();

        public string ImagePath
        {
            get => _imagePath;
            set => SetProperty(ref _imagePath, value);
        }

        public string Icon
        {
            get => _icon;
            set => SetProperty(ref _icon, value);
        }

        public bool IsExpanded
        {
            get => _isExpanded;
            set => SetProperty(ref _isExpanded, value);
        }

        /// <summary>
        /// Event yang terjadi ketika properti berubah
        /// </summary>
        public event PropertyChangedEventHandler? PropertyChanged;

        /// <summary>
        /// Memicu event PropertyChanged
        /// </summary>
        /// <param name="propertyName">Nama properti yang berubah (otomatis diambil jika null)</param>
        private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        /// <summary>
        /// Menetapkan nilai properti dan memicu PropertyChanged jika nilai berubah
        /// </summary>
        private void SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (Equals(field, value)) return;
            field = value;
            OnPropertyChanged(propertyName);
        }
    }
}
