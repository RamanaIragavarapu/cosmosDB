using Microsoft.Azure.Cosmos;
using System;
class Db
{
    public static void Main(string[] args)
    {
        CreateItem().Wait();
    }
    private static async Task CreateItem()
    {
        var cosmosUrl = "https://localhost:8081";
        var cosmoskey = "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==";
        var databaseName = "DemoDB";
        CosmosClient client = new CosmosClient(cosmosUrl, cosmoskey);
        Database database = await client.CreateDatabaseIfNotExistsAsync(databaseName);
        Container container = await database.CreateContainerIfNotExistsAsync(
            "MyContainerName", "/partitionKeyPath", 400);
        dynamic testItem = new { id = Guid.NewGuid().ToString(), partitionKeyPath = "Mykeyvalue", details = "its working" };
        var response = await container.CreateItemAsync(testItem);



    }
}