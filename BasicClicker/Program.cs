using System;

namespace BasicClicker
{
    public static class Program
    {
        [STAThread]
        static void Main()
        {
            using (var game = new BasicClickerGame())
                game.Run();
        }
    }
}
