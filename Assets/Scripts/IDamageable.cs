using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable 
{
    int EnemyHealth { get; set; }
    void Damage();
}
