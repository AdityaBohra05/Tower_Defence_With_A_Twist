using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destoncoll : MonoBehaviour
{

    public float explosionRadius = 5f;
    public float explosionForce = 1000f;
    public int damage = 20;
     [SerializeField] GameObject kaboom;
    private void OnCollisionEnter(Collision collision)
    {
         Explode();
         ApplyDamage(collision.transform);
         GameObject explosion = Instantiate(kaboom,transform.position, transform.rotation);
        // Add any other explosion-related logic here
         Destroy(gameObject);
        // Destroy(this.gameObject);
       
    }
   
      void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider nearbyObject in colliders)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(explosionForce, transform.position, explosionRadius);
            }
        }

        // Optionally, destroy the explosion GameObject
        Destroy(gameObject);
    }

    void ApplyDamage(Transform target)
    {
        Health health = target.GetComponent<Health>();

        if (health != null)
        {
            health.TakeDamage(damage);
        }
    }
   
}
