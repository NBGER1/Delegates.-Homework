using System.Collections;

namespace Infastracture
{
    public interface ICoroutineService
    {
        #region Methods

        void RunCoroutine(IEnumerator coroutine);

        #endregion
    }
}