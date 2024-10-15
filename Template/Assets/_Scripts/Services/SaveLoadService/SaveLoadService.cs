using _Scripts.Services.Progress.ProgressData;
using _Scripts.Services.StaticData;
using UnityEngine;

namespace _Scripts.Services.SaveLoadService
{
    public static class SaveLoadService
    {
        public static void Save(PlayerProgress playerProgress)
        {
            PlayerPrefs.SetString("Progress", playerProgress.ToJson());
        }

        public static PlayerProgress Load()
        {
            return PlayerPrefs.GetString("Progress")?.ToDeserialized<PlayerProgress>();
        }
    }
}
