﻿using System;
using UnityEngine;

namespace Infastracture
{
    public static class GameplayServices
    {
        #region Fields

        private static ICoroutineService _coroutineService;
        private static IWaitService _waitService;

        #endregion

        #region Methods

        public static void Initialize()
        {
            var csgo = new GameObject("CoroutineService");
            _coroutineService = csgo.AddComponent<CoroutineService>();
        }

        #endregion

        #region Properties

        public static ICoroutineService CoroutineService => _coroutineService;
        public static IWaitService WaitService => _waitService;

        #endregion
    }
}