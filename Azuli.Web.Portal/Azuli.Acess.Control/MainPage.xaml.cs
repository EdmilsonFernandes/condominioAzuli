using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Media.Imaging;
using System.IO;
using Azuli.Acess.Control.ServiceReference1;


namespace Azuli.Acess.Control
{
    public partial class MainPage : UserControl
    {






        WriteableBitmap lastSnapshot = null;

        public MainPage()
        {
            InitializeComponent();

            // Event Wiring
            cameraButton.Click += new RoutedEventHandler(cameraButton_Click);
            photoButton.Click += new RoutedEventHandler(photoButton_Click);
            saveButton.Click += new RoutedEventHandler(saveButton_Click);

            // Setup Capture Source

       
            cameraBrush.SetSource(src);
        }

        void saveButton_Click(object sender, RoutedEventArgs e)
        {

            if (lastSnapshot != null)
            {
                var dlg = new SaveFileDialog();
                dlg.DefaultExt = ".png";
                dlg.Filter = "PNG File|*.png";

                 var teste = dlg.SafeFileName;
                var pngStream = GetPngStream(lastSnapshot);
                //using (var file = dlg.OpenFile())
                //{
                byte[] binaryData = new Byte[pngStream.Length];
                //long bytesRead = pngStream.Read(binaryData, 0, (int)pngStream.Length);
                //file.Write(binaryData, 0, (int)pngStream.Length);

                WebServiceAzuliSoapClient proxy = new WebServiceAzuliSoapClient();

                proxy.cadastraFotoCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(proxy_cadastraFotoCompleted);

                proxy.cadastraFotoAsync(binaryData);



                // cliente.gravaTesteCompleted += new EventHandler<System.ComponentModel.AsyncCompletedEventArgs>(cliente_gravaTesteCompleted);
                //cliente.gravaTesteAsync(binaryData);


                //file.Flush();
                //file.Close();
            }



                    
                
            
        }


        void proxy_cadastraFotoCompleted(object sender, System.ComponentModel.AsyncCompletedEventArgs e)
        {
                throw new NotImplementedException();
        }

        



        void photoButton_Click(object sender, RoutedEventArgs e)
        {
            src.CaptureImageCompleted += (s, a) =>
            {
                lastSnapshot = a.Result;
                snapshot.Visibility = Visibility.Visible;
                snapshot.Source = lastSnapshot;
                src.Stop();
            };
            src.CaptureImageAsync();

            
        }

        CaptureSource src = new CaptureSource();

        void cameraButton_Click(object sender, RoutedEventArgs e)
        {
            if (CaptureDeviceConfiguration.AllowedDeviceAccess ||
              CaptureDeviceConfiguration.RequestDeviceAccess())
            {
                snapshot.Visibility = Visibility.Collapsed;
                src.Start();
            }
        }

        Stream GetPngStream(WriteableBitmap bmp)
        {
            // Use Joe Stegman's PNG Encoder
            // http://bit.ly/77mDsv
            EditableImage imageData = new EditableImage(bmp.PixelWidth, bmp.PixelHeight);

            for (int y = 0; y < bmp.PixelHeight; ++y)
            {
                for (int x = 0; x < bmp.PixelWidth; ++x)
                {

                    int pixel = bmp.Pixels[bmp.PixelWidth * y + x];

                    imageData.SetPixel(x, y,
                                (byte)((pixel >> 16) & 0xFF),
                                (byte)((pixel >> 8) & 0xFF),
                                (byte)(pixel & 0xFF),
                                (byte)((pixel >> 24) & 0xFF)
                                );

                }
            }

            return imageData.GetStream();
        }


    }
}
