using CoinCollection.Data;
using CoinCollection.Models;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class CoinViewModel
{
    private readonly CoinCollectionDbContext _dbContext;

    public CoinViewModel()
    {
        _dbContext = new CoinCollectionDbContext();
        Coins = new ObservableCollection<Coin>();
    }

    public ObservableCollection<Coin> Coins { get; private set; }

    public async Task LoadData()
    {
        await LoadCoins();
    }

    private async Task LoadCoins()
    {
        var coinsList = await _dbContext.Coins.ToListAsync();
        Coins.Clear();
        foreach (var coin in coinsList)
        {
            Coins.Add(coin);
        }
    }

    public async Task AddCoin(Coin coin)
    {
        _dbContext.Coins.Add(coin);
        await _dbContext.SaveChangesAsync();
        Coins.Add(coin);
    }

    public async Task DeleteCoin(Coin coin)
    {
        _dbContext.Coins.Remove(coin);
        await _dbContext.SaveChangesAsync();
        Coins.Remove(coin);
    }

    public async Task EditCoin(Coin coin)
    {
        _dbContext.Coins.Update(coin);
        await _dbContext.SaveChangesAsync();
        int index = Coins.IndexOf(coin);
        Coins[index] = coin;
    }
    public async Task SaveChanges()
    {
        await _dbContext.SaveChangesAsync();
    }
}