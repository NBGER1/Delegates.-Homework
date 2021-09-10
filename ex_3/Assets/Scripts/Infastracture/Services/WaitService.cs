using System;
using System.Collections;
using UnityEngine;

namespace Infastracture
{
    public class WaitService : IWaitService
    {
        #region Methods

        public IAwaiter WaitFor(float delay)
        {
            var awaiter = new Awaiter();
            GameplayServices.CoroutineService.RunCoroutine(WaitForInternal(delay, awaiter));
            return awaiter;
        }

        private IEnumerator WaitForInternal(float delay, IAwaiter awaiter)
        {
            yield return null;
            awaiter.Start();
            yield return new WaitForSeconds(delay);
            awaiter.End();
        }

        #endregion
    }
}