using System.Security.Policy;
using Delegates.Models;
using UnityEditor;
using UnityEngine;

namespace Delegates
{
    [CustomEditor(typeof(PlayerModel))]
    public class PlayerModelInspector : Editor
    {
        #region Consts

        private const int COINS_TO_ADD = 10;
        private const int COINS_TO_WITHDRAW = 10;
        private const float MANA_TO_ADD = 10;
        private const float MANA_TO_WITHDRAW = 10;
        private const float HEALTH_TO_ADD = 10;
        private const float HEALTH_TO_WITHDRAW = 10;

        #endregion

        #region Fields

        private PlayerModel _playerModel;

        #endregion

        #region Methods

        public override void OnInspectorGUI()
        {
            _playerModel = target as PlayerModel;
            BalanceGUI();
            ManaGUI();
            HealthGUI();
        }

        private void HealthGUI()
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label("Player Health");
            GUILayout.TextField(_playerModel.Health.ToString());
            if (GUILayout.Button("+"))
            {
                _playerModel.AddHealth(HEALTH_TO_ADD);
            }

            if (GUILayout.Button("-"))
            {
                _playerModel.WithdrawHealth(HEALTH_TO_WITHDRAW);
            }

            GUILayout.EndHorizontal();
        }

        private void BalanceGUI()
        {
            GUILayout.Label("Player Model", EditorStyles.boldLabel);
            GUILayout.Space(10);
            GUILayout.BeginHorizontal();
            GUILayout.Label("Coins Balance");
            GUILayout.TextField(_playerModel.CoinsBalance.ToString());

            if (GUILayout.Button("+"))
            {
                _playerModel.AddCoins(COINS_TO_ADD);
            }

            if (GUILayout.Button("-"))
            {
                _playerModel.WithdrawCoins(COINS_TO_WITHDRAW);
            }

            GUILayout.EndHorizontal();
        }

        private void ManaGUI()
        {
            // GUILayout.Space(10);
            GUILayout.BeginHorizontal();
            GUILayout.Label("Player Mana");
            GUILayout.TextField(_playerModel.Mana.ToString());
            if (GUILayout.Button("+"))
            {
                _playerModel.AddMana(MANA_TO_ADD);
            }

            if (GUILayout.Button("-"))
            {
                _playerModel.WithdrawMana(MANA_TO_WITHDRAW);
            }

            GUILayout.EndHorizontal();
        }

        #endregion
    }
}