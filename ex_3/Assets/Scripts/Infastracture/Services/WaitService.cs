﻿using System;
using System.Collections;
using UnityEngine;

namespace Infastracture
{
    public class WaitService
    {
        #region Methods

        public Awaiter WaitFor(float delay)
        {
            var awaiter = new Awaiter();
            GameplayServices.CoroutineService.RunCoroutine(WaitForInternal(delay, awaiter));
            return awaiter;
        }

        private IEnumerator WaitForInternal(float delay, Awaiter awaiter)
        {
            awaiter.Start();
            yield return new WaitForSeconds(delay);
            awaiter.End();
        }

        #endregion
    }
}