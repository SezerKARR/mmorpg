using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using System.Linq;
using UnityEngine.Serialization;
using Zenject;

namespace Script.Enemy
{
    [RequireComponent(typeof(LineRenderer))]
    public class CreaturesSpawnArea : MonoBehaviour
    {
        [SerializeField] private LineRenderer lineRenderer;
        [SerializeField] private int creatureCount = -1;
        public GameObject creaturesGroupPrefab;
        [SerializeField] private List<CreaturesGroup> creaturesGroups=new List<CreaturesGroup>(); 
        public List<CreaturesGroup>  Initialize()
        {
            if (lineRenderer == null)
            {
                lineRenderer = GetComponent<LineRenderer>();
            }
            
            List<Vector2> positions = GetLineRendererPositions(lineRenderer);
            for (int i = 0; i < creatureCount; i++)
            {
                Vector2 point = GetRandomPositionInPolygon(positions);
                GameObject creaturesGroup= Instantiate(creaturesGroupPrefab,point , Quaternion.identity);
                creaturesGroup.transform.parent = transform;
                creaturesGroups.Add(creaturesGroup.GetComponent<CreaturesGroup>());
            }
            return creaturesGroups;
            //Vector2 randomPosition = GetRandomPositionInPolygon(positions);
            //Debug.Log("Rastgele Konum: " + randomPosition);
        }

        List<Vector2> GetLineRendererPositions(LineRenderer lineRenderer)
        {
            List<Vector2> positions = new List<Vector2>();

            // LineRenderer'daki pozisyon sayısını al
            int positionCount = lineRenderer.positionCount;

            // Tüm pozisyonları al ve listeye ekle
            for (int i = 0; i < positionCount; i++)
            {
                positions.Add(new Vector2(lineRenderer.GetPosition(i).x, lineRenderer.GetPosition(i).y));
            }

            return positions;
        }

        // Polygon içinde rastgele bir konum almak
        Vector2 GetRandomPositionInPolygon(List<Vector2> polygon)
        {
            // Polygonu oluştur
            Vector2 randomPosition = Vector2.zero;
            bool insidePolygon = false;

            // Polygonun iç kısmında rastgele bir konum seç
            while (!insidePolygon)
            {
                // Polygon sınırları içinde rastgele bir konum seç
                randomPosition = GetRandomPointInBounds(polygon);

                // Bu konum polygonun içinde mi diye kontrol et
                insidePolygon = IsPointInPolygon(randomPosition, polygon);
            }

            return randomPosition;
        }

        // Polygon içinde rastgele bir nokta seçmek için bu fonksiyonu kullanıyoruz
        Vector2 GetRandomPointInBounds(List<Vector2> polygon)
        {
            // Bounding box (kapsama kutusu) hesapla
            float minX = polygon.Min(v => v.x);
            float maxX = polygon.Max(v => v.x);
            float minY = polygon.Min(v => v.y);
            float maxY = polygon.Max(v => v.y);

            // Kapsama kutusu içinde rastgele bir nokta seç
            float randomX = Random.Range(minX, maxX);
            float randomY = Random.Range(minY, maxY);

            return new Vector2(randomX, randomY);
        }

        // Bir noktanın polygonun içinde olup olmadığını kontrol etme
        bool IsPointInPolygon(Vector2 point, List<Vector2> polygon)
        {
            bool inside = false;

            // Polygonun kenarları arasında çizilen bir çizgi ile kontrol yapılır (ray-casting algoritması)
            for (int i = 0, j = polygon.Count - 1; i < polygon.Count; j = i++)
            {
                Vector2 v1 = polygon[i];
                Vector2 v2 = polygon[j];

                if (((v1.y > point.y) != (v2.y > point.y)) &&
                    (point.x < (v2.x - v1.x) * (point.y - v1.y) / (v2.y - v1.y) + v1.x))
                {
                    inside = !inside;
                }
            }

            return inside;
        }
    }
}