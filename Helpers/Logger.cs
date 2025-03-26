using System;
using NLog;

namespace day1_asm.Helpers;

public static class Logger
{
    private static readonly NLog.Logger logger = LogManager.GetCurrentClassLogger();

    public static void LogInfo(string message)
    {
        logger.Info(message);
    }

    public static void LogWarning(string message)
    {
        logger.Warn(message);
    }

    public static void LogError(Exception ex, string context = "")
    {
        logger.Error(ex, $"[{context}] {ex.Message}");
    }
}
