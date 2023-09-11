using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitTrigger : MonoBehaviour
{
    private AbsTakingDamage _absTakingDamage;
    private Transform _thisTransform;

    private void Awake()
    {
        _absTakingDamage = GetComponent<AbsTakingDamage>();
        _thisTransform = transform;
    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.transform.TryGetComponent(out IDamaging iDamaging))
        {
            other.transform.TryGetComponent(out IRefreshible iRefreshable);
            iRefreshable.TotalRefresh();

            if (CheckTeamKill(iDamaging.shootsCharacter))
            {
                _absTakingDamage.TakeDamage(iDamaging.damage);
            }
        }
    }


    private bool CheckTeamKill(Transform shootsCharacter)
    {
        return shootsCharacter.tag != _thisTransform.tag ? true : false;
    }

}
