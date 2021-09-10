using System;
using Delegates.Models;
using Infastracture;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class HealthBarView : MonoBehaviour
    {
        #region Editor

        [SerializeField] private Slider _slider;
        [SerializeField] private TextMeshProUGUI _maxSliderValueText;
        [SerializeField] private TextMeshProUGUI _sliderValueText;
        [SerializeField] private HealthBarModel _healthBarModel;

        #endregion

        #region Methods

        public void Initialize()
        {
            GameplayElements.Instance.PlayerModel.HealthChangedEvent += SetSliderValue;
            GameplayElements.Instance.PlayerModel.HealthChangedEvent += SetSliderText;
            var health = GameplayElements.Instance.PlayerModel.Health;
            SetMaxSliderText(_slider.maxValue);
            SetSliderValue(health);
            SetSliderText(health);
            RefillHealth();
        }

        private void RefillHealth()
        {
            GameplayServices.WaitService
                .WaitFor(_healthBarModel.HealthFillRate)
                .OnEnd(() =>
                {
                    GameplayElements.Instance.PlayerModel.AddHealth(_healthBarModel.HealthFillValue);
                    RefillHealth();
                });
        }

        public void SetMaxSliderText<T>(T value)
        {
            _maxSliderValueText.text = value.ToString();
        }

        public void SetSliderText<T>(T value)
        {
            _sliderValueText.text = value.ToString();
        }

        public void SetSliderValue(float value)
        {
            _slider.value = value;
        }

        #endregion
    }
}