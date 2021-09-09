using System;
using Delegates.Views;
using UnityEngine;

namespace Delegates.Models
{
    [CreateAssetMenu(menuName = "Models/Player Model", fileName = "Player Model")]
    public class PlayerModel : ScriptableObject
    {
        #region Editor

        [SerializeField] private int _coinsBalance;
        [SerializeField] [Range(0f, 100f)] private float _mana;

        #endregion

        #region Events

        public event Action<int> BalancechangedEvent;
        public event Action<float> ManaChangedEvent;

        #endregion

        #region Methods

        public void AddCoins(int coinsToAdd)
        {
            _coinsBalance += coinsToAdd;
            BalancechangedEvent?.Invoke(_coinsBalance);
        }

        public void WithdrawCoins(int coinsToWithdraw)
        {
            _coinsBalance = Mathf.Max(0, _coinsBalance - coinsToWithdraw);
            BalancechangedEvent?.Invoke(_coinsBalance);
        }

        public void AddMana(float manaToAdd)
        {
            _mana += manaToAdd;
            ManaChangedEvent?.Invoke(_mana);
        }

        public void WithdrawMana(float manaToWithdraw)
        {
            _mana = Mathf.Max(_mana - manaToWithdraw, 0);
            ManaChangedEvent?.Invoke(_mana);
        }

        #endregion

        #region Properties

        public int CoinsBalance => _coinsBalance;
        public float Mana => _mana;

        #endregion
    }
}