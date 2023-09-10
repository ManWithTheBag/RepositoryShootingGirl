using UnityEngine;

public class EnemyMovement : AbsCharacterMovement
{
    private RandomEnemyPosition _randomEnemyPosition;
    private Vector3 _randomDirection;

    public override void Awake()
    {
        _randomEnemyPosition = GameObject.Find("CaractersController").GetComponent<RandomEnemyPosition>();
        base.Awake();
    }

    public override void SetStartPosition()
    {
        Vector3 randomPosition = _randomEnemyPosition.GetRandomPosition();
        _thisTransform.position = new Vector3(randomPosition.x, _thisCharacter.currentCharacterInfo.defaultY, randomPosition.z);
    }

    public void Start()
    {
        GetDirectionMovement();
    }

    public override void MoveCharacter()
    {
        //TODO Coment/Uncomment for move enemys
        _thisRb.velocity = _randomDirection.normalized * _thisCharacter.currentCharacterInfo.speedMove;
    }

    private void GetDirectionMovement()
    {
        Vector3 tempDirection = _thisTransform.position - _randomEnemyPosition.centerSpawnEnemy.position;
        float angleX = Vector3.Angle(new Vector3(1, 0, 0), tempDirection);
        Vector3 angle0Position = new Vector3(_thisTransform.position.x, 0, -_thisCharacter.mapInfo.mapRadius);
        float defaulthypotenuse = _thisCharacter.mapInfo.mapRadius / (Mathf.Cos(_thisCharacter.mapInfo.angleMapLimit * Mathf.Deg2Rad));
        float defaultBottomLeg = defaulthypotenuse * (Mathf.Sin(_thisCharacter.mapInfo.angleMapLimit * Mathf.Deg2Rad));

        float randomX = 0;
        float randomZ = 0;

        float angleZ = Vector3.Angle(new Vector3(0, 0, -1), tempDirection);

        if (angleX > 0 && angleX < 90)
        {
            //Right
            float maxSuitableAngle = RightMaxSuitableAngle(angle0Position, defaultBottomLeg);
            float randomValue = Mathf.Ceil(Random.Range(0, maxSuitableAngle));

            randomX = -Mathf.Sin(-randomValue * Mathf.Deg2Rad);
            randomZ = -Mathf.Cos(-randomValue * Mathf.Deg2Rad);
        }
        else
        {
            // Left
            float maxSuitableAngle = LeftMaxSuitableAngle(angle0Position, defaultBottomLeg);
            float randomValue = Mathf.Ceil(Random.Range(0, maxSuitableAngle));

            randomZ = -Mathf.Cos(randomValue * Mathf.Deg2Rad);
            randomX = -Mathf.Sin(randomValue * Mathf.Deg2Rad);
        }

        _randomDirection = new Vector3(randomX, 0, randomZ);
    }

    private float RightMaxSuitableAngle(Vector3 angle0Position, float defaultBottomLeg)
    {
        Vector3 angleLimitPositionRight = new Vector3(defaultBottomLeg, 0, -_thisCharacter.mapInfo.mapRadius);
        float gipABright = Vector3.Distance(_thisTransform.position, angleLimitPositionRight);
        float cutBCright = Vector3.Distance(angle0Position, angleLimitPositionRight);
        //Debug.Log("Right: " + cutBCright + ";     " + gipABright);

        float maxAngleRight = Mathf.Sin((cutBCright / gipABright)) * Mathf.Rad2Deg;
        //Debug.Log( "AngleRight:" + maxAngleRight);
        return maxAngleRight;
    }

    private float LeftMaxSuitableAngle(Vector3 angle0Position, float defaultBottomLeg)
    {
        Vector3 angleLimitPositionLeft = new Vector3(-defaultBottomLeg, 0, -_thisCharacter.mapInfo.mapRadius);
        float gipABleft = Vector3.Distance(_thisTransform.position, angleLimitPositionLeft);
        float cutBCleft = Vector3.Distance(angle0Position, angleLimitPositionLeft);
        //Debug.Log("Left: " + cutBCleft + ";     " + gipABleft);

        float maxAngleLeft = Mathf.Sin((cutBCleft / gipABleft)) * Mathf.Rad2Deg;
        //Debug.Log("AngleLeft:" + maxAngleLeft);

        return maxAngleLeft;
    }
}
