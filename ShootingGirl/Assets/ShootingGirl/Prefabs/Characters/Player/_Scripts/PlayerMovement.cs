using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : AbsCharacterMovement
{
    private InputJoystick _inputJoystick;
    private float _angleOfMove;
    private float _joystickHorizontalValue;
    private float _joystickVerticalValue;
    private float _yPosition;

    public override void Awake()
    {
        base.Awake();
        _inputJoystick = GetComponent<InputJoystick>();
    }

    public override void SetStartPosition()
    {
        _thisTransform.position = new Vector3(0, _thisCharacter.currentCharacterInfo.defaultY, _thisCharacter.commonMapInfo.mapRadius);
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
            _angleOfMove -= Time.fixedDeltaTime * _thisCharacter.currentCharacterInfo.speedMove;
        }

        //Left
        if (_joystickHorizontalValue < 0  && (_angleOfMove * Mathf.Rad2Deg) < _thisCharacter.commonMapInfo.angleMapLimit)
        {
            _angleOfMove += Time.fixedDeltaTime * _thisCharacter.currentCharacterInfo.speedMove;
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

        if (_joystickVerticalValue > 0   &&   _thisTransform.position.y <= _thisCharacter.currentCharacterInfo.heightJump)
        {
            return _thisTransform.position.y + (Time.fixedDeltaTime * _thisCharacter.currentCharacterInfo.speedJump);
        }

        if (_joystickVerticalValue <= 0 )
        {
            _yPosition = _thisTransform.position.y - (Time.fixedDeltaTime * _thisCharacter.currentCharacterInfo.speedJump);

            if (_yPosition <= _thisCharacter.currentCharacterInfo.defaultY)
            {
                return _thisCharacter.currentCharacterInfo.defaultY;
            }
            else
            {
                return _yPosition;
            }
        }

        return _thisTransform.position.y;
    }
}
