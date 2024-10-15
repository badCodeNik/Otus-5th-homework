using System;
using System.Collections.Generic;

namespace SaveSystem.Storages
{
    [Serializable]
    public class UnitStorage : IStorage
    {
        private UnitListData unitListData;
        public UnitListData UnitListData => unitListData;

        public void SetupData(UnitListData unitListData)
        {
            this.unitListData = unitListData;
        }
    }

    [Serializable]
    public class UnitListData
    {
        public List<UnitData> units = new();
    }

    [Serializable]
    public class UnitData
    {
        public string type;
        public int hitPoints;
        public Vector3Data position;
        public Vector3Data rotation;
    }
}