using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class CircleGenerator : MonoBehaviour
{
   

void Start()
{
   
}

public GameObject circlePrefab; // Daire prefabı
public float spawnInterval = 2f; // Dairelerin oluşturulma aralığı (saniye)
public float moveSpeed = 3f; // Dairelerin hareket hızı
public float maxX = 11f; // Dairelerin sağa kadar gidebileceği maksimum X pozisyonu
public float minX = -11f; // Dairelerin sola kadar gidebileceği maksimum X pozisyonu
public float minY = -5f; // Dairelerin sahneden çıkması gereken minimum Y pozisyonu
public float deviation = 6f; // Rastgele sapma miktarı

private float spawnTimer = 0f; // Oluşturma süreleyici
private List<GameObject> circles = new List<GameObject>(); // Oluşturulan dairelerin listesi

    public MiddleBullet tria;
    
void Update()
{
    // Süreleyiciyi güncelle
    spawnTimer += Time.deltaTime;

    // Belirli aralıklarla daire oluştur
    if (spawnTimer >= spawnInterval)
    {
        SpawnCircle();
        spawnTimer = 0f; // Süreleyiciyi sıfırla
    }

    // Daireleri hareket ettir
foreach (GameObject circle in circles.ToList())
{
    MoveCircle(circle);
            

    // Daire sahneden çıktıysa, listeden kaldır
    if (circle.transform.position.y <= minY)
    {
        circles.Remove(circle);
        Destroy(circle);
    }
}
}

void SpawnCircle()
{
    float randomX = Random.Range(minX, maxX); // random X poz
    float startY = 4f; // baslangic daire konumu
    Vector3 spawnPosition = new Vector3(randomX, startY, transform.position.z);
    GameObject circle = Instantiate(circlePrefab,spawnPosition, Quaternion.identity);
    float circleSize = 3f; // Dairenin boyutu
    circle.transform.localScale = new Vector3(circleSize, circleSize, 1f);
    circles.Add(circle);
}

void MoveCircle(GameObject circle)
{
    // Dairenin hareket yönünü belirle
    float xDirection = Random.Range(0, 2) == 0 ? -1f : 1f; // Sağa veya sola hareket için rastgele bir yön belirle

    // Rastgele bir sapma ekle
    float xDeviation = Random.Range(-deviation, deviation);

    // Hareket yönüne sapmayı ekle
    float xMovement = moveSpeed * Time.deltaTime * (xDirection + xDeviation);

    // Yeni pozisyonu hesapla
    Vector3 newPosition = circle.transform.position + new Vector3(xMovement, -moveSpeed * Time.deltaTime, 0f);

    // Pozisyonu sınırla
    newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

    // Yeni pozisyonu uygula
    circle.transform.position = newPosition;
}
  
}

