using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    public float maxHealth = 3f;
    public GameObject speedItem;
    public GameObject damageItem;
    public float dropChance = 0.5f;
    public float dropChanceDamage = 1.5f;

    public float currentHealth;
    public float minDropChanceAttack = 1.0f;
    public float maxDropChanceAttack = 1.99f;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            this.TakeDamage(1f);
            Debug.Log("Takes 1 dmg");
            Destroy(collision.gameObject);
        }
    }

    private void Die()
    {
        float randomValueDamage = Random.Range(minDropChanceAttack, maxDropChanceAttack);
        float randomValue = Random.value;

        if (currentHealth <= 0 && randomValue <= dropChance)
        {
            Instantiate(speedItem, transform.position, Quaternion.identity);
        }

        else if (currentHealth <= 0 && randomValueDamage <= dropChanceDamage)
        {
            Instantiate(damageItem, transform.position, Quaternion.identity);
        }

        GameManager.instance.PointsToWin++;

        // Debug
        Destroy(gameObject);
        Debug.Log(randomValue);
        Debug.Log(randomValueDamage);
    }


}
