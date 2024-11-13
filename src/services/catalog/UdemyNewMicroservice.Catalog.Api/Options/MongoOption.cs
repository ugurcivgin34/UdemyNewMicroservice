﻿namespace UdemyNewMicroservice.Catalog.Api.Options
{
    public class MongoOption
    {
        public string DatabaseName { get; set; } = default!;
        public string ConnectionString { get; set; } = default!;
    }
}