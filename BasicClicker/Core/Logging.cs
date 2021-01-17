using log4net;
using log4net.Appender;
using log4net.Config;
using log4net.Layout;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace BasicClicker.Core
{
    public static class Logging
    {
        public static readonly string LogPath = Environment.CurrentDirectory + Path.DirectorySeparatorChar + "Logs";

        internal static ILog Logger => LogManager.GetLogger("BasicClicker");

        internal static void Load()
        {
            Directory.CreateDirectory(LogPath);

            PatternLayout layout = new PatternLayout()
            {
                ConversionPattern = "[%d{HH:mm:ss}] [%t/%level] [%logger]: %m%n"
            };

            layout.ActivateOptions();

            List<IAppender> appenders = new List<IAppender>
            {
                new ConsoleAppender()
                {
                    Name = "ConsoleAppender",
                    Layout = layout
                },
                new DebugAppender()
                {
                    Name = "DebugAppender",
                    Layout = layout
                }
            };
            FileAppender fileAppender = new FileAppender()
            {
                Name = "FileAppender",
                File = Path.Combine(LogPath, "log"),
                AppendToFile = false,
                Encoding = Encoding.UTF8,
                Layout = layout
            };
            fileAppender.ActivateOptions();

            appenders.Add(fileAppender);

            BasicConfigurator.Configure(appenders.ToArray());
        }
    }
}