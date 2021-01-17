using BasicClicker.Core;
using System;

namespace BasicClicker
{
    public static class Program
    {
        [STAThread]
        private static void Main()
        {
            Logging.Load();

            using var game = new BCGame();
            game.Run();
        }
    }
}