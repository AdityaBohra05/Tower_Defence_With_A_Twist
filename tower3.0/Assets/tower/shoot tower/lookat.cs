using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lookat : MonoBehaviour
{
    public GameObject Target;
    public GameObject Target2;
    public GameObject projectile;
    bool alreadyAttacked;
    public float timeBetweenAttacks;

   

    void Update()
    {
        AttackPlayer();

        
    }


    private void AttackPlayer()
    {
        // //Make sure enemy doesn't move
        // agent.SetDestination(transform.position);

        // transform.LookAt(player);

        transform.LookAt(Target.transform.position);

        if (!alreadyAttacked)
        {
            ///Attack code here
            Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            ///End of attack code

            alreadyAttacked = true;
            Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }


     private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
