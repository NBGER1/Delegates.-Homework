using System;
using UnityEngine;

namespace Infastracture
{
    public class AppEntry : MonoBehaviour
    {
        private void Awake()
        {
            GameplayServices.Initialize();
        }
    }
}