using System;
using System.Windows;
using System.Windows.Media;

namespace ColourPicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Counts the numer of numbers the user has decided

        int i = 0;

        //Maximum number of guesses, by default its 21, changing this might lead to more accurate results? idk 
        int max = 21;

        int redtotal = 0;
        int greentotal = 0;
        int bluetotal = 0;

        //The total score for each channel, which i divide by the number of turns to get the average

        int redaverage = 0;
        int greenaverage = 0;
        int blueaverage = 0;

        //Rng setup 

        Random rnd = new Random();

        private void btnYes_Click(object sender, RoutedEventArgs e)
        {
            //Creates random values for the RGB channels of the rectangle, i have to declare the variables locally as they wont work globally

            int r = rnd.Next(0, 255);
            int g = rnd.Next(0, 255);
            int b = rnd.Next(0, 255);

            i++;

            //if the number of turns is less than the desired amount it will write to the average variables but if not it will display them

            if (i < max)
            {
                //Applies the channels to the background colour

                rctBackground.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(r), Convert.ToByte(g), Convert.ToByte(b)));

                redtotal += r;
                greentotal += g;
                bluetotal += b;

                redaverage = redtotal / i;
                greenaverage = greentotal / i;
                blueaverage = bluetotal / i;
            }

            else
            {
                rctBackground.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(greenaverage), Convert.ToByte(greenaverage), Convert.ToByte(blueaverage)));

                //This hides the buttons as they arent used any more

                btnYes.Visibility = Visibility.Hidden;
                btnNo.Visibility = Visibility.Hidden;
            }

            //Debug, ignore or uncomment for more infomation

            //txtDebug.Text = " i= " + i + "redavg=" + redaverage + " blueavg= " + blueaverage + " greenavg= " + greenaverage;
        }

        private void btnNo_Click(object sender, RoutedEventArgs e)
        {
            //Creates random values for the RGB channels of the rectangle

            int r = rnd.Next(0, 255);
            int g = rnd.Next(0, 255);
            int b = rnd.Next(0, 255);

            i++;

            if (i < max)
            {
                //Applies the channels to the background colour

                rctBackground.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(r), Convert.ToByte(g), Convert.ToByte(b)));

                //This works out the 'colour at fault' by working out what channel is more pronounced, taking that channel away and adding to the others. Should fix an issue with the end result being grey/black

                //If red is the most prevelant 

                if (r >= g && r>= b)
                {

                    if (redtotal >= r)
                    {
                        redtotal -= r;
                    }

                    else
                    {
                        redtotal = 0;
                    }

                    if (bluetotal >= g)
                    {
                        bluetotal += g;
                    }

                    else
                    {
                        bluetotal = 0;
                    }

                    if (greentotal >= b)
                    {
                        greentotal += b;
                    }

                    else
                    {
                        greentotal = 0;
                    }
                }

                //If green is the most prevelant 

                if (g >= r && g >= b)
                {

                    if (redtotal >= r)
                    {
                        redtotal += r;
                    }

                    else
                    {
                        redtotal = 0;
                    }

                    if (bluetotal >= g)
                    {
                        bluetotal -= g;
                    }

                    else
                    {
                        bluetotal = 0;
                    }

                    if (greentotal >= b)
                    {
                        greentotal -= b;
                    }

                    else
                    {
                        greentotal = 0;
                    }
                }

                //If blue is the most prevelant 

                if (b >= r && b >= g)
                {

                    if (redtotal >= r)
                    {
                        redtotal += r;
                    }

                    else
                    {
                        redtotal = 0;
                    }

                    if (bluetotal >= g)
                    {
                        bluetotal += g;
                    }

                    else
                    {
                        bluetotal = 0;
                    }

                    if (greentotal >= b)
                    {
                        greentotal -= b;
                    }

                    else
                    {
                        greentotal = 0;
                    }
                }

                redaverage = redtotal / i;
                greenaverage = greentotal / i;
                blueaverage = bluetotal / i;
            }

            else
            {
                rctBackground.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(greenaverage), Convert.ToByte(greenaverage), Convert.ToByte(blueaverage)));
            }

            //Debug, ignore or uncomment for more infomation

            //txtDebug.Text = " i= " + i + "redavg=" + redaverage + " blueavg= " + blueaverage + " greenavg= " + greenaverage;
        }

        private void rctBackground_Loaded(object sender, RoutedEventArgs e)
        {
            //Starts the background off as a random colour

            rctBackground.Fill = new SolidColorBrush(Color.FromRgb(Convert.ToByte(rnd.Next(0, 255)), Convert.ToByte(rnd.Next(0, 255)), Convert.ToByte(rnd.Next(0, 255))));
        }
    }
}
