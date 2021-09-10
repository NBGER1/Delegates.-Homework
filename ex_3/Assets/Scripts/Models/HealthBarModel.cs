using UnityEngine;

namespace Delegates.Models
{
    [CreateAssetMenu(menuName = "Models/Health Bar Model", fileName = "Health Bar Model")]
    public class HealthBarModel : ScriptableObject
    {
        #region Editor

        [SerializeField] [Range(0f, 100f)] private float _healthFillRate;
        [SerializeField] [Range(0f, 100f)] private float _healthFillValue;

        #endregion

        #region Properties

        public float HealthFillRate => _healthFillRate;
        public float HealthFillValue => _healthFillValue;

        #endregion
    }
}