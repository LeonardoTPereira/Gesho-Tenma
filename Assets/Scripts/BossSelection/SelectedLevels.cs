using System;
using System.Collections.Generic;
using UnityEngine;

namespace Game.LevelSelection
{
    [CreateAssetMenu(fileName = "SelectedLevels", menuName = "GeshouTenma/SelectedLevels", order = 0)]    [Serializable]
    public class SelectedLevels : ScriptableObject
    {
        [field: SerializeField] public List<LevelData> Levels { get; set; }
        [SerializeField] private int selectedIndex;

        public LevelData GetCurrentLevel()
        {
            return Levels[selectedIndex];
        }

        public void SelectLevel(int index)
        {
            selectedIndex = index;
        }
    }
}