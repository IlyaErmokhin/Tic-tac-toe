using System;


namespace TicTacToe;

class Program
{
    const char X = 'X';
    const char O = 'O';
    const char zero = ' ';
    static int boardSize = 3;
    private static int boardArea = boardSize * boardSize;

    //Вывод поля
    static void PrintBoard(char[] board)
    {
        const string gorizontal1 = "-----------------";
        const string gorizontal2 = "_________________";
        const string vertical1 = "|";
        const string vertical2 = "|     |     |     |";

        Console.WriteLine("\n                   Tic-Tac-Toe \n\n\n");
        Console.WriteLine("            1 player: X,  2 player: O\n");
        Console.WriteLine("    Gaming Board                   Square numeration\n");
        Console.WriteLine($"  {gorizontal2}                {gorizontal2}");
        Console.WriteLine($" {vertical2}              {vertical2}");
        Console.WriteLine(
            $" {vertical1}  {board[6]}  {vertical1}  {board[7]}  {vertical1}  {board[8]}  {vertical1}              |  7  |  8  |  9  |");
        Console.WriteLine($" {vertical2}              {vertical2}");
        Console.WriteLine($" {vertical1}{gorizontal1}{vertical1}              {vertical1}{gorizontal1}{vertical1}");
        Console.WriteLine($" {vertical2}              {vertical2}");
        Console.WriteLine(
            $" {vertical1}  {board[3]}  {vertical1}  {board[4]}  {vertical1}  {board[5]}  {vertical1}              |  4  |  5  |  6  |");
        Console.WriteLine($" {vertical2}              {vertical2}");
        Console.WriteLine($" {vertical1}{gorizontal1}{vertical1}              {vertical1}{gorizontal1}{vertical1}");
        Console.WriteLine($" {vertical2}              {vertical2}");
        Console.WriteLine(
            $" {vertical1}  {board[0]}  {vertical1}  {board[1]}  {vertical1}  {board[2]}  {vertical1}              |  1  |  2  |  3  |");
        Console.WriteLine($" {vertical2}              {vertical2}");
        Console.WriteLine($"  {gorizontal1}                {gorizontal1}\n");
    }

        static void Main()
    {
        char[] board = new char[boardArea];
        char winner = ' ';
        int step = 0;

        Array.Fill(board, zero);
        PrintBoard(board);
        while (step < boardArea)
        {
            var player = (step % 2) + 1;
            ChampionPlayer(board, player);
            winner = CheckWin(board);
            if (winner != zero)
                break;
            step++;
        }

        if (step == boardArea - 1)
            Console.WriteLine(" It's a draw!");
        else
            Console.WriteLine($" player {(winner == X ? 1 : 2)} won!");

        Console.WriteLine("Press enter to exit");
        Console.ReadLine();
    }

        //Ввод данных и определение победителя
    static void ChampionPlayer(char[] arr, int player)
    {
        int selectedNumber;

        while (true)
        {
            Console.WriteLine($"\n                   {player} player move:\n");
            Console.Write($" Select a cell from 1 to {boardArea}: ");
            string s = Console.ReadLine();
            try
            {
                selectedNumber = Convert.ToInt32(s);
                selectedNumber--;
                if (selectedNumber < 0 || selectedNumber > boardArea - 1)
                    throw new FormatException();
            }
            catch (FormatException)
            {
                Console.WriteLine(" Goddamn, please enter the cell number from 1 to 9!");
                continue;
            }
            catch (Exception)
            {
                continue;
            }

            if (arr[selectedNumber] == zero)
            {
                arr[selectedNumber] = player == 1 ? X : O;
                break;
            }

            Console.WriteLine(" Goddamn, this cell is occupied!");
        }

        Console.Clear();
        PrintBoard(arr);
    }

            private static char CheckWin(char[] board)
    {
        var columnsCheck = new int[boardSize];
        Array.Fill(columnsCheck, 0);
        var rowsCheck = new int[boardSize];
        Array.Fill(rowsCheck, 0);
        var diagonal = new char[boardSize];
        var oppositeDiagonal = new char[boardSize];

        for (var i = 0; i < boardSize; i++)
        {
            for (var j = 0; j < boardSize; j++)
            {
                var currentField = board[i * boardSize + j];
                switch (currentField)
                {
                    case X:
                        columnsCheck[j]++;
                        rowsCheck[i]++;
                        break;
                    case O:
                        columnsCheck[j]--;
                        rowsCheck[i]--;
                        break;
                }

                if (i == j)
                {
                    diagonal[i] = currentField;
                    oppositeDiagonal[i] = board[i * boardSize + boardSize - j - 1];
                }
            }
        }


        if (
            columnsCheck.Any(x => x == boardSize)
            || rowsCheck.Any(x => x == boardSize)
            || diagonal.All(x => x == X)
            || oppositeDiagonal.All(x => x == X)
        )
        {
            return X;
        }

        if (
            columnsCheck.Any(x => x == -boardSize)
            || rowsCheck.Any(x => x == -boardSize)
            || diagonal.All(x => x == O)
            || oppositeDiagonal.All(x => x == O)
        )
        {
            return O;
        }

        return zero;
    }
}
