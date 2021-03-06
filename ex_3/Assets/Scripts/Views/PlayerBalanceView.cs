using System;
using Delegates.Models;
using Infastracture;
using TMPro;
using UnityEngine;
using UnityEngine.PlayerLoop;

namespace Delegates.Views
{
    public class PlayerBalanceView : MonoBehaviour
    {
        #region Editor

        [SerializeField] private TMP_Text _coinsBalance;

        [SerializeField] private PlayerModel _playerModel;

        #endregion


        #region Methods

        private void Awake()
        {
            UpdateCoinsBalance();
            _playerModel.BalanceChangedEvent += OnBalanceUpdate;
        }

        private void OnDestroy()
        {
            _playerModel.BalanceChangedEvent -= OnBalanceUpdate;
        }

        private void UpdateCoinsBalance()
        {
            _coinsBalance.text = _playerModel.CoinsBalance.ToString();
        }

        private void OnBalanceUpdate(int balance)
        {
            UpdateCoinsBalance();
        }

     

        #endregion
    }
}