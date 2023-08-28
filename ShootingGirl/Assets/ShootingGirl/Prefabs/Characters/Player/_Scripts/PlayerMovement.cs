using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : AbsCharacterMovement
{

    private AimsListContainer _aimsListContainer;
    private float _angleOfMove;
    private float _inputAxis;
    private bool _isJump;

    private void OnEnable()
    {
        GlobalEventManager.SearchNewAimEvent.AddListener(SetAimTransform);
    }
    private void OnDisable()
    {
        GlobalEventManager.SearchNewAimEvent.RemoveListener(SetAimTransform);
    }

    public override void Awake()
    {
        base.Awake();

        _aimsListContainer = GameObject.Find("CaractersController").GetComponent<AimsListContainer>();
    }

    private void Update()
    {
        CheckMoveButton();
        CheckJumpButton();
        CheckRefreshAimButton();
    }

    //TODO Chenge on the UI button
    private void CheckMoveButton()
    {
        _inputAxis = Input.GetAxis("Horizontal");
    }
    private void CheckJumpButton()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            _isJump = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            _isJump = false;
        }
    }
    private void CheckRefreshAimButton()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SetAimTransform();
        }
    }

    public override void SetStartPosition()
    {
        _thisTransform.position = new Vector3(0, _thisCharacter.CharacterInfo.DefaultY, _thisCharacter.CommonMapInfo.MapRadius);
    }

    public override void SetAimTransform()
    {
        _aimTransform = _aimsListContainer.GetSortedAimList()[0].SortTransform;
    }

    public override void MoveCharacter()
    {
        CalculateAngle();
        _thisRb.MovePosition(GetDirectionMovement());
    }

    private void CalculateAngle()
    {
        if (_inputAxis > 0 && (_angleOfMove * Mathf.Rad2Deg) < _thisCharacter.CommonMapInfo.AngleMapLimit)
        {
            _angleOfMove -= Time.fixedDeltaTime * _thisCharacter.CharacterInfo.SpeedMove;
        }
        if (_inputAxis < 0 && (_angleOfMove * Mathf.Rad2Deg) > - _thisCharacter.CommonMapInfo.AngleMapLimit)
        {
            _angleOfMove += Time.fixedDeltaTime * _thisCharacter.CharacterInfo.SpeedMove;
        }
    }

    private Vector3 GetDirectionMovement()
    {
        _directionMovement.x = (-Mathf.Sin(_angleOfMove)) * _thisCharacter.CommonMapInfo.MapRadius;
        _directionMovement.y = GetYJump();
        _directionMovement.z = (-Mathf.Cos(_angleOfMove)) * _thisCharacter.CommonMapInfo.MapRadius;
        _directionMovement = _mapCenter.position + (_directionMovement);

        return _directionMovement;
    }

    private float GetYJump()
    {
        if(_isJump == true   &&   _thisTransform.position.y <= _thisCharacter.CharacterInfo.HeightJump)
        {
            return _thisTransform.position.y + (Time.fixedDeltaTime * _thisCharacter.CharacterInfo.SpeedJump);
        }
        if (_isJump == false   &&   _thisTransform.position.y > _thisCharacter.CharacterInfo.DefaultY)
        {
            return _thisTransform.position.y - (Time.fixedDeltaTime * _thisCharacter.CharacterInfo.SpeedJump);
        }

        return _thisTransform.position.y;
    }
}
