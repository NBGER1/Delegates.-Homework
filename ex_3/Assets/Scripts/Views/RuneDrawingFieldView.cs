using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
    
namespace Runes.Views
{
    public class RuneDrawingFieldView : MonoBehaviour
    {
        #region Editor

        [SerializeField]
        private Transform[] _runePoints;

        [SerializeField]
        private Transform _runeBrush;

        [SerializeField]
        private float _oneUnitMoveTime = 0.5f;
        
        #endregion

        #region Functions
        
        public void DrawRune()
        {
        }

        #endregion
    }
}