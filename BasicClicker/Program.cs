using log4net;
using System;

namespace BasicClicker
{
    public static class Program
    {
        [STAThread]
        private static void Main()
        {
            BasicClicker.Main.Logger = LogManager.GetLogger("BasicClicker");

            using (var game = new BCGame())
                game.Run();

            DataManager.CreateSaveFile();
        }
    }
}