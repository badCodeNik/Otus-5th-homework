using System;

namespace SaveSystem.Storages
{
    [Serializable]
    public class ResourceStorage : IStorage
    {
        private ResourceData resourceData;
        
        public ResourceData ResourceData => resourceData;

        public void SetupData(ResourceData resourceData)
        {
            this.resourceData = resourceData;
        }
    }

    public struct ResourceData
    {
        public int Stone;
        public int Wood;
    }
}