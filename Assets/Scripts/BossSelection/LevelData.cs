using System;
using UnityEngine;

namespace Game.LevelSelection
{
    [Serializable]
    [CreateAssetMenu(fileName = "LevelData", menuName = "Overlord-Project/LevelData", order = 0)]
    public class LevelData : ScriptableObject
    {
        [SerializeField] private bool _completed;
        [SerializeField] private bool _surrendered;

        //TODO: Pass boss and scenario parameters
        public void Init()
        {
            _completed = false;
            _surrendered = false;
        }

        public void CompleteLevel()
        {
            _completed = true;
        }

        public void GiveUpLevel()
        {
            _surrendered = true;
        }

        public bool HasCompleted()
        {
            return _completed || _surrendered;
        }
    }
}