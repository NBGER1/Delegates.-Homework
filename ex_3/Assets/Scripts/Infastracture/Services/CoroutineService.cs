using System.Collections;
using UnityEngine;

namespace Infastracture
{
    public class CoroutineService : MonoBehaviour, ICoroutineService
    {
        public void RunCoroutine(IEnumerator coroutine)
        {
            StartCoroutine(coroutine);
        }
    }
}