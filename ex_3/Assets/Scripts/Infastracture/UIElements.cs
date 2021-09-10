using System.Collections;
using System.Collections.Generic;
using Services;
using UnityEngine;
using Views;

public class UIElements : Singleton<UIElements>
{
    #region Fields

    [SerializeField] private HealthBarView _healthBarView;
    [SerializeField] private ManaBarView _manaBarView;

    #endregion

    #region Methods

    public void Initialize()
    {
        _healthBarView.Initialize();
        _manaBarView.Initialize();
    }

    protected override UIElements GetInstance()
    {
        return this;
    }

    #endregion
}