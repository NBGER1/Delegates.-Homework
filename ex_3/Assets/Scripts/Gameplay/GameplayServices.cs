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
            _waitService = new WaitService();
            var csgo = new GameObject("CoroutineService");
            _coroutineService = csgo.AddComponent<CoroutineService>();
            GameplayElements.Instance.PlayerView.Initialize();
            UIElements.Instance.Initialize();
        }

        #endregion

        #region Properties

        public static ICoroutineService CoroutineService => _coroutineService;
        public static IWaitService WaitService => _waitService;

        #endregion
    }
}