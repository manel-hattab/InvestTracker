
using InvestTracker.Models;
using InvestTracker.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace InvestTracker.Data;

public static class DbSeeder
{
    public static async Task SeedAsync(AppDbContext context)
    {
        if (await context.Assets.AnyAsync()) return;

        Console.WriteLine("--- Seeding assets ---");

        var bitcoin = new Asset
        {
            Name = "Bitcoin",
            Symbol = "BTC",
            Type = AssetType.Crypto,
            CurrentPrice = 62000.00m,
            LastUpdated = DateTime.Now
        };

        var ethereum = new Asset
        {
            Name = "Ethereum",
            Symbol = "ETH",
            Type = AssetType.Crypto,
            CurrentPrice = 3200.00m,
            LastUpdated = DateTime.Now
        };

        var apple = new Asset
        {
            Name = "Apple Inc.",
            Symbol = "AAPL",
            Type = AssetType.Stock,
            CurrentPrice = 175.50m,
            LastUpdated = DateTime.Now
        };

        var tesla = new Asset
        {
            Name = "Tesla Inc.",
            Symbol = "TSLA",
            Type = AssetType.Stock,
            CurrentPrice = 245.00m,
            LastUpdated = DateTime.Now
        };

        context.Assets.AddRange(bitcoin, ethereum, apple, tesla);
        await context.SaveChangesAsync();

        Console.WriteLine("--- Seeding completed! ---");
    }
}
