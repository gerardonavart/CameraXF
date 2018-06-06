using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CameraSample
{   
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

          
        }

        private async void CameraButton_Clicked(object sender, EventArgs e)
        {
            var photo = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions() { });
            if (photo != null)
            {
                MiImagen.Source = ImageSource.FromStream(() =>
                {
                    return photo.GetStream();
                });
            }

        }
        private async void ImagenButton_Clicked(object sender, EventArgs e)
        {
            
                if (CrossMedia.Current.IsTakePhotoSupported)
                {
                    var imagen = await CrossMedia.Current.PickPhotoAsync();
                    if (imagen != null)
                    {
                        MiImagen.Source = ImageSource.FromStream(() =>
                        {
                            var stream = imagen.GetStream();
                            imagen.Dispose();
                            return stream;
                        });
                    }
                }
            
        }
    }
}
