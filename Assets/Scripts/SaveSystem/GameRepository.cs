using System.Collections.Generic;
using Newtonsoft.Json;
using UnityEngine;

namespace SaveSystem
{
    public class GameRepository : IGameRepository
    {
        private Dictionary<string, string> _gameState = new();

        public bool TryGetData<T>(out T data)
        {
            var key = typeof(T).ToString();

            if (_gameState.TryGetValue(key, out var jsonData))
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
            _gameState[key] = jsonData;
        }

        public void LoadState()
        {
            if (PlayerPrefs.HasKey(GameStateKey))
            {
                var gameStateJson = PlayerPrefs.GetString(GameStateKey);
                _gameState = JsonConvert.DeserializeObject<Dictionary<string, string>>(gameStateJson);
            }
        }

        private const string GameStateKey = "gameStateKey";

        public void SaveState()
        {
            var gameStateJson = JsonConvert.SerializeObject(_gameState);
            PlayerPrefs.SetString(GameStateKey, gameStateJson);
        }
    }
}