// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

using delivery.document.api.Extensions;

namespace delivery.document.api.Brokers.DateTimes
{
    public class DateTimeBroker : IDateTimeBroker
    {
        public DateTime GetCurrentDateTime() =>
           DateTime.UtcNow.Round(new TimeSpan(0, 0, 0, 1));
    }
}
