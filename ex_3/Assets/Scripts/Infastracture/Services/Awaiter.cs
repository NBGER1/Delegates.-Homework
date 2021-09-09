using System;
using UnityEngine;

namespace Infastracture
{
    public class Awaiter : IAwaiter
    {
        #region Fields

        private Action _onStartCallback;
        private Action _onEndCallback;

        #endregion

        #region Methods

        public IAwaiter OnStart(Action onStartCallback)
        {
            _onStartCallback = onStartCallback;
            return this;
        }

        public IAwaiter OnEnd(Action onEndCallback)
        {
            _onEndCallback = onEndCallback;
            return this;
        }

        public void Start()
        {
            _onStartCallback?.Invoke();
        }

        public void End()
        {
            _onEndCallback?.Invoke();
        }

        #endregion
    }
}