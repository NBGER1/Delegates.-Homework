using System;
using UnityEngine;

namespace Infastracture
{
    public static class GameplayServices
    {
        #region Fields

        private static ICoroutineService _coroutineService;
        private static WaitService _waitService;

        #endregion

        #region Methods

        public static void Initialize()
        {
            var csgo = new GameObject("CoroutineService");
            _coroutineService = csgo.AddComponent<CoroutineService>();
            _waitService = new WaitService();
        }

        #endregion

        #region Properties

        public static ICoroutineService CoroutineService => _coroutineService;
        public static WaitService WaitService => _waitService;

        #endregion
    }
}