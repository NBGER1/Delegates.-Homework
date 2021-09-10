using UnityEngine;

namespace Delegates.Models
{
    [CreateAssetMenu(menuName = "Models/Mana Bar Model", fileName = "Mana Bar Model")]
    public class ManaBarModel : ScriptableObject
    {
        #region Editor

        [SerializeField] [Range(0f, 100f)] private float _manaFillRate;
        [SerializeField] [Range(0f, 100f)] private float _manaFillValue;

        #endregion

        #region Properties

        public float ManaFillRate => _manaFillRate;
        public float ManaFillValue => _manaFillValue;

        #endregion
    }
}