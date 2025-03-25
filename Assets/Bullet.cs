//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Bullet : MonoBehaviour
//{


//    [Header("References")]
//    [SerializeField] private Rigidbody2D rb;

//    [Header("Attribute")]
//    [SerializeField] private float bulletSpeed = 5f;

//    private Transform target;


//    public void SetTarget(Transform _target){

//        target = _target;
//    }


//    private void FixedUpdate()
//    {
//        if (!target) return;

//        Vector2 direction = (target.position - transform.position).normalized;

//        rb.velocity = direction * bulletSpeed;

//    }

//    private void OnCollisionEnter2D(Collision2D other)
//    {
//        //take health from enemy 
//        Destroy(gameObject);
//    }


//}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody2D rb;

    [Header("Attributes")]
    [SerializeField] private float bulletSpeed = 5f;
    [SerializeField] private float lifetime = 5f; // Lifetime of the bullet

    private Transform target;

    private void Start()
    {
        // Destroy the bullet after a certain time to prevent it from existing indefinitely
        Destroy(gameObject, lifetime);
    }

    public void SetTarget(Transform _target)
    {
        target = _target;
    }

    private void Update()
    {
        if (target == null) return;

        Vector2 direction = (target.position - transform.position).normalized;
        rb.velocity = direction * bulletSpeed;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the bullet hits an enemy
        if (other.gameObject.CompareTag("Enemy")) // Assuming your enemies have the tag "Enemy"
        {
            // Here you can implement damage logic, e.g.:
            // Enemy enemy = other.gameObject.GetComponent<Enemy>();
            // enemy.TakeDamage(damageAmount);

            Destroy(gameObject); // Destroy the bullet on collision
        }
        else
        {
            // Optionally destroy the bullet if it hits something else
            Destroy(gameObject);
        }
    }
}
