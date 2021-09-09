using Services;
using UnityEngine;

namespace Infastracture
{
    public class GameplayElements : Singleton<GameplayElements>
    {
        #region Editor

        [SerializeField] private RuneView _starRune;

        #endregion

        #region Properties

        public RuneView StarRune => _starRune;

        #endregion

        protected override GameplayElements GetInstance()
        {
            return this;
        }
    }
}