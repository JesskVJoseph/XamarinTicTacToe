using Acr.UserDialogs;
using System;
using System.Threading.Tasks;
using TicTacToe.Model;
using Xamarin.Forms;

namespace TicTacToe
{
    public class GameViewModel : ViewModelBase
    {
        public string[,] CurrentGame { get; set; }
        
        bool Player1Up { get; set; } = true;
        int Moves { get; set; } = 0;
        public GameViewModel(Page page) :base(page)
        {
            CurrentGame = new string[3, 3];
            CurrentStatus = $"{Settings.Player1} is up.";  
        }

        string currentStatus;
        public string CurrentStatus
        {
            get { return currentStatus; }
            set {
                  currentStatus = value;
                  OnPropertyChanged("CurrentStatus");
                 }
        }


        string boardPosition0 = string.Empty;
        public string BoardPosition0
        {
            get { return boardPosition0; }
            set
            {
                boardPosition0 = value;
                OnPropertyChanged("BoardPosition0");
            }
        }

        string boardPosition1 = string.Empty;
        public string BoardPosition1
        {
            get { return boardPosition1; }
            set
            {
                boardPosition1 = value;
                OnPropertyChanged("BoardPosition1");
            }
        }

        string boardPosition2 = string.Empty;
        public string BoardPosition2
        {
            get { return boardPosition2; }
            set
            {
                boardPosition2 = value;
                OnPropertyChanged("BoardPosition2");
            }
        }

        string boardPosition3 = string.Empty;
        public string BoardPosition3
        {
            get { return boardPosition3; }
            set
            {
                boardPosition3 = value;
                OnPropertyChanged("BoardPosition3");
            }
        }

        string boardPosition4 = string.Empty;
        public string BoardPosition4
        {
            get { return boardPosition4; }
            set
            {
                boardPosition4 = value;
                OnPropertyChanged("BoardPosition4");
            }
        }

        string boardPosition5 = string.Empty;
        public string BoardPosition5
        {
            get { return boardPosition5; }
            set
            {
                boardPosition5 = value;
                OnPropertyChanged("BoardPosition5");
            }
        }

        string boardPosition6 = string.Empty;
        public string BoardPosition6
        {
            get { return boardPosition6; }
            set
            {
                boardPosition6 = value;
                OnPropertyChanged("BoardPosition6");
            }
        }

        string boardPosition7 = string.Empty;
        public string BoardPosition7
        {
            get { return boardPosition7; }
            set
            {
                boardPosition7 = value;
                OnPropertyChanged("BoardPosition7");
            }
        }

        string boardPosition8 = string.Empty;
        public string BoardPosition8
        {
            get { return boardPosition8; }
            set {
                  boardPosition8 = value;
                  OnPropertyChanged("BoardPosition8");
                }
        }

        Boolean isgameOver;
        public Boolean IsGameOver
        {
            get { return isgameOver; }
            set {
                  isgameOver = value;
                  OnPropertyChanged("IsGameOver");
                }
        }

        string gameOverExpression = string.Empty;
        public string GameOverExpression
        {
            get { return gameOverExpression; }
            set {
                   gameOverExpression = value;
                   OnPropertyChanged("GameOverExpression");
                 }
        }

        Command resetCommand;
        public Command ResetCommand
        {
            get
            {
                return resetCommand ??
                  (resetCommand = new Command(async () =>
                  {
                      //check if game is over
                      if(!IsGameOver)
                      {
                          var result = await UserDialogs.Instance.ConfirmAsync("The game isn't over yet, are you sure you want to reset the game?", "Reset?");
                          if (!result)
                              return;
                      }

                      CurrentGame = new string[3, 3];
                      BoardPosition0 = string.Empty;
                      BoardPosition1 = string.Empty;
                      BoardPosition2 = string.Empty;
                      BoardPosition3 = string.Empty;
                      BoardPosition4 = string.Empty;
                      BoardPosition5 = string.Empty;
                      BoardPosition6 = string.Empty;
                      BoardPosition7 = string.Empty;
                      BoardPosition8 = string.Empty;
                      Player1Up = true;
                      IsGameOver = false;
                      Moves = 0;
                      CurrentStatus = $"{Settings.Player1} is up.";
                  }));
            }
        }

        Command<string> playCommand;
        public Command<string> PlayCommand
        {
            get
            {
                return playCommand ??
                    (playCommand = new Command<string>(async (p) => await Play(p)));
            }
        }


        async Task Play(string number)
        {
          
            if (IsGameOver)
                return;

            int x = 0;
            int y = 0;
            Move currentPostion = GetMatrixPosition(number);
            x = currentPostion.row;
            y = currentPostion.col;

            if (!string.IsNullOrWhiteSpace(CurrentGame[x, y]))
                return;

             CurrentGame[x, y] = "X";

             SetPlayerMove(number, x, y);
           
             Moves++;

             await CheckResults();  
        }

        private void SetPlayerMove(string postion,int x,int y)
        {
            switch (postion)
            {
                case "0":
                    BoardPosition0 = GetImageName(x, y);
                    break;
                case "1":
                    BoardPosition1 = GetImageName(x, y);
                    break;
                case "2":
                    BoardPosition2 = GetImageName(x, y);
                    break;
                case "3":
                    BoardPosition3 = GetImageName(x, y);
                    break;
                case "4":
                    BoardPosition4 = GetImageName(x, y);
                    break;
                case "5":
                    BoardPosition5 = GetImageName(x, y);
                    break;
                case "6":
                    BoardPosition6 = GetImageName(x, y);
                    break;
                case "7":
                    BoardPosition7 = GetImageName(x, y);
                    break;
                case "8":
                    BoardPosition8 = GetImageName(x, y);
                    break;
                default:
                    return;
            }
        }
        private Move GetMatrixPosition(string postion)
        {
            Move currentPostion = new Move();

            switch (postion)
            {
                case "0": 
                    break;
                case "1":
                    currentPostion.row = 1;
                    currentPostion.col = 0;
                    break;
                case "2":
                    currentPostion.row = 2;
                    currentPostion.col = 0;
                    break;
                case "3":
                    currentPostion.row = 0;
                    currentPostion.col = 1;
                    break;
                case "4":
                    currentPostion.row = 1;
                    currentPostion.col = 1;
                    break;
                case "5":
                    currentPostion.row = 2;
                    currentPostion.col = 1;
                    break;
                case "6":
                    currentPostion.row = 0;
                    currentPostion.col = 2;
                    break;
                case "7":
                    currentPostion.row = 1;
                    currentPostion.col = 2;
                    break;
                case "8":
                    currentPostion.row = 2;
                    currentPostion.col = 2;
                    break;
              
            }

            return currentPostion;

        }
        private string GetImageName(int x, int y)
        {
            return CurrentGame[x, y] == "X" ? "x_1.png" : "o_1.png";
        }

        //check for win or draw.
        async Task CheckResults()
        {
            //Conditions for winning the game
            string[,] winningCombos =
            {
                {CurrentGame[0,0], CurrentGame[0,1], CurrentGame[0,2]},
                {CurrentGame[1,0], CurrentGame[1,1], CurrentGame[1,2]},
                {CurrentGame[2,0], CurrentGame[2,1], CurrentGame[2,2]},
                {CurrentGame[0,0], CurrentGame[1,0], CurrentGame[2,0]},
                {CurrentGame[0,1], CurrentGame[1,1], CurrentGame[2,1]},
                {CurrentGame[0,2], CurrentGame[1,2], CurrentGame[2,2]},
                {CurrentGame[0,0], CurrentGame[1,1], CurrentGame[2,2]},
                {CurrentGame[0,2], CurrentGame[1,1], CurrentGame[2,0]}
            };

            for (int i = 0; i < 8; i++)
            {

                if ((winningCombos[i, 0] == "X") & (winningCombos[i, 1] == "X") & (winningCombos[i, 2] == "X"))
                {
                    IsGameOver = true;
                    CurrentStatus = "You Win!";
                    GameOverExpression = "face_happy.png";
                    await InsertWinner(1);
                    return;
                }

                if ((winningCombos[i, 0] == "O") & (winningCombos[i, 1] == "O") & (winningCombos[i, 2] == "O"))
                {
                    IsGameOver = true;
                    CurrentStatus = "You Lose!";
                    GameOverExpression = "face_sad.png";
                    await InsertWinner(2);
                    return;
                }

            }

             
            SimpleAI simpleAI = new SimpleAI();
            for (int x = 0; x < 3; x++)
            {
                for (int y = 0; y < 3; y++)
                {
                    if (string.IsNullOrWhiteSpace(CurrentGame[x, y]))
                    {
                        
                        int computerMove = simpleAI.FindBestMove(CurrentGame);
                        Move matrixPostion = GetMatrixPosition(computerMove.ToString());
                        CurrentGame[matrixPostion.row, matrixPostion.col] = "O";
                        await Task.Delay(100);
                        SetPlayerMove(computerMove.ToString(), matrixPostion.row, matrixPostion.col);
                        return;
                    }
                }

                //Draw!
                IsGameOver = true;
                CurrentStatus = "That's a draw!";
                GameOverExpression = "face_indifferent.png";
                await InsertWinner(0);
            }

            async Task InsertWinner(int winner)
            {
                var winnerName = string.Empty;
                bool isDraw = false;
                var date = DateTime.UtcNow;
                switch (winner)
                {
                    case 0:
                         isDraw = true;
                        await UserDialogs.Instance.AlertAsync("Game is a draw!. Hit Play Again to start a new game.", "Draw!");
                        break;
                    case 1:
                        winnerName = Settings.Player1;
                        await UserDialogs.Instance.AlertAsync($"{Settings.Player1} won this game!. Hit Play Again to start a new game.", $"{Settings.Player1} Wins!");
                        break;
                    case 2:
                        winnerName = Settings.Player2;
                        await UserDialogs.Instance.AlertAsync($"{Settings.Player2} won this game!. Hit Play Again to start a new game.", $"{Settings.Player2} Wins!");
                        break;
                }

            }

        }
       
    }
}
