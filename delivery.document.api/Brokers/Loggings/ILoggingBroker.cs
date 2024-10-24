// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

namespace delivery.document.api.Brokers.Loggings
{
    public interface ILoggingBroker
    {
        void LogInInformation(string message);
        void LogTrace(string message);
        void LogDebug(string message);
        void LogWarning(string message);
        void LogError(Exception exception);
        void LogCritical(Exception exception);
    }
}
