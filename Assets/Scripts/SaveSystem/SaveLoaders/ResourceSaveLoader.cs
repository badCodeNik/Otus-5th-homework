using GameEngine.Systems;
using SaveSystem.Storages;
using Zenject;

namespace SaveSystem.SaveLoaders
{
    public class ResourceSaveLoader : ISaveLoader
    {
        private readonly ResourceStorage resourceStorage;
        private readonly IGameRepository gameRepository;
        private readonly ResourceService resourceService;
        private readonly SceneEntitiesHandler sceneEntitiesHandler;

        [Inject]
        public ResourceSaveLoader(ResourceStorage resourceStorage, IGameRepository gameRepository,
            ResourceService resourceService, SceneEntitiesHandler sceneEntitiesHandler)
        {
            this.resourceStorage = resourceStorage;
            this.gameRepository = gameRepository;
            this.resourceService = resourceService;
            this.sceneEntitiesHandler = sceneEntitiesHandler;
        }

        public void SaveGame()
        {
            var resourceListData = new ResourceListData();
            resourceService.SetResources(sceneEntitiesHandler.CollectResources());
            foreach (var resource in resourceService.GetResources())
            {
                resourceListData.resources.Add(new ResourceData()
                {
                    amount = resource.Amount,
                    id = resource.ID
                });
            }

            resourceStorage.SetupData(resourceListData);
            gameRepository.SetData(resourceStorage.ResourceListData);
        }

        public void LoadGame()
        {
            if (gameRepository.TryGetData(out ResourceListData resourceListData))
            {
                resourceStorage.SetupData(resourceListData);
            }
        }
    }
}