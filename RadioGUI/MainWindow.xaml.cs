using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RadioApp;

namespace RadioGUI
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		Radio radio = new Radio();

		public MainWindow()
		{
			InitializeComponent();
			DisplayLight.Fill = new SolidColorBrush(Colors.Red);
			VolumeReadout.Text = $"Vol: {radio.Volume * 100}%";
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			Button btn = (Button)sender;
			String buttonContent = btn.Content.ToString();
			
			switch (buttonContent)
			{
				case "1":
					radio.Channel = 1;
					break;
				case "2":
					radio.Channel = 2;
					break;
				case "3":
					radio.Channel = 3;
					break;
				case "4":
					radio.Channel = 4;
					break;
				case "Play":
					RadioReadout.Text = radio.Play();
					if (RadioReadout.Text != "Radio is off")
					{
						mediaElement.Source = radio.Source;
						mediaElement.Play();
					}
					break;
				case "Off":
					radio.TurnOff();
					DisplayLight.Fill = new SolidColorBrush(Colors.Red);
					mediaElement.Stop();
					RadioReadout.Text = "Radio Off";
					break;
				case "On":
					radio.TurnOn();
					DisplayLight.Fill = new SolidColorBrush(Colors.Green);
					RadioReadout.Text = "Radio On";
					break;
				case "+":
					radio.IncreaseVolume();
					mediaElement.Volume = radio.Volume;
					VolumeReadout.Text = $"Vol: {radio.Volume * 100}%";
					break;
				case "-":
					radio.DecreaseVolume();
					mediaElement.Volume = radio.Volume;
					VolumeReadout.Text = $"Vol: {radio.Volume * 100}%";
					break;
				default:
					break;
			}
		}
	}
}
