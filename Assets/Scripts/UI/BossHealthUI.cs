using Enemy;
using Events;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BossHealthUI : MonoBehaviour
    {
        [SerializeField] private Slider slider;

        private void OnEnable()
        {
            PlaceholderEnemyController.InitializeBossHealthEventHandler += SetFullHealth;
            PlaceholderEnemyController.BossTakeDamageEventHandler += TakeDamage;
        }    
    
        private void OnDisable()
        {
            PlaceholderEnemyController.InitializeBossHealthEventHandler -= SetFullHealth;
            PlaceholderEnemyController.BossTakeDamageEventHandler -= TakeDamage;
        }

        private void SetFullHealth(object sender, InitializeHealthEventArgs eventArgs)
        {
            slider.maxValue = eventArgs.MaxHealth;
            slider.value = slider.maxValue;
        }

        private void TakeDamage(object sender, TakeDamageEventArgs eventArgs)
        {
            slider.value -= eventArgs.Damage;
        }
    }
}
