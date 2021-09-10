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

        private void OnRuneDraw(int cost)
        {
            GameplayElements.Instance.PlayerModel.WithdrawMana(cost);
        }

        #endregion
    }
}