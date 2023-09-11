using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerButtonFields : MonoBehaviour
{
    [SerializeField] private ShotButton _shotButton;
    [SerializeField] private Image _overheatFillImage;
    [SerializeField] private Button _launchMortarSkillButton;


    public ShotButton shotButton { get { return _shotButton; } private set { _shotButton = value; } }
    public Image overheatFillImage { get { return _overheatFillImage; } private set { _overheatFillImage = value; } }
    public Button launchMortarSkillButton { get { return _launchMortarSkillButton; } private set { _launchMortarSkillButton = value; } }

}
