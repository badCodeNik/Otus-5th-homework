using SaveSystem.Storages;

namespace SaveSystem.SaveLoaders
{
    public class ResourceSaveLoader : ISaveLoader
    {
        private readonly ResourceStorage resourceStorage;
        private readonly IGameRepository gameRepository;

        public ResourceSaveLoader(ResourceStorage resourceStorage, IGameRepository gameRepository)
        {
            this.resourceStorage = resourceStorage;
            this.gameRepository = gameRepository;
        }

        public void SaveGame()
        {
            gameRepository.SetData(resourceStorage.ResourceData);
            
        }

        public void LoadGame()
        {
            if (gameRepository.TryGetData(out ResourceData resourceData))
            {
                resourceStorage.SetupData(resourceData);
            }
        }
    }
}