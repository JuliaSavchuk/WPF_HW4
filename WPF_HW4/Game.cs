using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_HW4
{
    public static class Game
    {

        private static char[] field = new char[] { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', };

        public static char CurrentPlayer { get; private set; } = 'X';


        public static bool IsTaken(int cellIndex)
        {
            return field[cellIndex] != ' ';
        }

        public static void Turn(int cellIndex)
        {
            field[cellIndex] = CurrentPlayer;
        }

        public static void ChangePlayer()
        {
            CurrentPlayer = CurrentPlayer == 'X' ? 'O' : 'X';
        }

        public static char? GetWinner()
        {
            for (int i = 0; i < 3; i++)
            {
                if (field[i * 3] != ' ' && field[i * 3] == field[i * 3 + 1] && field[i * 3] == field[i * 3 + 2])
                {
                    return CurrentPlayer;
                }
            }

            for (int i = 0; i < 3; i++)
            {
                if (field[i] != ' ' && field[i] == field[i + 3] && field[i] == field[i + 6])
                {
                    return CurrentPlayer;
                }
            }

            if (field[0] != ' ' && field[0] == field[4] && field[0] == field[8])
            {
                return CurrentPlayer;
            }
            if (field[2] != ' ' && field[2] == field[4] && field[2] == field[6])
            {
                return CurrentPlayer; 
            }

            return null;
        }

        public static bool IsTie()
        {
            return GetWinner() == null && !field.Contains(' ');
        }

        public static void ResetField()
        {
            for (int i = 0; i < field.Length; i++)
            {
                field[i] = ' ';
            }
            CurrentPlayer = 'X';
        }

    }
}
