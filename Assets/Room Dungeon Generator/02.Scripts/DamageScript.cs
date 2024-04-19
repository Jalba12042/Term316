using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    [SerializeField] EnemyHP eHP;

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            eHP.TakeDamage(1);
            Debug.Log("Does 1 dmg");
        }
    }
}
