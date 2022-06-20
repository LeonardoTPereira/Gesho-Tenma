using TMPro;
using UnityEngine;

namespace Game.LevelSelection
{
    public class LevelDescription : MonoBehaviour
    {
        public string BossDescription { get; set; }
        public string ScenarioDescription { get; set; }

        [field:SerializeField] public TextMeshProUGUI DisplayedText { get; set; }

        public void CreateDescriptions(LevelData levelData)
        {
            CreateBossDescription(levelData.Boss);
            CreateScenarioDescription(levelData.Scenario);
            ShowDescription();
        }

        private void CreateScenarioDescription(ScenarioData levelDataScenario)
        {
            ScenarioDescription = levelDataScenario.Name;
        }

        private void CreateBossDescription(BossData levelDataBoss)
        {
            BossDescription = levelDataBoss.Name;
        }

        private void ShowDescription()
        {
            DisplayedText.text = BossDescription +"\n"+ ScenarioDescription;
        }
    }
}