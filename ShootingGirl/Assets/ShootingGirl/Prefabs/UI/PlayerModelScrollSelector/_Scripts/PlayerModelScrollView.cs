using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelScrollView : MonoBehaviour
{
    [SerializeField] private ScrollView _playerModelScrollView;

    public ScrollView playerModelScrollView { get { return _playerModelScrollView; } private set { _playerModelScrollView = value; } }
}
