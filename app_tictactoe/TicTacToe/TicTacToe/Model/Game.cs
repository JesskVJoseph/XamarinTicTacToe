using System;

namespace TicTacToe
{   
    //currently this class is not used but this can be used when we do backend integration
    public class Game
    {
        public string Id { get; set; }

        public bool IsComputer { get; set; } = true;

        public string Player1 { get; set; }

        public string Player2 { get; set; }

        public string Winner { get; set; }

        public bool IsDraw { get; set; }

        public int Moves { get; set; }

    }
}
