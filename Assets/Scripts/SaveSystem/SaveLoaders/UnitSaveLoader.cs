using GameEngine.Systems;
using SaveSystem.Storages;
using Zenject;

namespace SaveSystem.SaveLoaders
{
    public class UnitSaveLoader : ISaveLoader
    {
        private readonly UnitStorage unitStorage;
        private readonly IGameRepository gameRepository;
        private readonly UnitManager unitManager;
        private readonly SceneEntitiesHandler sceneEntitiesHandler;

        [Inject]
        public UnitSaveLoader(UnitStorage unitStorage, IGameRepository gameRepository, UnitManager unitManager,
            SceneEntitiesHandler sceneEntitiesHandler)
        {
            this.unitStorage = unitStorage;
            this.gameRepository = gameRepository;
            this.unitManager = unitManager;
            this.sceneEntitiesHandler = sceneEntitiesHandler;
        }

        public void SaveGame()
        {
            UnitListData unitListData = new UnitListData();
            unitManager.SetupUnits(sceneEntitiesHandler.CollectUnits());
            var units = unitManager.GetAllUnits();
            foreach (var unit in units)
            {
                unitListData.units.Add(new UnitData()
                {
                    hitPoints = unit.HitPoints,
                    position = new Vector3Data(unit.Position.x, unit.Position.y, unit.Position.z),
                    rotation = new Vector3Data(unit.Rotation.x, unit.Rotation.y, unit.Rotation.z),
                    type = unit.Type
                });
            }

            unitStorage.SetupData(unitListData);
            gameRepository.SetData(unitListData);
        }

        public void LoadGame()
        {
            if (gameRepository.TryGetData(out UnitListData unitData))
            {
                unitStorage.SetupData(unitData);
            }
        }
    }
}