using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform _target;
    [SerializeField] float _damage = 2f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Animation Event
    public void AttackHitEvent()
    {
        if (_target == null) return;

        _target.GetComponent<Health>().TakeDamage(_damage);

    }
}
