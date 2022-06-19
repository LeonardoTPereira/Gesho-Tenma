using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Game.LevelSelection
{
    public class LevelDescription : MonoBehaviour
    {
        public string DungeonDescription { get; set; }
        public string QuestDescription { get; set; }

        [field:SerializeField] public TextMeshProUGUI DisplayedText { get; set; }

        private bool _isShowingDungeon;

        public void CreateDescriptions(LevelData levelData)
        {
            _isShowingDungeon = false;
            ChangeDescription();
        }

        public void ChangeDescription(InputAction.CallbackContext context)
        {
            ChangeDescription();
        }

        private void ChangeDescription()
        {
            _isShowingDungeon = !_isShowingDungeon;
            DisplayedText.text = _isShowingDungeon ? DungeonDescription : QuestDescription;
        }
    }
}