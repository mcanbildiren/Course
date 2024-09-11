﻿namespace Course.Catalog.API.Settings;

public class DatabaseSettings : IDatabaseSettings
{
    public string ClassCollectionName { get; set; }
    public string CategoryCollectionName { get; set; }
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}