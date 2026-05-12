using System.ComponentModel;

namespace zad20._3
{
    public partial class MainPage : ContentPage
    {
        int aspectIndex = 0;

        Aspect[] aspects =
        {
        Aspect.AspectFit,
        Aspect.AspectFill,
        Aspect.Fill
    };

        public MainPage()
        {
            InitializeComponent();
        }

        private void OnChangeAspectClicked(object sender, EventArgs e)
        {
            aspectIndex++;

            if (aspectIndex >= aspects.Length)
            {
                aspectIndex = 0;
            }

            mainImage.Aspect = aspects[aspectIndex];

            aspectLabel.Text =
                $"Aktualny tryb: {mainImage.Aspect}";
        }

        private void RemoteImage_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == Image.IsLoadingProperty.PropertyName)
            {
                if (remoteImage.IsLoading)
                {
                    loadingLabel.Text = "Ładowanie obrazu...";
                }
                else
                {
                    loadingLabel.Text = "Obraz został załadowany.";
                }
            }
        }
    }
}

