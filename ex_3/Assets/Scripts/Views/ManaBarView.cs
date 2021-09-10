using System;
using System.Collections;
using Delegates.Models;
using Infastracture;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Views
{
    public class ManaBarView : MonoBehaviour
    {
        #region Editor

        [SerializeField] private Slider _slider;
        [SerializeField] private TextMeshProUGUI _maxSliderValueText;
        [SerializeField] private TextMeshProUGUI _sliderValueText;
        [SerializeField] private ManaBarModel _manaBarModel;

        #endregion

        #region Methods

        public void Initialize()
        {
            GameplayElements.Instance.PlayerModel.ManaChangedEvent += SetSliderValue;
            GameplayElements.Instance.PlayerModel.ManaChangedEvent += SetSliderText;
            var mana = GameplayElements.Instance.PlayerModel.Mana;
            SetMaxSliderText(_slider.maxValue);
            SetSliderValue(mana);
            SetSliderText(mana);

            RefillMana();
        }

        private void RefillMana()
        {
            GameplayServices.WaitService
                .WaitFor(_manaBarModel.ManaFillRate)
                .OnEnd(() =>
                {
                    GameplayElements.Instance.PlayerModel.AddMana(_manaBarModel.ManaFillValue);
                    RefillMana();
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