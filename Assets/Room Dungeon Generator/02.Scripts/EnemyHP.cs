using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
   //public EnemyHP instance;

    [SerializeField] int HP=0;
    [SerializeField] int MaxHP = 3;

    // Start is called before the first frame update
    void Start()
    {
        HP = MaxHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TakeDamage(int damage)
    {
        HP -= damage;
        Debug.Log("takes 1 dmg");

        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Death() 
    {
        if (HP <= 0)
        {
            Destroy(gameObject);
        }
    }

}
