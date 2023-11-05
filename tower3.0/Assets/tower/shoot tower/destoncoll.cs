using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destoncoll : MonoBehaviour
{

     [SerializeField] GameObject kaboom;
    private void OnCollisionEnter(Collision collision)
    {
         Destroy(this.gameObject);
        GameObject explosion = Instantiate(kaboom,transform.position, transform.rotation);
    }
   

    // Update is called once per frame
    // void Update()
    // {
        
    // }
}
