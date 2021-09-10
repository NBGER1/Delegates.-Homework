using UnityEngine;

namespace Delegates.Models
{
    [CreateAssetMenu(menuName = "Models/Rune Model", fileName = "Rune Model")]
    public class RuneModel : ScriptableObject
    {
        #region Editor

        [SerializeField] [Range(0, 100)] private int _manaCost;
        [SerializeField] [Range(0f, 100f)] private float _damage;
        [SerializeField] [Range(0f, 10f)] private float _oneUnitMoveTime = 0.5f;
        [SerializeField] [Range(0f, 100f)] private float _heal;

        #endregion

        #region Properties

        public int ManaCost => _manaCost;
        public float Damage => _damage;
        public float Heal => _heal;
        public float OneUnitMoveTime => _oneUnitMoveTime;

        #endregion
    }
}