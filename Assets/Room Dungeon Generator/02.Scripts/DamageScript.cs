using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
    [SerializeField] EnemyHP eHP;

    private void OnCollisionEnter(Collision collision)
    {
        EnemyHP enemyHP = collision.gameObject.GetComponent<EnemyHP>();

        
            
            if (enemyHP != null && collision.gameObject.tag == "Enemy")
            {
                enemyHP.TakeDamage(1f);
                Debug.Log("Does 1 dmg");
            }

            //eHP.TakeDamage(1f);
            //Debug.Log("Does 1 dmg");
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //EnemyHP.instance.TakeDamage(1);
            eHP.TakeDamage(1f);
            Debug.Log("Does 1 dmg");
        }
    }
}
