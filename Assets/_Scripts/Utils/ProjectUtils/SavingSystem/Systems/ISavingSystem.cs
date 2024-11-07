using System.Threading.Tasks;

public interface ISavingSystem<T> where T : class
{
    public void SaveData(T data, string fileName = "gameData");
    public T LoadData(string fileName = "gameData");
    public void DeleteData(string fileName = "gameData");
    public Task SaveDataAsync(T data, string fileName = "gameData");
    public Task<T> LoadDataAsync(string fileName = "gameData");
    public Task DeleteDataAsync(string fileName = "gameData");
}