using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelSwitcher : MonoBehaviour
{
    [SerializeField] private List<CharacterInfo> _playerModelInfoList;
    
    public static Dictionary<PlayerModelEnum, AbsPlayerBaseModetState> s_playerModelStateDictionary = new();

    private AbsPlayerBaseModetState _currentPlayerModelState;
    private PlayerModelScrollView _playerModelScrollView;

    private void Awake()
    {
        _playerModelScrollView = GameObject.Find("UIController").GetComponent<PlayerModelScrollView>();
        InitPlayerModelState();
        SetPlayerModelStateByDefault();
    }

    private void OnEnable()
    {
        _playerModelScrollView.playerModelScrollView.SetPlayerModelStateEvent.AddListener(SelectPlayerModelState);

    }
    private void OnDisable()
    {
        _playerModelScrollView.playerModelScrollView.SetPlayerModelStateEvent.RemoveListener(SelectPlayerModelState);
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

    private void SelectPlayerModelState(int indexModel)
    {
        SetPlayerModelState((PlayerModelEnum)indexModel);
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
        GlobalEventManager.SearchNewAimEvent.Invoke();
    }
}
