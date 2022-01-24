using Enemy;
using Events;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BossHealthUI : MonoBehaviour
    {
        private Slider _slider;

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
        
        private void Start()
        {
            _slider = GetComponent<Slider>();
        }

        private void SetFullHealth(object sender, InitializeHealthEventArgs eventArgs)
        {
            _slider.maxValue = eventArgs.MaxHealth;
            _slider.value = _slider.maxValue;
        }

        private void TakeDamage(object sender, TakeDamageEventArgs eventArgs)
        {
            _slider.value -= eventArgs.Damage;
        }
    }
}
