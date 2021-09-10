using Delegates.Models;
using Runes.Views;
using Services;
using UnityEngine;
using UnityEngine.UIElements;
using Views;

namespace Infastracture
{
    public class GameplayElements : Singleton<GameplayElements>
    {
        #region Editor

        [SerializeField] private RuneView _starRune;
        [SerializeField] private RuneView _eyeRune;
        [SerializeField] private RuneView _sunRune;

        [SerializeField] private PlayerModel _playerModel;
        [SerializeField] private RuneDrawingFieldView _runeDrawingFieldView;
        [SerializeField] private PlayerView _playerView;

        #endregion


        #region Properties

        public RuneView StarRune => _starRune;
        public RuneView SunRune => _sunRune;

        public RuneView EyeRune => _eyeRune;
        public PlayerModel PlayerModel => _playerModel;
        public PlayerView PlayerView => _playerView;
        public RuneDrawingFieldView RuneDrawingFieldView => _runeDrawingFieldView;

        protected override GameplayElements GetInstance()
        {
            return this;
        }

        #endregion
    }
}