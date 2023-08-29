using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : AbsCharacterMovement
{
    private InputJoystick _inputJoystick;
    private AimsListContainer _aimsListContainer;
    private float _angleOfMove;
    private float _joystickHorizontalValue;
    private float _joystickVerticalValue;

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

        _inputJoystick = GetComponent<InputJoystick>();
        _aimsListContainer = GameObject.Find("CaractersController").GetComponent<AimsListContainer>();
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
        _joystickHorizontalValue = _inputJoystick.GetHorisontalValue();

        //Right
        if (_joystickHorizontalValue > 0   &&  (_angleOfMove * Mathf.Rad2Deg) > -_thisCharacter.CommonMapInfo.AngleMapLimit)
        {
            _angleOfMove -= Time.fixedDeltaTime * _thisCharacter.CharacterInfo.SpeedMove;
        }

        //Left
        if (_joystickHorizontalValue < 0  && (_angleOfMove * Mathf.Rad2Deg) < _thisCharacter.CommonMapInfo.AngleMapLimit)
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
        _joystickVerticalValue = _inputJoystick.GetVerticalValue();

        if (_joystickVerticalValue > 0   &&   _thisTransform.position.y <= _thisCharacter.CharacterInfo.HeightJump)
        {
            return _thisTransform.position.y + (Time.fixedDeltaTime * _thisCharacter.CharacterInfo.SpeedJump);
        }
        if (_joystickVerticalValue <= 0 &&   _thisTransform.position.y > _thisCharacter.CharacterInfo.DefaultY)
        {
            return _thisTransform.position.y - (Time.fixedDeltaTime * _thisCharacter.CharacterInfo.SpeedJump);
        }

        return _thisTransform.position.y;
    }
}
