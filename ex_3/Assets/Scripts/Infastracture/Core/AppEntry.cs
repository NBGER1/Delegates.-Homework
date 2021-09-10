using System;
using UnityEngine;

namespace Infastracture
{
    public class AppEntry : MonoBehaviour
    {
        #region Methods

        private void Awake()
        {
            GameplayServices.Initialize();
        }

        #endregion
     
    }
}