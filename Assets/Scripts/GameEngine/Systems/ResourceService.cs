using System;
using System.Collections.Generic;
using System.Linq;
using GameEngine.Objects;
using Sirenix.OdinInspector;

namespace GameEngine.Systems
{
    //Нельзя менять!
    [Serializable]
    public sealed class ResourceService
    {
        [ShowInInspector, ReadOnly]
        private Dictionary<string, Resource> sceneResources = new();

        public void SetResources(IEnumerable<Resource> resources)
        {
            this.sceneResources = resources.ToDictionary(it => it.ID);
        }

        public IEnumerable<Resource> GetResources()
        {
            return this.sceneResources.Values;
        }
    }
}