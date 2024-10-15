using System.Collections.Generic;
using GameEngine.Objects;
using GameEngine.Systems;
using UnityEngine;
using Zenject;

namespace SaveSystem
{
    public class SceneEntitiesHandler : MonoBehaviour
    {
        private ResourceService resourceService;
        private UnitManager unitManager;

        [Inject]
        public void Construct(ResourceService resourceService, UnitManager unitManager)
        {
            this.resourceService = resourceService;
            this.unitManager = unitManager;
            var resources = FindObjectsOfType<Resource>();
            var units = FindObjectsOfType<Unit>();
            resourceService.SetResources(resources);
            unitManager.SetupUnits(units);
        }

        public IEnumerable<Resource> CollectResources()
        {
            var resources = FindObjectsOfType<Resource>();
            return resources;
        }

        public IEnumerable<Unit> CollectUnits()
        {
            var units = FindObjectsOfType<Unit>();
            return units;
        }
    }
}