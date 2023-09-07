using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelSwitcher : MonoBehaviour
{
    [SerializeField] private List<CharacterInfo> _playerModelInfoList;
    
    public static Dictionary<PlayerModelEnum, AbsPlayerBaseModetState> s_playerModelStateDictionary = new();

    private AbsPlayerBaseModetState _currentPlayerModelState;
    private CustomScrollView _customScrollView;

    private void Awake()
    {
        _customScrollView = GameObject.Find("UIController").GetComponent<CustomScrollView>();
        InitPlayerModelState();
        SetPlayerModelStateByDefault();
    }

    private void OnEnable()
    {
        _customScrollView.SetPlayerModelStateEvent += SetPlayerModelState;

    }
    private void OnDisable()
    {
        _customScrollView.SetPlayerModelStateEvent -= SetPlayerModelState;
    }

    private void Start()
    {
        SetPlayerModelStateByDefault();
    }

    private void InitPlayerModelState()
    {
        foreach (var item in _playerModelInfoList)
        {
            GameObject modelOfPlayer = Instantiate(item.prefabOfCharacter, transform);
            modelOfPlayer.SetActive(false);

            s_playerModelStateDictionary.Add(item.typePlayerModel, modelOfPlayer.GetComponent<AbsPlayerBaseModetState>());
        }
    }

    private void SetPlayerModelStateByDefault()
    {
        SetPlayerModelState(PlayerModelEnum.PlayerWithGun);
    }


    private void SetPlayerModelState(PlayerModelEnum playerModelEnum)
    {
        if (_currentPlayerModelState != null)
        {
            _currentPlayerModelState.Exit();
        }

        if(s_playerModelStateDictionary.TryGetValue(playerModelEnum, out AbsPlayerBaseModetState value))
        {
            _currentPlayerModelState = value;
            _currentPlayerModelState.Enter();
        }

        GlobalEventManager.ChangePlayerModelStateEvent.Invoke(playerModelEnum);
    }
}
