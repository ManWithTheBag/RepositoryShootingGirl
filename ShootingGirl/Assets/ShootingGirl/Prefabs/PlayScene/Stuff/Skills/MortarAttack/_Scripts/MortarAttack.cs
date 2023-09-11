using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MortarAttack : AbsSkill
{
    [SerializeField] [Min(3)] private int _amountMortarLaunchers;
    [SerializeField] [Min(0)] private float _ofsetZposition;

    private AimsPoolContainer _aimsPoolContainer;
    protected PlayerButtonFields _playerButtonFielsd;
    private PoolShellMortar _poolShellMortar;
    private GameObject _mortarContainer;
    private List<Transform> _startTransformList = new();

    public override void Awake()
    {
        base.Awake();

        _poolShellMortar = GameObject.Find("ShellCotroller").GetComponent<ShellPoolContainer>().poolShellMortar;
        _aimsPoolContainer = GameObject.Find("CaractersController").GetComponent<AimsPoolContainer>();
        _playerButtonFielsd = GameObject.Find("UIController").GetComponent<PlayerButtonFields>();
        _mortarContainer = GameObject.Find("MortartAttack");
        
        CalculateLauncherPosition();
    }

    public override void OnEnable()
    {
        base.OnEnable();
        _playerButtonFielsd.launchMortarSkillButton.onClick.AddListener(ActivateSkillButton);
    }
    public override void OnDisable()
    {
        base.OnDisable();
        _playerButtonFielsd.launchMortarSkillButton.onClick.RemoveListener(ActivateSkillButton);
    }

    private void CalculateLauncherPosition()
    {
        float leg = (Mathf.Abs(_mapInfo.mapRadius * (Mathf.Tan(Mathf.Deg2Rad * _mapInfo.angleMapLimit))));
        float parcent = 0;

        for (int i = 0; i <= _amountMortarLaunchers; i++)
        {
            float xPosition = Mathf.Lerp( - leg, leg, parcent);
            parcent += 1f / (_amountMortarLaunchers -1);

            Transform startTransform = new GameObject("Mortar").transform;
            startTransform.parent = _mortarContainer.transform;
            startTransform.position = new Vector3(xPosition, 1, - (_mapInfo.mapRadius + _ofsetZposition));
            _startTransformList.Add(startTransform);
        }
    }

    private void ActivateSkillButton()
    {
        TryToUseSkill();
    }

    public override void UseSkill()
    {
        List<IDistanceToAimsComparable> tempAimList = _aimsPoolContainer.GetSortedActiveAimList();

        for (int i = 0; i < _startTransformList.Count; i++)
        {
            if(tempAimList.Count > i)
            {
                AbsShell shell = _poolShellMortar.GetElement();
                shell.SetShellData(_skillsInfo.damage, Player.s_playerTransform);
                shell.SetPropertyToFlight(_skillsInfo.timeToFlight, _skillsInfo.maxHeight, _skillsInfo.radiusExplosion);
                shell.SetPositions(_startTransformList[i], tempAimList[i].thisTransform);
                shell.SetAutoTakeAim(true);

                shell.SetVisibleStatusGO(true);
            }
        }
    }
}
