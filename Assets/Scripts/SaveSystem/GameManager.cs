using GameEngine.Systems;
using SaveSystem.SaveLoaders;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace SaveSystem
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private Transform container;
        [ShowInInspector] private SaveLoadManager saveLoadManager;
        [ShowInInspector] private UnitManager unitManager;

        [Inject]
        public void Construct(SaveLoadManager saveLoadManager, UnitManager unitManager)
        {
            this.saveLoadManager = saveLoadManager;
            this.unitManager = unitManager;
            unitManager.SetContainer(container);
        }
    }
}