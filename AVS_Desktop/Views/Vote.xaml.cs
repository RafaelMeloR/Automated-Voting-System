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
using System.Windows.Shapes;
using System.Windows.Threading;

namespace AVS_Desktop.Views
{
    /// <summary>
    /// Interaction logic for Vote.xaml
    /// </summary>
    public partial class Vote : Window
    {
        public Vote()
        {
            InitializeComponent();
            utilities.tools.timer(this);
            for(int i=0;i<10;i++)
            {
                create();
            }
           

             
        }
        public void timer_Tick(object sender, EventArgs e)
        {
            LiveTimeLabel.Content = DateTime.Now.ToString("HH:mm:ss");
        }

        public void create()
        {

            Canvas candidatesView = new Canvas()
            {
                Name = "candidatesView",
                Background = Brushes.WhiteSmoke,
                Height = 270,
                Width = 330
            };

            Image candidateProfileImage = new Image()
            {
                Height = 210,
                Width = 184,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top
            };
            Canvas.SetLeft(candidateProfileImage, 10);
            Canvas.SetTop(candidateProfileImage, 37);
            candidateProfileImage.Source = new BitmapImage(new Uri("/Assets/profile.png", UriKind.Relative));
            candidatesView.Children.Add(candidateProfileImage);

            Label nameLabel = new Label()
            {
                Content = "Name",
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center
            };
            Canvas.SetLeft(nameLabel, 199);
            Canvas.SetTop(nameLabel, 37);
            candidatesView.Children.Add(nameLabel);

            Label labelName = new Label()
            {
                Name = "LabelName",
                Content = "LabelName",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Center
            };
            Canvas.SetLeft(labelName, 199);
            Canvas.SetTop(labelName, 63);
            candidatesView.Children.Add(labelName);

            Label politicalPartyLabel = new Label()
            {
                Content = "Political Party",
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top
            };
            Canvas.SetLeft(politicalPartyLabel, 199);
            Canvas.SetTop(politicalPartyLabel, 94);
            candidatesView.Children.Add(politicalPartyLabel);

            Label labelPoliticalParty = new Label()
            {
                Name = "LabelPoliticalParty",
                Content = "LabelPoliticalParty",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top
            };
            Canvas.SetLeft(labelPoliticalParty, 199);
            Canvas.SetTop(labelPoliticalParty, 120);
            candidatesView.Children.Add(labelPoliticalParty);

            Label electiveOfficeLabel = new Label()
            {
                Content = "Elective Office",
                FontWeight = FontWeights.Bold,
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top
            };
            Canvas.SetLeft(electiveOfficeLabel, 199);
            Canvas.SetTop(electiveOfficeLabel, 151);
            candidatesView.Children.Add(electiveOfficeLabel);

            Label labelElctiveOffice = new Label()
            {
                Name = "LabelElctiveOffice",
                Content = "LabelElctiveOffice",
                HorizontalAlignment = HorizontalAlignment.Center,
                VerticalAlignment = VerticalAlignment.Top
            };
            Canvas.SetLeft(labelElctiveOffice, 199);
            Canvas.SetTop(labelElctiveOffice, 182);
            candidatesView.Children.Add(labelElctiveOffice);

            RadioButton selectRadioButton = new RadioButton()
            {
                Name = "selectRadioButton",
                Content = "Choose",
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Center,
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                Width = 103
            };
            Canvas.SetLeft(selectRadioButton, 199);
            Canvas.SetTop(selectRadioButton, 224);
            candidatesView.Children.Add(selectRadioButton);

            dock.Children.Add(candidatesView);
        }     
    }
}
