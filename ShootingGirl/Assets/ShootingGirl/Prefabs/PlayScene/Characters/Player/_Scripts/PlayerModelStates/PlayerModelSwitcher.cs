using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerModelSwitcher : MonoBehaviour
{
    [SerializeField] protected List<CharacterInfo> _playerModelInfoList;
    
    public static Dictionary<PlayerModelEnum, AbsPlayerBaseModetState> s_playerModelStateDictionary = new();
    
    protected Transform _modelContainer;

    private AbsPlayerBaseModetState _currentPlayerModelState;
    private CustomScrollView _customScrollView;

    public virtual void Awake()
    {
        GameObject.Find("UIController").TryGetComponent(out CustomScrollView customScrollView); _customScrollView = customScrollView;
        _modelContainer = transform;
        SetupSwitcher();
    }

    protected void SetupSwitcher()
    {
        InitPlayerModelState();
        SetPlayerModelStateByDefault();
    }

    public virtual void OnEnable()
    {
        _customScrollView.SetPlayerModelStateEvent += SetPlayerModelState;

    }
    public virtual void OnDisable()
    {
        _customScrollView.SetPlayerModelStateEvent -= SetPlayerModelState;
    }

    private void Start()
    {
        SetPlayerModelStateByDefault();
    }

    private void InitPlayerModelState()
    {
        s_playerModelStateDictionary.Clear();

        foreach (var item in _playerModelInfoList)
        {
            GameObject modelOfPlayer = Instantiate(item.prefabOfCharacter, _modelContainer);
            SetupModelForBuyScroller(modelOfPlayer);

            s_playerModelStateDictionary.Add(item.typePlayerModel, modelOfPlayer.GetComponent<AbsPlayerBaseModetState>());
        }
    }

    private void SetupModelForBuyScroller(GameObject modelOfPlayer)
    {
        modelOfPlayer.SetActive(false);
        foreach (MonoBehaviour item in modelOfPlayer.GetComponents(typeof(MonoBehaviour)))
        {
            if (CheckSuitableComponents(item))
                item.enabled = false;
            else
                item.enabled = true;
        }
    }

    public virtual bool CheckSuitableComponents(MonoBehaviour item) => false;

    
    private void SetPlayerModelStateByDefault()
    {
        SetPlayerModelState(PlayerModelEnum.PlayerWithGun);
    }


    protected void SetPlayerModelState(PlayerModelEnum playerModelEnum)
    {
        if (_currentPlayerModelState != null)
            _currentPlayerModelState.Exit();


        if(s_playerModelStateDictionary.TryGetValue(playerModelEnum, out AbsPlayerBaseModetState value))
        {
            _currentPlayerModelState = value;
            _currentPlayerModelState.Enter();
        }

        GlobalEventManager.ChangePlayerModelStateEvent.Invoke(playerModelEnum);
    }
}
