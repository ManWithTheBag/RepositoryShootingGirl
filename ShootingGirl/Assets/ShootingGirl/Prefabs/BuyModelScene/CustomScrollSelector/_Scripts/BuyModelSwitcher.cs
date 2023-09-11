using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyModelSwitcher : PlayerModelSwitcher
{
    [SerializeField] private Transform _container;
    private CustomBuyModelScrollSelector _customBuyModelScrollSelector;


    public override void Awake()
    {
        GameObject.Find("UIController").TryGetComponent(out CustomBuyModelScrollSelector customBuyModelScroll); _customBuyModelScrollSelector = customBuyModelScroll;
        _modelContainer = _container;
        
        SetupSwitcher();
    }

    public override void OnEnable()
    {
        _customBuyModelScrollSelector.SetPlayerModelStateEvent += SetPlayerModelState;
    }
    public override void OnDisable()
    {
        _customBuyModelScrollSelector.SetPlayerModelStateEvent -= SetPlayerModelState;
    }


    public override bool CheckSuitableComponents(MonoBehaviour item)
    {
        switch (item)
        {
            case AbsWeapon:
                return true;

            case AbsTakeAimCharacter:
                return true;

            default:
                return false;
        }
    }
}
