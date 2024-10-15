using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace SaveSystem.SaveLoaders
{
    public class SaveLoadManager 
    {
        private readonly ISaveLoader[] saveLoaders;
        private readonly GameRepository gameRepository;

        [Inject]
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
            gameRepository.SaveData();
        }

        
        [Button]
        public void LoadGame()
        {
            gameRepository.LoadData();
            
            foreach (var saveLoader in saveLoaders)
            {
                saveLoader.LoadGame();
            }
        }
    }
}