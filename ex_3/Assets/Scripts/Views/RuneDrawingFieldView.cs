using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
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

        [SerializeField] private TextMeshPro _manaValueText;
        [SerializeField] private PlayerModel _playerModel;

        #region Fields

        private Dictionary<string, int> _runesDictionary = new Dictionary<string, int>();
        private Queue<Transform> _transformQueue;
        private RuneView _runeView;

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

        private void DrawRuneInternal()
        {
        }

        private void DrawRune()

        {
            if (_transformQueue.Count > 0)
            {
                var target = _transformQueue.Dequeue();
                StartCoroutine(MoveRune(target.position, DrawRune));
            }
        }

        private void PrepareRune()
        {
            _runeView.RuneBrush.position = _runeView.RuneBrushOrigin.position;
            var pointsArray = _runeView.RunePoints;

            _transformQueue = new Queue<Transform>(pointsArray);
            DrawRune();
        }

        public void RequestRune(string runeName)
        {
            //TODO: Create Interface?
            if (!_runesDictionary.ContainsKey(runeName))
            {
                throw new NullReferenceException($"Rune {runeName} doesn't exist in the dictionary!");
            }

            _runeView = GameplayElements.Instance.StarRune;
            PrepareRune();
        }

        #endregion
    }
}