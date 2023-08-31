using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : AbsCharacterMovement
{
    private InputJoystick _inputJoystick;
    private AimsPoolContainer _aimsPoolContainer;
    private Transform _nearestAimOfPlayer;
    private float _angleOfMove;
    private float _joystickHorizontalValue;
    private float _joystickVerticalValue;


    public override void Awake()
    {
        base.Awake();
        _inputJoystick = GetComponent<InputJoystick>();
        _aimsPoolContainer = GameObject.Find("CaractersController").GetComponent<AimsPoolContainer>();
    }

    private void OnEnable()
    {
        _aimsPoolContainer.FoundNearestAimOfPlayerEvent += SetNearestAimOfPlayer;
    }
    private void OnDisable()
    {
        _aimsPoolContainer.FoundNearestAimOfPlayerEvent -= SetNearestAimOfPlayer;
    }

    public override void SetStartPosition()
    {
        _thisTransform.position = new Vector3(0, _thisCharacter.characterInfo.defaultY, _thisCharacter.commonMapInfo.mapRadius);
    }

    private void SetNearestAimOfPlayer(Transform nearestAimOfPlayer)
    {
        _nearestAimOfPlayer = nearestAimOfPlayer;
    }

    public override Transform GetAimSootTransform()
    {
        return _nearestAimOfPlayer;
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
        if (_joystickHorizontalValue > 0   &&  (_angleOfMove * Mathf.Rad2Deg) > -_thisCharacter.commonMapInfo.angleMapLimit)
        {
            _angleOfMove -= Time.fixedDeltaTime * _thisCharacter.characterInfo.speedMove;
        }

        //Left
        if (_joystickHorizontalValue < 0  && (_angleOfMove * Mathf.Rad2Deg) < _thisCharacter.commonMapInfo.angleMapLimit)
        {
            _angleOfMove += Time.fixedDeltaTime * _thisCharacter.characterInfo.speedMove;
        }
    }

    private Vector3 GetDirectionMovement()
    {
        _directionMovement.x = (-Mathf.Sin(_angleOfMove)) * _thisCharacter.commonMapInfo.mapRadius;
        _directionMovement.y = GetYJump();
        _directionMovement.z = (-Mathf.Cos(_angleOfMove)) * _thisCharacter.commonMapInfo.mapRadius;
        _directionMovement = _mapCenter.position + (_directionMovement);

        return _directionMovement;
    }

    private float GetYJump()
    {
        _joystickVerticalValue = _inputJoystick.GetVerticalValue();

        if (_joystickVerticalValue > 0   &&   _thisTransform.position.y <= _thisCharacter.characterInfo.heightJump)
        {
            return _thisTransform.position.y + (Time.fixedDeltaTime * _thisCharacter.characterInfo.speedJump);
        }
        if (_joystickVerticalValue <= 0 &&   _thisTransform.position.y > _thisCharacter.characterInfo.defaultY)
        {
            return _thisTransform.position.y - (Time.fixedDeltaTime * _thisCharacter.characterInfo.speedJump);
        }

        return _thisTransform.position.y;
    }
}
