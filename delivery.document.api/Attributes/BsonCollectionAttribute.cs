// ---------------------------------------------------------------
// Author: Dario Mostecak
// Copyright (c) 2024 Dario Mostecak. 
// ---------------------------------------------------------------


namespace delivery.document.api.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class BsonCollectionAttribute : Attribute
    {
        private string collectionName;
        public BsonCollectionAttribute(string collectionName)
        {
            this.collectionName = collectionName;
        }

        public string CollectionName => this.collectionName;
    }
}
