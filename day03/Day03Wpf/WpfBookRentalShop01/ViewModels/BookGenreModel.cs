using CommunityToolkit.Mvvm.ComponentModel;

namespace WpfBookRentalShop01.ViewModels
{
    public partial class BookGenreModel : ObservableObject
    {
        private string _message;

        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public BookGenreModel()
        {
            Message = "책장르 화면입니다.";
        }
    }
}
