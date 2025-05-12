using CommunityToolkit.Mvvm.ComponentModel;
using MySql.Data.MySqlClient;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;
using System.Text.Unicode;
using WpfBookRentalShop01.Models;

namespace WpfBookRentalShop01.ViewModels
{
    public partial class BookGenreViewModel : ObservableObject
    {
        private ObservableCollection<Genre> _genres;
        public ObservableCollection<Genre> Genres
        {
            get => _genres;
            set => SetProperty(ref _genres, value);
        }

        private Genre _selectedGenre;

        public Genre SelectedGenre
        {
            get => _selectedGenre;
            set => SetProperty(ref _selectedGenre, value);
            
        }

        private bool _isUpdate;
        public BookGenreViewModel()
        {
            LoadGridFromDb();
        }

        private void LoadGridFromDb() 
        {
            string connectionString = "Server=localhost;Database=bookrentalshop;Uid=root;Pwd=12345;CharSet = Utf8;";
            string query = "SELECT division, names FROM divtbl";

            ObservableCollection<Genre> genres = new ObservableCollection<Genre>();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            { 
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(query, conn);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    var division = reader.GetString("division");
                    var names = reader.GetString("names");

                    genres.Add(new Genre
                    {
                        Division = division,
                        Name = names
                    });
                }
            }

            Genres = genres;
        }
    }
}