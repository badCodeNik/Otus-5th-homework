using GameEngine.Systems;
using SaveSystem.SaveLoaders;
using SaveSystem.Storages;
using Zenject;

namespace SaveSystem
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameRepository>().AsSingle();
            Container.BindInterfacesAndSelfTo<ResourceSaveLoader>().AsSingle();
            Container.BindInterfacesAndSelfTo<UnitSaveLoader>().AsSingle();
            Container.Bind<ResourceStorage>().AsSingle();
            Container.Bind<UnitManager>().AsSingle();
            Container.Bind<ResourceService>().AsSingle();
            Container.Bind<SceneEntitiesHandler>().FromComponentInHierarchy().AsSingle();
            Container.Bind<UnitStorage>().AsSingle();
            Container.Bind<SaveLoadManager>().AsSingle();
        }
    }
}