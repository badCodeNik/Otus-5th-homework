using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace SaveSystem
{
    public class GameRepository : IGameRepository
    {
        private Dictionary<string, string> _gameData = new();

        public bool TryGetData<T>(out T data)
        {
            var key = typeof(T).ToString();

            if (_gameData.TryGetValue(key, out var jsonData))
            {
                data = JsonConvert.DeserializeObject<T>(jsonData);
                return true;
            }

            data = default;
            return false;
        }

        public void SetData<T>(T data)
        {
            var jsonData = JsonConvert.SerializeObject(data);
            var key = typeof(T).ToString();
            _gameData[key] = jsonData;
        }

        public void LoadData()
        {
            if (PlayerPrefs.HasKey(Constants.GameStateKey))
            {
                var gameStateJson = PlayerPrefs.GetString(Constants.GameStateKey);
                _gameData = JsonConvert.DeserializeObject<Dictionary<string, string>>(gameStateJson);
            }
        }


        public void SaveData()
        {
            var gameStateJson = JsonConvert.SerializeObject(_gameData);
            PlayerPrefs.SetString(Constants.GameStateKey, gameStateJson);
        }
    }
}