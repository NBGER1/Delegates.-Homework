using System;
using System.Collections;
using System.Collections.Generic;
using Delegates.Models;
using Infastracture;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Runes.Views
{
    public class RuneDrawingFieldView : MonoBehaviour
    {
        #region Editor

        [SerializeField] private RuneView[] _runeViews;
        [SerializeField] private TextMeshPro _manaValueText;
        [SerializeField] private PlayerModel _playerModel;

        #region Fields

        private Stack<Transform> _runeStack;
        private Dictionary<string, int> _runesDictionary = new Dictionary<string, int>();

        #endregion

        #endregion

        #region Functions

        private void Awake()
        {
            InitializeDictionary();
        }

        private void InitializeDictionary()
        {
            _runesDictionary.Add("Star", 0);
        }

        private void DrawRuneInternal(RuneView runeView)
        {
            var transformArray = runeView.RunePoints;
            GameplayServices.WaitService
                .WaitFor(2)
                .OnStart(() => Debug.Log("On Start"))
                .OnEnd(() => Debug.Log("On End"));
        }

        public void DrawRune(string runeName)
        {
            //TODO: Create Interface?
            if (!_runesDictionary.ContainsKey(runeName))
            {
                throw new NullReferenceException($"Rune {runeName} doesn't exist in the dictionary!");
            }

            var runeIndex = _runesDictionary[runeName];
            DrawRuneInternal(GameplayElements.Instance.StarRune);
        }

        #endregion
    }
}