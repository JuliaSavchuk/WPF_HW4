using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF_HW4
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int playerXScore = 0;
        private int playerOScore = 0;
        private int isTie = 0;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void OnButtonClick(object sender, RoutedEventArgs e)
        {
            Button pressedButton = (Button)sender;

            int cellIndex = Convert.ToInt32(pressedButton.Tag);

            if (Game.IsTaken(cellIndex))
                return;

            Game.Turn(cellIndex);

            pressedButton.Content = Game.CurrentPlayer;

            char? winner = Game.GetWinner();

            if ((winner) != null)
            {
                MessageBox.Show($"Player '{winner}' winner!");
                if (winner == 'X')
                {
                    playerXScore++;
                    PlayerXScore.Content = $"Player X: {playerXScore}";
                }
                else if (winner == 'O')
                {
                    playerOScore++;
                    PlayerOScore.Content = $"Player O: {playerOScore}";
                }

                ResetGame();
            }
            else if (Game.IsTie())
            {
                MessageBox.Show("It's a tie!");

                isTie++;
                DrawGame.Content = $"Draw: {isTie}";
                ResetGame();
            }
            else
            {
                Game.ChangePlayer();
            }
        }

        private void ResetGame()
        {
            Game.ResetField();

            foreach (var child in MainGrid.Children)
            {
                if (child is Button button && button.Tag != null)
                {
                    button.Content = string.Empty;
                }
            }
        }
    }
}