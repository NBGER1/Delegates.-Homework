using System.Collections;

namespace Infastracture
{
    public interface ICoroutineService
    {
        void RunCoroutine(IEnumerator coroutine);
    }
}