using Sirenix.OdinInspector;

namespace SaveSystem.SaveLoaders
{
    public class SaveLoadManager 
    {
        private readonly ISaveLoader[] saveLoaders;
        private readonly GameRepository gameRepository;


        public SaveLoadManager(ISaveLoader[] saveLoaders, GameRepository gameRepository)
        {
            this.saveLoaders = saveLoaders;
            this.gameRepository = gameRepository;
        }

        
        [Button]
        public void SaveGame()
        {
            foreach (var saveLoader in saveLoaders)
            {
                saveLoader.SaveGame();
            }    
            gameRepository.SaveState();
        }

        
        [Button]
        public void LoadGame()
        {
            gameRepository.LoadState();
            
            foreach (var saveLoader in saveLoaders)
            {
                saveLoader.LoadGame();
            }
        }
    }
}