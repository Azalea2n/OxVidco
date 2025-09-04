using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OxVidco.Models
{
    /// <summary>
    /// Kelas yang merepresentasikan pertanyaan dan jawaban untuk bagian FAQ
    /// </summary>
    public class FAQItem : INotifyPropertyChanged
    {
        private string _question = string.Empty;
        private string _answer = string.Empty;
        private bool _isExpanded;

        public string Question
        {
            get => _question;
            set => SetProperty(ref _question, value);
        }

        public string Answer
        {
            get => _answer;
            set => SetProperty(ref _answer, value);
        }

        public bool IsExpanded
        {
            get => _isExpanded;
            set => SetProperty(ref _isExpanded, value);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected bool SetProperty<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }
}
