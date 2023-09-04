using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelSwitcher : MonoBehaviour
{
    [SerializeField] private List<CharacterInfo> _playerModelInfoList;
    
    public static Dictionary<PlayerModelEnum, AbsPlayerBaseModetState> s_playerModelStateDictionary = new();

    private AbsPlayerBaseModetState _currentPlayerModelState;
    private PlayerButtonController _playerButtonController;

    private void Awake()
    {
        _playerButtonController = GameObject.Find("UIController").GetComponent<PlayerButtonController>();
        InitPlayerModelState();
        SetPlayerModelStateByDefault();
    }

    private void OnEnable()
    {
        _playerButtonController.activalePlayerWithGun.onClick.AddListener(SetPlayerWithGun);
        _playerButtonController.activatePlayerWithGunmachine.onClick.AddListener(SetPlayerWithGanmachine);
        _playerButtonController.activatePlayerWothRocket.onClick.AddListener(SetPlayerWithRocket);

    }
    private void OnDisable()
    {
        _playerButtonController.activalePlayerWithGun.onClick.RemoveListener(SetPlayerWithGun);
        _playerButtonController.activatePlayerWithGunmachine.onClick.RemoveListener(SetPlayerWithGanmachine);
        _playerButtonController.activatePlayerWothRocket.onClick.RemoveListener(SetPlayerWithRocket);
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
        GlobalEventManager.SearchNewAimEvent.Invoke();
    }

    private void SetPlayerWithGun()
    {
        SetPlayerModelState(PlayerModelEnum.PlayerWithGun);
    }
    private void SetPlayerWithGanmachine()
    {
        SetPlayerModelState(PlayerModelEnum.PlayerWithGunmachine);

    }
    private void SetPlayerWithRocket()
    {
        SetPlayerModelState(PlayerModelEnum.PlayerWithRocket);
    }
}
