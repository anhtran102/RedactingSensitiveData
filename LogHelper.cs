using AnhTran.RedactingSensitiveData.Models;

namespace AnhTran.RedactingSensitiveData
{
    public static partial class LogHelper
    {
        [LoggerMessage(LogLevel.Information, "User infomation:")]
        public static partial void LogInfoUser(this ILogger logger, [LogProperties] User user);
    }
}