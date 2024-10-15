using System;
using System.Collections.Generic;
using UnityEngine;

namespace SaveSystem.Storages
{
    [Serializable]
    public class ResourceStorage : IStorage
    {
        private ResourceListData resourceListData;

        public ResourceListData ResourceListData => resourceListData;

        public void SetupData(ResourceListData resourceData)
        {
            this.resourceListData = resourceData;
            Debug.Log(this.resourceListData.resources.Count);
        }
    }

    [Serializable]
    public class ResourceData
    {
        public string id;
        public int amount;
    }

    [Serializable]
    public class ResourceListData
    {
        public List<ResourceData> resources = new List<ResourceData>();
    }
}