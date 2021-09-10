using System;
using Infastracture;
using UnityEngine;

namespace Views
{
    public class PlayerView : MonoBehaviour
    {
        #region Methods

        public void Initialize()
        {
            GameplayElements.Instance.RuneDrawingFieldView.RuneDrawEvent += OnRuneDraw;
        }

        private void OnDestroy()
        {
            GameplayElements.Instance.RuneDrawingFieldView.RuneDrawEvent -= OnRuneDraw;
        }

        private void OnRuneDraw(int cost, float heal, float damage)
        {
            Debug.Log($"Cost {cost} Heal {heal} Damage {damage}");
            GameplayElements.Instance.PlayerModel.WithdrawMana(cost);
            GameplayElements.Instance.PlayerModel.AddHealth(heal);
            GameplayElements.Instance.PlayerModel.WithdrawHealth(damage);
        }

        #endregion
    }
}