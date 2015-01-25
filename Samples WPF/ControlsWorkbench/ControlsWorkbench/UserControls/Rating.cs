using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using Color=System.Windows.Media.Color;
using Point=System.Windows.Point;

namespace ControlsWorkbench
{
    /// <summary>
    /// Führen Sie die Schritte 1a oder 1b und anschließend Schritt 2 aus, um dieses benutzerdefinierte Steuerelement in einer XAML-Datei zu verwenden.
    ///
    /// Schritt 1a) Verwenden des benutzerdefinierten Steuerelements in einer XAML-Datei, die im aktuellen Projekt vorhanden ist.
    /// Fügen Sie dieses XmlNamespace-Attribut dem Stammelement der Markupdatei 
    /// an der Stelle hinzu, an der es verwendet werden soll:
    ///
    ///     xmlns:MyNamespace="clr-namespace:ControlsWorkbench.UserControls"
    ///
    ///
    /// Schritt 1b) Verwenden des benutzerdefinierten Steuerelements in einer XAML-Datei, die in einem anderen Projekt vorhanden ist.
    /// Fügen Sie dieses XmlNamespace-Attribut dem Stammelement der Markupdatei 
    /// an der Stelle hinzu, an der es verwendet werden soll:
    ///
    ///     xmlns:MyNamespace="clr-namespace:ControlsWorkbench.UserControls;assembly=ControlsWorkbench.UserControls"
    ///
    /// Darüber hinaus müssen Sie von dem Projekt, das die XAML-Datei enthält, einen Projektverweis
    /// zu diesem Projekt hinzufügen und das Projekt neu erstellen, um Kompilierungsfehler zu vermeiden:
    ///
    ///     Klicken Sie im Projektmappen-Explorer mit der rechten Maustaste auf das Zielprojekt und anschließend auf
    ///     "Verweis hinzufügen"->"Projekte"->[Navigieren Sie zu diesem Projekt, und wählen Sie es aus.]
    ///
    ///
    /// Schritt 2)
    /// Fahren Sie fort, und verwenden Sie das Steuerelement in der XAML-Datei.
    ///
    ///     <MyNamespace:Rating/>
    ///
    /// </summary>
    public class Rating : Control
    {

        // TODO: Mit der Änderung eines Images sollte sich die Breite und Höhe anpassen ?
        // TODO: Mögliche Ausrichtung: Horizontal oder Vertical ?
        // TODO: Standardimage für das Rating
        // TODO: How about supporting keyboard
        
        public static readonly DependencyProperty ImageProperty = DependencyProperty.Register("Image", typeof (ImageSource), typeof (Rating),
                                                                                              new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.None, new PropertyChangedCallback(OnImageChanged)));

        public static readonly DependencyProperty SectionsProperty = DependencyProperty.Register("Sections", typeof (int), typeof (Rating),
                                                                                              new FrameworkPropertyMetadata (5, FrameworkPropertyMetadataOptions.None, new PropertyChangedCallback(OnPropertyChanged)));

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(double), typeof(Rating),
                                                                                              new FrameworkPropertyMetadata(1.0, FrameworkPropertyMetadataOptions.None, new PropertyChangedCallback(OnPropertyChanged)));
        
        private bool mv_fIsMouseDown;
        private ImageSource mv_imgActiveImage = null;
        private ImageSource mv_imgInactiveImage = null;
        private ImageSource mv_imgCroppedImage = null;
       
        static Rating()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Rating), new FrameworkPropertyMetadata(typeof(Rating)));
        }

        /// <summary>
        /// This method is called when the image changed
        /// </summary>
        /// <param name="o"></param>
        /// <param name="args"></param>
        protected static void OnImageChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            Rating ctl = o as Rating;

            if (ctl == null) return;

            if (args.NewValue == null)
            {
                // if there is not value reset the values
                ctl.mv_imgActiveImage = null;
                ctl.mv_imgInactiveImage = null;
                ctl.mv_imgCroppedImage = null;
            }
            else
            {
                ImageSource imgSource = args.NewValue as ImageSource;

                if (imgSource == null) return;

                double dblWidth = imgSource.Width;
                double dblHeight = imgSource.Height;

                // Create the inactive image
                var imgGrayedImage = new FormatConvertedBitmap();

                imgGrayedImage.BeginInit();
                imgGrayedImage.Source = imgSource as BitmapSource;
                imgGrayedImage.DestinationFormat = PixelFormats.Gray32Float;
                imgGrayedImage.EndInit();
                imgGrayedImage.Freeze();

                var grpInactiveDrawing = new DrawingGroup {OpacityMask = new ImageBrush(imgSource)};
                grpInactiveDrawing.Children.Add(new ImageDrawing(imgGrayedImage, new Rect(0, 0, imgGrayedImage.Width, imgGrayedImage.Height)));
                grpInactiveDrawing.Freeze();

                ctl.mv_imgInactiveImage = new DrawingImage(grpInactiveDrawing);
                
                // Create the cropped image
                var imgCroppedSource = new CroppedBitmap();

                imgCroppedSource.BeginInit();
                imgCroppedSource.SourceRect = new Int32Rect(0, 0, (int)dblWidth / 2, (int)dblWidth);
                imgCroppedSource.Source = imgSource as BitmapSource;
                imgCroppedSource.EndInit();
                imgCroppedSource.Freeze(); 

                var grpDrawingCropped = new DrawingGroup {OpacityMask = new ImageBrush(imgSource)};
                    grpDrawingCropped.Children.Add(new ImageDrawing(imgGrayedImage, new Rect(0, 0, imgGrayedImage.Width, imgGrayedImage.Height)));
                    grpDrawingCropped.Children.Add(new ImageDrawing(imgCroppedSource, new Rect(0, 0, imgCroppedSource.Width, imgCroppedSource.Height)));
                ctl.mv_imgCroppedImage = new DrawingImage(grpDrawingCropped);

                ctl.mv_imgActiveImage = imgSource; 
            }

            // Redraw the control
            ctl.InvalidateVisual();
            ctl.UpdateLayout();
        }

        protected static void OnPropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs args)
        {
            Rating ctl = o as Rating;
            if (ctl != null)
            {
                ctl.InvalidateVisual();
                ctl.UpdateLayout(); 
            }
        }
        
        #region Properties

        public ImageSource Image
        {
            get { return (ImageSource)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        /// <summary>
        /// Gets the number of sections for the rating or sets the value. One section equals the value of two.
        /// </summary>
        public int Sections
        {
            get { return (int) GetValue(SectionsProperty); }
            set { SetValue(SectionsProperty, value);}
        }

        public double Value
        {
            get { return (double)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        
        #endregion
        
        #region Interaction with the user

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);

            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // open the user interactivity
                this.CaptureMouse();
                mv_fIsMouseDown = true;

                // Retrieve the value from position
                double dblValue = CalculateValue(e.GetPosition(this));
                
                // Set the value if changed
                if (dblValue != this.Value)
                    this.Value = dblValue;
            }
        }

        protected override void OnMouseUp(MouseButtonEventArgs e)
        {
            base.OnMouseUp(e);

            if (e.LeftButton == MouseButtonState.Released)
            {
                // close the user interactivity
                mv_fIsMouseDown = false;
                this.ReleaseMouseCapture(); 
            }
        }


        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);

            if (mv_fIsMouseDown)
            {
                // Retrieve the value from position
                double dblValue = CalculateValue(e.GetPosition(this));

                // Set the value if changed
                if (dblValue != this.Value)
                    this.Value = dblValue;
            }
        }

        #endregion

        protected override void OnRender(DrawingContext drawingContext)
        {
            base.OnRender(drawingContext);

            if (drawingContext == null) return;

            ImageSource imgSource = this.Image;

            // Wenn kein Image gefunden wurde, dann brauchen wir auch nichts zu machen.
            if (imgSource == null)
            {
                System.Windows.Media.Brush b = new SolidColorBrush(Color.FromRgb(10, 10, 10));
                System.Windows.Media.Pen p = new System.Windows.Media.Pen(b, 5);
                drawingContext.DrawLine(p, new Point(0,0), new Point(20, 20));

                Debug.WriteLine("Text gezeichnet");
            }
            else
            {
                // Erstellen der Grafiken
                double dblValue = this.Value;
                double dblWidth = imgSource.Width;
                double dblHeight = imgSource.Height;
                
                int nSections = this.Sections;

                // Calculate the start and the end of the regions
                int nLocalMod = ((int) dblValue%2);
                int nLocalValueStart = ((int) dblValue - nLocalMod) / 2;
                int nLocalValueEnd = (((int)dblValue + nLocalMod) / 2);

                // Draw all sections
                for (int i = 0; i < nSections; i++)
                {
                    ImageSource imgDraw = null;

                    // select the image to draw
                    if (i < nLocalValueStart)
                        imgDraw = mv_imgActiveImage;
                    else if (i >= nLocalValueEnd)
                        imgDraw = mv_imgInactiveImage;
                    else
                        imgDraw = mv_imgCroppedImage;

                    drawingContext.DrawImage(imgDraw, new Rect(i * dblWidth, 0, dblWidth, dblHeight));
                }
            }
        }
        
        #region local methods

        /// <summary>
        /// Calculate the value depending on the mouse position.
        /// </summary>
        private double CalculateValue(Point p)
        {
            double dblValue = 0;

            ImageSource imgSource = this.Image;

            // if the value is null we don't have any value
            if (imgSource == null) return 0;

            if (p.X < 0)
                dblValue = 0;
            else
            {
                double dblWidth = imgSource.Width / 2;
                double dblX = p.X;

                dblValue = ((dblX - (dblX % dblWidth)) / dblWidth) + 1;

                // correcting the value
                dblValue = Math.Min(dblValue, this.Sections*2);
            }
            
            return dblValue;
        }


        #endregion

    }
}
