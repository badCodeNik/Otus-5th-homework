namespace SaveSystem.Storages
{
    public class ResourceStorage : ISaveLoader
    {
        public void LoadGame()
        {
            
        }

        public void SaveGame()
        {
            
        }
    }

    public interface ISaveLoader
    {
        void LoadGame();
        void SaveGame();
    }
}