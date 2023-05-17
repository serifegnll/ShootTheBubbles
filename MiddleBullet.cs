using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleBullet : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public CircleGenerator circle;
    private float shootForce;
    private float maxY;
    public bool isShot = false;

    public void SetShootForce(float force)
    {
        shootForce = force;
    }

    public void StartShooting(float sceneMaxY)
    {
         maxY = sceneMaxY;
        // Call the MoveTriangle method in the Update loop to continuously move the triangle
        InvokeRepeating("MoveTriangle", 0f, Time.deltaTime);
    }

    private void MoveTriangle()
    {    
        if (isShot)
        {
        
            transform.Translate(Vector3.up * shootForce * Time.deltaTime);
            
        
            if (transform.position.y >= maxY)
            {
                Destroy(gameObject); 
            }
        }
    }

    
}
