using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Windows.Media;
using System.Windows; 
using AVS_Desktop.Models;
using AVS_Desktop.Controls;
using Microsoft.IdentityModel.Tokens;

namespace AVS_Desktop.ViewModels
{
    partial class voteCandidateViewModel
    {
        private static void createCandidate(WrapPanel dock,CandidateViewModel candidate)
        {
            if (candidate!=null)
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
                if (candidate.ProfilePhoto != null) //TO DO FIX ELSE, IT DOESNT SHOW PICTURE
                {
                    candidateProfileImage.Source = new BitmapImage(new Uri("/Assets/profile.png", UriKind.Relative));
                }
                else
                {
                    candidateProfileImage.Source = new BitmapImage(new Uri("'"+candidate.ProfilePhoto+"'", UriKind.RelativeOrAbsolute));

                }
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
                    Content = candidate.Name + " " + candidate.LastName,
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
                    Content = candidate.NamePoliticalParty,
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
                    Content = candidate.ElectoralPosition,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Top
                };
                Canvas.SetLeft(labelElctiveOffice, 199);
                Canvas.SetTop(labelElctiveOffice, 182);
                candidatesView.Children.Add(labelElctiveOffice);

                RadioButton selectRadioButton = new RadioButton()
                {
                    Name = "selectRadioButton" + candidate.IdPerson,
                    Content = "Choose",
                    HorizontalAlignment = HorizontalAlignment.Left,
                    VerticalAlignment = VerticalAlignment.Center,
                    FontSize = 16,
                    FontWeight = FontWeights.Bold,
                    Width = 103
                };
                // Event handler for the Click event
                selectRadioButton.Click += SelectRadioButton_Click;

                // Event handler method
                void SelectRadioButton_Click(object sender, RoutedEventArgs e)
                {
                    RadioButton clickedRadioButton = (RadioButton)sender;
                    VoteControl voteControl = new VoteControl();
                    voteControl.SetGuid(candidate.IdCandidate); 
                    foreach (var radioButton in candidatesView.Children.OfType<RadioButton>())
                    {
                        if (radioButton != clickedRadioButton)
                        {
                            radioButton.IsChecked = false;
                        }
                    }
                }
                Canvas.SetLeft(selectRadioButton, 199);
                Canvas.SetTop(selectRadioButton, 224);
                candidatesView.Children.Add(selectRadioButton);

                Border candidatesViewBorder = new Border()
                {
                    BorderBrush = Brushes.White,
                    BorderThickness = new Thickness(2),
                    Child = candidatesView
                };

                dock.Children.Add(candidatesViewBorder);
            }
           
        }

        public static void AddCandidate(WrapPanel dock)
        {
            VoteControl voteControl = new VoteControl();
            List<CandidateViewModel> candidates = VoteControl.GetCandidates();
           
            if (candidates.IsNullOrEmpty())
            {
                Label emptyLabel = new Label
                {
                    Content = "No Candidates Available",
                };
                dock.Children.Add(emptyLabel);
            }
            else 
            {
                foreach (CandidateViewModel candidate in candidates)
                {
                    createCandidate(dock, candidate);
                }
            }
        }
    }

}
