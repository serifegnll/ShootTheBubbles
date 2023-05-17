using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterCode : MonoBehaviour
{
   
    public float moveSpeed = 60f;
    public float frameSize = 11f;
    public float objectWidth = 2f;

    private float minX;
    private float maxX;
    
    void Start()
    {       
        minX = -frameSize + (objectWidth / 2f);
        maxX = frameSize - (objectWidth / 2f);
    }

    // Update is called once per frame
    void Update()
    {
       
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, 0f);
        Vector3 newPosition = transform.position + movementDirection * moveSpeed * Time.deltaTime;

        float clampedX = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition = new Vector3(clampedX, transform.position.y, transform.position.z);

        transform.position = newPosition;
    }
}
