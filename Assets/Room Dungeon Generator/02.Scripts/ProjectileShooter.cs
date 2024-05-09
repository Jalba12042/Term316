using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float fireRate = 1f; 
    public float projectileSpeed = 10f; 
    public float projectileLifetime = 3f;
    public Animator ani;

    private Camera mainCamera;
    private float nextFireTime;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1") && Time.time >= nextFireTime)
        {
            nextFireTime = Time.time + 1f / fireRate;
            FireProjectile();
            ani.SetTrigger("Attack");
        }
    }

    void FireProjectile()
    {
        // Create a projectile at the center of the camera view
        Vector3 spawnPosition = mainCamera.transform.position + mainCamera.transform.forward;
        GameObject projectile = Instantiate(projectilePrefab, spawnPosition, Quaternion.identity);

        // Get the rigidbody of the projectile and set its velocity to move it forward
        Rigidbody projectileRigidbody = projectile.GetComponent<Rigidbody>();
        if (projectileRigidbody != null)
        {
            projectileRigidbody.velocity = mainCamera.transform.forward * projectileSpeed;
        }

        // Destroy the projectile after the specified lifetime
        Destroy(projectile, projectileLifetime);
    }
}
