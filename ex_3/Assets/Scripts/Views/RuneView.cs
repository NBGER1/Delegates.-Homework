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
    #endregion

    #region Properties

    public RuneModel RuneModel => _runeModel;
    public Transform[] RunePoints => _runePoints;

    #endregion
}