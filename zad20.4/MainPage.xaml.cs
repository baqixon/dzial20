namespace zad20._4
{
    public partial class MainPage : ContentPage
    {
        List<string> imageUrls = new List<string>()
    {
        "https://i.kym-cdn.com/entries/icons/facebook/000/053/315/LARRY.jpg",
        "https://wp-media.patheos.com/blogs/sites/212/2014/01/1512679_10152046411588232_1134073941_n.jpg",
        "https://th.bing.com/th/id/OIP.PYgAv3a6oOtnxpvS8TGNNgHaG5?w=227&h=212&c=7&r=0&o=7&dpr=1.3&pid=1.7&rm=3",
        "https://th.bing.com/th/id/OIP.pz8kXnlvhtPYt89FLlJO0QHaHa?w=211&h=212&c=7&r=0&o=7&dpr=1.3&pid=1.7&rm=3",
        "https://th.bing.com/th/id/OIP.-ehjKNqY9fzgFcOPsnnkeQHaHa?w=197&h=197&c=7&r=0&o=7&dpr=1.3&pid=1.7&rm=3"
    };

        List<string> descriptions = new List<string>()
    {
        "Zdjęcie 1 - Góry",
        "Zdjęcie 2 - Pies",
        "Zdjęcie 3 - Jezioro",
        "Zdjęcie 4 - Las",
        "Zdjęcie 5 - Miasto"
    };

        public MainPage()
        {
            InitializeComponent();

            CreateGallery();
        }

        private void CreateGallery()
        {
            for (int i = 0; i < imageUrls.Count; i++)
            {
                int index = i;

                Frame frame = new Frame
                {
                    CornerRadius = 15,
                    Padding = 0,
                    HasShadow = true,
                    BorderColor = Colors.Gray
                };

                Image image = new Image
                {
                    HeightRequest = 200,
                    Aspect = Aspect.AspectFill
                };

                image.Source = new UriImageSource
                {
                    Uri = new Uri(imageUrls[i]),
                    CachingEnabled = true,
                    CacheValidity = TimeSpan.FromDays(3)
                };

                TapGestureRecognizer tapGesture = new TapGestureRecognizer();

                tapGesture.Tapped += async (s, e) =>
                {
                    await DisplayAlertAsync(
                        "Wybrano obraz",
                        descriptions[index],
                        "OK");
                };

                image.GestureRecognizers.Add(tapGesture);

                frame.Content = image;

                Label label = new Label
                {
                    Text = descriptions[i],
                    FontSize = 18,
                    HorizontalOptions = LayoutOptions.Center
                };

                galleryLayout.Children.Add(frame);
                galleryLayout.Children.Add(label);
            }
        }
    }
}
