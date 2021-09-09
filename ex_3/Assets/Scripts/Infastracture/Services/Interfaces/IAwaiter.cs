using System;

namespace Infastracture
{
    public interface IAwaiter
    {
        #region Methods

        IAwaiter OnStart(Action onStartCallback);
        IAwaiter OnEnd(Action onEndCallback);
        void Start();
        void End();

        #endregion
    }
}