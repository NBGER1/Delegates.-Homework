using System;

namespace Infastracture
{
    public class Awaiter
    {
        #region Fields

        private Action _onStartCallback;
        private Action _onEndCallback;

        #endregion

        #region Methods

        public Awaiter OnStart(Action onStartCallback)
        {
            _onStartCallback = onStartCallback;
            return this;
        }

        public Awaiter OnEnd(Action onEndCallback)
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