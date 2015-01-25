using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Drawing.Imaging;
using Image=System.Windows.Controls.Image;
using PixelFormat=System.Windows.Media.PixelFormat;
using Rectangle=System.Windows.Shapes.Rectangle;

namespace ControlsWorkbench.Pages
{
    /// <summary>
    /// Interaktionslogik für RectPage.xaml
    /// </summary>
    public partial class DrawImage : Page
    {
        public DrawImage()
        {
            InitializeComponent();
        }

        private void ConvertToGray_Click(object sender, RoutedEventArgs e)
        {
            // Auslesen der Quelldaten
            BitmapSource bsSourceImage = ((Image)cboImages.SelectedItem).Source.Clone() as BitmapSource;

            if (bsSourceImage == null) return;

            // Erstellen eines Images, bei dem das Imageformat
            // umgewandelt wird. Hier: In Graustufen
            FormatConvertedBitmap bmpGrayImage = new FormatConvertedBitmap();

            bmpGrayImage.BeginInit();
            bmpGrayImage.Source = bsSourceImage;
            bmpGrayImage.DestinationFormat = PixelFormats.Gray32Float;
            bmpGrayImage.EndInit();

            // Um den Hintergrund nicht schwarz zu lassen, muss das Originalimage
            // als Transparenzmaske festgelegt werden
            imgGrayScale.OpacityMask = new ImageBrush(bsSourceImage);

            // Dann erfolgt die Zuordnung des Bildes
            imgGrayScale.Stretch = Stretch.None; 
            imgGrayScale.Source = bmpGrayImage;
            
        }

        private void cmdCropp_Click(object sender, RoutedEventArgs e)
        {
            // Auslesen der Quelldaten
            BitmapSource bsSourceImage = ((Image)cboImages.SelectedItem).Source.Clone() as BitmapSource;
            
            if (bsSourceImage == null) return;

            // Erstellen eines zugeschnittenen Bildes
            CroppedBitmap imgCroppedSource = new CroppedBitmap();
            
            imgCroppedSource.BeginInit();
            imgCroppedSource.SourceRect = new Int32Rect(0, 0, (int)bsSourceImage.Width / 2, (int)bsSourceImage.Height);
            imgCroppedSource.Source = bsSourceImage;
            imgCroppedSource.EndInit();
            
            imgCropped.Stretch = Stretch.None;
            imgCropped.Source = imgCroppedSource;
        }

        private void cmdCombine_Click(object sender, RoutedEventArgs e)
        {
            BitmapSource imgGray = ((Image)cboImages.SelectedItem).Source.Clone() as BitmapSource;

            if (imgGray == null) return;

            CroppedBitmap imgCroppedSource = new CroppedBitmap();

            imgCroppedSource.BeginInit();
            imgCroppedSource.SourceRect = new Int32Rect(0, 0, (int)imgGray.Width / 2, (int)imgGray.Height);
            imgCroppedSource.Source = imgGray;
            imgCroppedSource.EndInit();

            FormatConvertedBitmap grayBitmapSource = new FormatConvertedBitmap();

            grayBitmapSource.BeginInit();
            grayBitmapSource.Source = imgGray;
            grayBitmapSource.DestinationFormat = PixelFormats.Gray32Float;
            grayBitmapSource.EndInit();
            
            ImageDrawing idDrawGrayscale = new ImageDrawing(grayBitmapSource, new Rect(0, 0, 64, 64));
            
            DrawingGroup grpDrawing = new DrawingGroup();
            grpDrawing.OpacityMask = new ImageBrush(imgGray);
            grpDrawing.Children.Add(idDrawGrayscale);
            grpDrawing.Freeze();

            ImageDrawing idCropped = new ImageDrawing(imgCroppedSource, new Rect(0, 0, 32, 64));

            DrawingGroup drawTogether = new DrawingGroup();
            drawTogether.Children.Add(grpDrawing);
            drawTogether.Children.Add(idCropped);
            drawTogether.Freeze();


            DrawingImage imgDrawing = new DrawingImage(drawTogether);
            imgDrawing.Freeze();

            imgCombine.Stretch = Stretch.None; 
            imgCombine.Source = imgDrawing;
            imgCombine.UpdateLayout(); 
            
        }

    }
}
