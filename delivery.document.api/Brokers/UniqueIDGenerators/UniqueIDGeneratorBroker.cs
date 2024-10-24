// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak.
// ---------------------------------------------------------------

namespace delivery.document.api.Brokers.UniqueIDGenerators
{
    public class UniqueIDGeneratorBroker : IUniqueIDGeneratorBroker
    {
        public Guid GenerateUniqueID() =>
           Guid.NewGuid();
    }
}
