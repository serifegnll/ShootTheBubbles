using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SquareScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

   public CircleGenerator circleObject;

private void Update()
{
       
    }

private bool IsCollidingWithCircle()
{
    // Square ve daire objelerinin pozisyonlarını al
    Vector3 squarePosition = transform.position;
    Vector3 circlePosition = circleObject.transform.position;

    // İki objenin pozisyonları arasındaki mesafeyi hesapla
    float collisionDistance = 1f; // Çarpışma mesafesi eşiği
    float distance = Vector3.Distance(squarePosition, circlePosition);

    // Mesafe kontrolü yap ve çarpışmayı döndür
    return distance < collisionDistance;
}
}
