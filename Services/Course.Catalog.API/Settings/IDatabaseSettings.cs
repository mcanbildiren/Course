namespace Course.Catalog.API.Settings;

public interface IDatabaseSettings
{
    public string ClassCollectionName { get; set; }
    public string CategoryCollectionName { get; set; }
    public string ConnectionString { get; set; }
    public string DatabaseName { get; set; }
}