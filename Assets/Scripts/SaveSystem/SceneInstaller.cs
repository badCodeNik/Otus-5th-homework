using SaveSystem.Storages;
using Zenject;

namespace SaveSystem
{
    public class SceneInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            Container.Bind<ResourceStorage>().AsSingle();
            Container.Bind<IGameRepository>().To<GameRepository>().AsSingle();
        }
    }
}