using System.Collections;
using System.Collections.Generic;
using Delegates.Models;
using UnityEngine;

public class RuneView : MonoBehaviour
{
    #region Editor

    [SerializeField] private RuneModel _runeModel;
    [SerializeField] private Transform[] _runePoints;
    [SerializeField] private Transform _runeBrush;
    [SerializeField] private Transform _runeBrushOrigin;

    #endregion

    #region Properties

    public RuneModel RuneModel => _runeModel;
    public Transform[] RunePoints => _runePoints;
    public Transform RuneBrush => _runeBrush;
    public Transform RuneBrushOrigin => _runeBrushOrigin;

    #endregion
}