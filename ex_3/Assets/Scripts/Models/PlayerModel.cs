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

        #endregion

        #region Events

        public event Action<int> BalancechangedEvent;

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

        #endregion

        #region Properties

        public int CoinsBalance => _coinsBalance;

        #endregion
    }
}