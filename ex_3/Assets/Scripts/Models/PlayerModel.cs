using System;
using Delegates.Views;
using UnityEngine;

namespace Delegates.Models
{
    [CreateAssetMenu(menuName = "Models/Player Model", fileName = "Player Model")]
    public class PlayerModel : ScriptableObject
    {
        #region Consts

        private const float MAX_MANA = 100f;
        private const float MAX_HEALTH = 100f;

        #endregion

        #region Editor

        [SerializeField] private int _coinsBalance;
        [SerializeField] [Range(0f, 100f)] private float _mana;
        [SerializeField] [Range(0f, 100f)] private float _health;

        #endregion

        #region Events

        public event Action<int> BalanceChangedEvent;
        public event Action<float> ManaChangedEvent;
        public event Action<float> HealthChangedEvent;

        #endregion

        #region Methods

        public void AddCoins(int coinsToAdd)
        {
            _coinsBalance += coinsToAdd;
            BalanceChangedEvent?.Invoke(_coinsBalance);
        }

        public void WithdrawCoins(int coinsToWithdraw)
        {
            _coinsBalance = Mathf.Max(0, _coinsBalance - coinsToWithdraw);
            BalanceChangedEvent?.Invoke(_coinsBalance);
        }

        public void AddMana(float manaToAdd)
        {
            _mana = Mathf.Min(manaToAdd + _mana, MAX_MANA);
            ManaChangedEvent?.Invoke(_mana);
        }

        public void WithdrawMana(float manaToWithdraw)
        {
            _mana = Mathf.Max(_mana - manaToWithdraw, 0);
            ManaChangedEvent?.Invoke(_mana);
        }

        public void AddHealth(float healthToAdd)
        {
            _health = Mathf.Min(healthToAdd + _health, MAX_HEALTH);
            HealthChangedEvent?.Invoke(_health);
        }

        public void WithdrawHealth(float healthToWithdraw)
        {
            _health = Mathf.Max(_health - healthToWithdraw, 0);
            HealthChangedEvent?.Invoke(_health);
        }

        #endregion

        #region Properties

        public int CoinsBalance => _coinsBalance;
        public float Mana => _mana;
        public float Health => _health;

        #endregion
    }
}