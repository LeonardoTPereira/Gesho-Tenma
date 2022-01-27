using Boss;
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
            BossHealth.InitializeBossHealthEventHandler += SetFullHealth;
            BossHealth.BossTakeDamageEventHandler += TakeDamage;
        }    
    
        private void OnDisable()
        {
            BossHealth.InitializeBossHealthEventHandler -= SetFullHealth;
            BossHealth.BossTakeDamageEventHandler -= TakeDamage;
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
