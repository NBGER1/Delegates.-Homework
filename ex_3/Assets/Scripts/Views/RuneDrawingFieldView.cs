using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Delegates.Models;
using Infastracture;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

namespace Runes.Views
{
    public class RuneDrawingFieldView : MonoBehaviour
    {
        #region Events

        public event Action<int> RuneDrawEvent;
        public event Action RuneDrawCompleteEvent;

        #endregion

        #region Fields

        private Dictionary<string, RuneView> _runesDictionary = new Dictionary<string, RuneView>();
        private Queue<Transform> _transformQueue;
        private RuneView _runeView;

        #endregion

        #region Functions

        private void Awake()
        {
            InitializeDictionary();
        }

        private void InitializeDictionary()
        {
            _runesDictionary.Add("Star", GameplayElements.Instance.StarRune);
        }

        IEnumerator MoveRune(Vector3 endPoint, Action callback)
        {
            var moveFactor = 0f;
            var startTime = Time.time;
            do
            {
                _runeView.RuneBrush.position = Vector3.Lerp(_runeView.RuneBrush.position, endPoint, moveFactor);
                moveFactor = (Time.time - startTime) / _runeView.RuneModel.OneUnitMoveTime;
                yield return null;
            } while (moveFactor < 1f);

            callback?.Invoke();
        }

        private void DrawRune()

        {
            if (_transformQueue.Count > 0)
            {
                var target = _transformQueue.Dequeue();
                StartCoroutine(MoveRune(target.position, DrawRune));
            }
            else
            {
                RuneDrawCompleteEvent?.Invoke();
            }
        }

        private void PrepareRune()
        {
            if (GameplayElements.Instance.PlayerModel.Mana - _runeView.RuneModel.ManaCost >= 0)
            {
                RuneDrawEvent?.Invoke(_runeView.RuneModel.ManaCost);
                _runeView.RuneBrush.position = _runeView.RuneBrushOrigin.position;
                var pointsArray = _runeView.RunePoints;

                _transformQueue = new Queue<Transform>(pointsArray);
                DrawRune();
            }
        }

        public void RequestRune(string runeName)
        {
            if (!_runesDictionary.ContainsKey(runeName))
            {
                throw new NullReferenceException($"Rune {runeName} doesn't exist in the dictionary!");
            }

            _runeView = _runesDictionary[runeName];
            PrepareRune();
        }

        #endregion
    }
}