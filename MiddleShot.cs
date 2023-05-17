using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleShot : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public GameObject trianglePrefab;
    public float shootForce = 10f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate a new triangle object
    GameObject triangle = Instantiate(trianglePrefab, transform.position, Quaternion.identity);

    // Get the triangle's script component, if it has one
    MiddleBullet bullet = triangle.GetComponent<MiddleBullet>();

    // Set the shoot force of the triangle
    bullet.SetShootForce(shootForce);

    // Pass the maximum y-coordinate of the scene to the StartShooting method
    float maxY = 4.8f;
    bullet.StartShooting(maxY);
    bullet.isShot = true;
    }
}
