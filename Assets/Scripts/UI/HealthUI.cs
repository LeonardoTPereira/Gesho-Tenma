using System;
using System.Collections.Generic;
using Events;
using Player;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class HealthUI : MonoBehaviour
    {
        private List<Image> _heartList;
        // Start is called before the first frame update

        [SerializeField]
        private Sprite fullHeartSprite, emptyHeartSprite;
        [SerializeField] private float iconPaddingMultiplier = 1.2f;
        [SerializeField] private int scale = 1;
        [SerializeField] private int delta = 16;
        private int _currentHealth;

        private void OnEnable()
        {
            PlayerController.InitializePlayerHealthEventHandler += CreateHeartImage;
            PlayerController.PlayerTakeDamageEventHandler += OnDamage;
        }

        private void OnDisable()
        {
            PlayerController.InitializePlayerHealthEventHandler -= CreateHeartImage;
            PlayerController.PlayerTakeDamageEventHandler -= OnDamage;
        }

        private void CreateHeartImage(object sender, InitializeHealthEventArgs eventArgs)
        {
            var row = 0;
            var col = 0;
            var rowMax = 10;


            _heartList = new List<Image>();

            var rowColSize = fullHeartSprite.rect.size.x * iconPaddingMultiplier;
            var maxHealth = eventArgs.MaxHealth;
            _currentHealth = maxHealth;

            for (var i = 0; i < maxHealth; i++)
            {

                var heartAnchoredPosition = new Vector2(col * rowColSize, row * rowColSize);
                var heartGameObject = InitializeHeartGameObject(heartAnchoredPosition);
                var heartImageUI = SetHeartImageUI(heartGameObject, i);
                _heartList.Add(heartImageUI);

                row++;
                if (row < rowMax && heartGameObject.transform.position.y + delta + rowColSize <= Screen.height) continue;
                col++;
                row = 0;
            }

        }

        private Image SetHeartImageUI(GameObject heartGameObject, int i)
        {
            // Set heart sprite
            var heartImageUI = heartGameObject.GetComponent<Image>();
            heartImageUI.sprite = i <= _currentHealth ? fullHeartSprite : emptyHeartSprite;
            return heartImageUI;
        }

        private GameObject InitializeHeartGameObject(Vector2 heartAnchoredPosition)
        {
            var heartGameObject = new GameObject("Heart", typeof(Image));

            // Set as child of this transform
            heartGameObject.transform.SetParent(transform, false);
            heartGameObject.transform.localPosition = Vector3.zero;
            heartGameObject.transform.localScale = new Vector3(scale, scale, 1);

            // Locate and Size heart
            heartGameObject.GetComponent<RectTransform>().anchoredPosition = heartAnchoredPosition;
            heartGameObject.GetComponent<RectTransform>().sizeDelta = new Vector2(delta, delta);
            return heartGameObject;
        }

        private void OnDamage(object sender, TakeDamageEventArgs eventArgs)
        {
            _currentHealth = Math.Max(0, _currentHealth - eventArgs.Damage);
            for (var i = 0; i < _currentHealth; ++i)
                _heartList[i].sprite = fullHeartSprite;
            for (var i = _currentHealth; i < _heartList.Count; ++i)
                _heartList[i].sprite = emptyHeartSprite;
        }

    }
}
