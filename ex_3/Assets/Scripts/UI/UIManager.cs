using Infastracture;
using Services;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;
using Slider = UnityEngine.UI.Slider;

namespace UI
{
    public class UIManager : Singleton<UIManager>, IUIManager
    {
        #region Editor

        [SerializeField] private TextMeshProUGUI _totalHealthText;
        [SerializeField] private TextMeshProUGUI _healthText;
        [SerializeField] private TextMeshProUGUI _totalManaText;
        [SerializeField] private TextMeshProUGUI _manaText;
        [SerializeField] private Slider _healthSlider;
        [SerializeField] private Slider _manaSlider;

        #endregion

        #region Fields

        private Button _lastSelectedRune;

        #endregion

        #region Methods

        public void Initialize()
        {
            InitializeSliders();
            RegisterEvents();
        }

        private void InitializeSliders()
        {
            var mana = GameplayElements.Instance.PlayerModel.Mana;
            var health = GameplayElements.Instance.PlayerModel.Health;
            SetTotalHealthText(_healthSlider.maxValue);
            SetHealthSlider(health);
            SetHealthText(health);
            SetTotalManaText(_manaSlider.maxValue);
            SetManaSlider(mana);
            SetManaText(mana);
        }

        private void RegisterEvents()
        {
            GameplayElements.Instance.PlayerModel.HealthChangedEvent += SetHealthText;
            GameplayElements.Instance.PlayerModel.ManaChangedEvent += SetManaText;
            GameplayElements.Instance.PlayerModel.HealthChangedEvent += SetHealthSlider;
            GameplayElements.Instance.PlayerModel.ManaChangedEvent += SetManaSlider;
            GameplayElements.Instance.RuneDrawingFieldView.RuneDrawCompleteEvent += DeselectRune;
            GameplayElements.Instance.RuneDrawingFieldView.RuneDrawEvent += DisableSelectedRune;
        }

        public void SetHealthSlider(float value)
        {
            _healthSlider.value = value;
        }

        public void SetManaSlider(float value)
        {
            _manaSlider.value = value;
        }

        public void SetTotalHealthText<T>(T value)
        {
            _totalHealthText.text = value.ToString();
        }

        public void SetHealthText<T>(T value)
        {
            _healthText.text = value.ToString();
        }

        public void SetTotalManaText<T>(T value)
        {
            _totalManaText.text = value.ToString();
        }

        public void SetManaText<T>(T value)
        {
            _manaText.text = value.ToString();
        }

        public void SelectRune()
        {
            if (_lastSelectedRune == null)
                _lastSelectedRune = EventSystem.current.currentSelectedGameObject.GetComponent<Button>();
        }

        private void DisableSelectedRune<T>(T cost)
        {
            if (_lastSelectedRune != null)
            {
                _lastSelectedRune.interactable = false;
            }
        }

        private void DeselectRune()
        {
            if (_lastSelectedRune != null)
            {
                _lastSelectedRune.interactable = true;
            }

            _lastSelectedRune = null;
        }

        protected override UIManager GetInstance()
        {
            return this;
        }

        #endregion
    }
}