using System;
using UnityEngine;

namespace Game.LevelSelection
{
    [Serializable]
    [CreateAssetMenu(fileName = "LevelData", menuName = "GeshouTenma/LevelData", order = 0)]
    public class LevelData : ScriptableObject
    {
        [SerializeField] private bool completed;
        [field: SerializeField] public ScenarioData Scenario { get; set; }
        [field: SerializeField] public BossData Boss { get; set; }

        //TODO: Pass boss and scenario parameters
        public void Init()
        {
            completed = false;
        }

        public void CompleteLevel()
        {
            completed = true;
        }

        public bool HasCompleted()
        {
            return completed;
        }
    }
}