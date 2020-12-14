using log4net;
using System;

namespace BasicClicker
{
    public static class Program
    {
        [STAThread]
        private static void Main()
        {
            Core.Main.Logger = LogManager.GetLogger("BasicClicker");

            using (var game = new BCGame())
                game.Run();
        }
    }
}