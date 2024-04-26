using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageScript : MonoBehaviour
{
   

    private void OnCollisionEnter(Collision collision)
    {
       

        
            
            if (collision.gameObject.tag == "Enemy")
            {
                  EnemyHP enemyHP = collision.gameObject.GetComponent<EnemyHP>();
            if (enemyHP)
            {
                //enemyHP.TakeDamage(1f);
                Debug.Log("Does 1 dmg");
            }
                    
            }

            //eHP.TakeDamage(1f);
            //Debug.Log("Does 1 dmg");
        
    }

   
}
