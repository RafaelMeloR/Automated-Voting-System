using AVS_Desktop.Controls;
using AVS_Desktop.ViewModels;
using System;
using System.Windows;

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
            voteCandidateViewModel.AddCandidate(dock);
        }
        public void timer_Tick(object sender, EventArgs e)
        {
            LiveTimeLabel.Content = DateTime.Now.ToString("HH:mm:ss");
        } 

        private async void vote_ClickAsync(object sender, RoutedEventArgs e)
        {
            VoteControl voteControl = new VoteControl();
            await voteControl.VoteAsync();
            this.Close();
        }
    }
}
