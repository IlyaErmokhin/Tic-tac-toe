using System;


namespace TicTacToe
{
    class Program
    {
        //Вывод поля
        public static void GamingBoard(char[] arr)
        {
            const string gorizontal1 = "-----------------";
            const string gorizontal2 = "_________________";
            const string vertical1 = "|";
            const string vertical2 = "|     |     |     |";

            Console.WriteLine("");
            Console.WriteLine("                   Tic-Tac-Toe ");
            Console.WriteLine("");
            Console.WriteLine(""); 
            Console.WriteLine("");
            Console.WriteLine("            1 player: X,  2 player: O");
            Console.WriteLine("");
            Console.WriteLine("    Gaming Board                   Square numeration");
            Console.WriteLine("");
            Console.WriteLine($"  {gorizontal2}                {gorizontal2}" );

            Console.WriteLine($" {vertical2}              {vertical2}" );

            Console.WriteLine($" {vertical1}  {arr[7]}  {vertical1}  {arr[8]}  {vertical1}  {arr[9]}  {vertical1}              |  7  |  8  |  9  |");

            Console.WriteLine($" {vertical2}              {vertical2}" );

            Console.WriteLine($" {vertical1}{gorizontal1}{vertical1}              {vertical1}{gorizontal1}{vertical1}");

            Console.WriteLine($" {vertical2}              {vertical2}");

            Console.WriteLine($" {vertical1}  {arr[4]}  {vertical1}  {arr[5]}  {vertical1}  {arr[6]}  {vertical1}              |  4  |  5  |  6  |");

            Console.WriteLine($" {vertical2}              {vertical2}");

            Console.WriteLine($" {vertical1}{gorizontal1}{vertical1}              {vertical1}{gorizontal1}{vertical1}");

            Console.WriteLine($" {vertical2}              {vertical2}");

            Console.WriteLine($" {vertical1}  {arr[1]}  {vertical1}  {arr[2]}  {vertical1}  {arr[3]}  {vertical1}              |  1  |  2  |  3  |");

            Console.WriteLine($" {vertical2}              {vertical2}");

            Console.WriteLine($"  {gorizontal1}                {gorizontal1}");
            Console.WriteLine("");
        }

        static void Main(string[] args)
        {
            const char zero = ' ';
            char[] Field = new char[10];
            int step = 0;
            bool game = false;

            Array.Fill(Field, zero);
            GamingBoard(Field);
            while (game == false)
            {
                game = ChampionPlayer(zero, Field, game, step);
                step += 1;
            }
            Console.ReadKey();
        }

        //Ввод данных и определение победителя
        public static bool ChampionPlayer(char Zero, char[] arr, bool GameCheck, int step)
        {
            const char X = 'X';
            const char O = 'O';
            int player, number;
            string s = " ";
            bool flag = true;
            player = (step % 2) + 1;

            do
            {
                try
                {
                    Console.WriteLine("");
                    Console.WriteLine("                   " + player + " player move:");
                    Console.WriteLine("");
                    Console.Write(" Select a cell from 1 to 9: ");
                    s = Console.ReadLine();
                    number = Convert.ToInt32(s);
                    if ((s.Length == 1) && (number >= 1) && (number <= 9))
                    {
                        if (arr[number] == Zero)
                        {
                            if (player == 1)
                                arr[number] = X;
                            else arr[number] = O;
                            flag = false;
                        }
                        else Console.WriteLine(" Goddamn, this cell is occupied!");
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine(" Goddamn, please enter the cell number from 1 to 9!");
                }
            }
            while (flag);

            //Victory check
            GameCheck = (Zero != arr[1]) && (arr[1] == arr[2]) && (arr[2] == arr[3]) ||
            (Zero != arr[4]) && (arr[4] == arr[5]) && (arr[5] == arr[6]) ||
            (Zero != arr[7]) && (arr[7] == arr[8]) && (arr[8] == arr[9]) ||
            (Zero != arr[1]) && (arr[1] == arr[4]) && (arr[4] == arr[7]) ||
            (Zero != arr[2]) && (arr[2] == arr[5]) && (arr[5] == arr[8]) ||
            (Zero != arr[3]) && (arr[3] == arr[6]) && (arr[6] == arr[9]) ||
            (Zero != arr[1]) && (arr[1] == arr[5]) && (arr[5] == arr[9]) ||
            (Zero != arr[3]) && (arr[3] == arr[5]) && (arr[5] == arr[7]);
            Console.Clear();
            GamingBoard(arr);

            if (GameCheck)
                Console.WriteLine(" " + player + " player " + " won!");
            else if (step == 8)
            {
                GameCheck = true;
                Console.WriteLine(" It's a draw!");
            }
            return GameCheck;
        }
    }
}
