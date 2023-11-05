using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("Aim")]
    [SerializeField] private bool aim;
    [SerializeField] private bool ignoreHeight;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private Transform aimedTransform;

     [Header("Laser")]
    public Transform FirePoint;
    public GameObject Fire;
    public GameObject HitPoint;




     private Camera mainCamera;
      private void Start()
        {
            mainCamera = Camera.main;

          
        }
    void Update()
    {
        Aim();
        // if(Input.GetKeyDown(KeyCode.Space))
        // {
        //     Shooting();
        // }
        if(Input.GetMouseButtonDown(0))
        {
             Shooting();
        }

       
        
    }

     private void Aim()
        {
            if (aim == false)
            {
                return;
            }

            var (success, position) = GetMousePosition();
            if (success)
            {
                // Direction is usually normalized, 
                // but it does not matter in this case.
                var direction = position - aimedTransform.position;

                if (ignoreHeight)
                {
                    // Ignore the height difference.
                    direction.y = 0;
                }

                // Make the transform look at the mouse position.
               aimedTransform.forward = direction;
            }
        }

        private (bool success, Vector3 position) GetMousePosition()
        {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, groundMask))
            {
                return (success: true, position: hitInfo.point);
            }
            else
            {
                return (success: false, position: Vector3.zero);
            }
        }

    public void Shooting()
    {
        RaycastHit hit;

        if(Physics.Raycast(FirePoint.position, transform.TransformDirection(Vector3.forward),out hit,1000))
        {
                Debug.DrawRay(FirePoint.position,transform.TransformDirection(Vector3.forward)*hit.distance, Color.yellow);
        }




        enemyH enemy = hit.transform.GetComponent<enemyH>();

        if(enemy != null)
        {
            enemy.Damage(2);
        }
    }
}
