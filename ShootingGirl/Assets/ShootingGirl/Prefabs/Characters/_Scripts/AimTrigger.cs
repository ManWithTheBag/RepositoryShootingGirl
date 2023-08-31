using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTrigger : MonoBehaviour
{
    private TakingDamage _takingDamage;
    private Transform _thisTransform;

    private void Awake()
    {
        _takingDamage = GetComponent<TakingDamage>();
        _thisTransform = transform;
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.transform.TryGetComponent(out IDamaging iDamaging))
        {
            collision.transform.TryGetComponent(out IRefreshible iRefreshable);
            iRefreshable.TotalRefresh();

            if (CheckTeamKill(iDamaging.shootsCharacter))
            {
                _takingDamage.TakeDamage(iDamaging.damage);
            }
        }
    }


    private bool CheckTeamKill(Transform shootsCharacter)
    {
        return shootsCharacter.tag != _thisTransform.tag ? true : false;
    }

}
