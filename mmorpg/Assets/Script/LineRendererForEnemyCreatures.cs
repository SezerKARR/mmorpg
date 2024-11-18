using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LineRendererForEnemyCreatures : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private GameObject outlineObject; // �izgi nesnesi i�in bir referans
    public bool isSelected = false;

    void Start()
    {

        // �izgi nesnesini olu�tur
        outlineObject = new GameObject("Outline");
        outlineObject.transform.parent = transform; // Ana nesnenin alt� olacak

        lineRenderer = outlineObject.AddComponent<LineRenderer>();
        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;
        lineRenderer.startWidth = 0.05f;
        lineRenderer.endWidth = 0.05f;
        lineRenderer.loop = true;

        // Ba�lang��ta g�r�nm�yor
        lineRenderer.positionCount = 0;
        outlineObject.SetActive(false); 
    }

    

    public void DrawBoundary(PolygonCollider2D polygon)
    {
        Vector2[] points = polygon.points;
        lineRenderer.positionCount = points.Length + 1;

        for (int i = 0; i < points.Length; i++)
        {
            Vector3 worldPos = transform.TransformPoint(points[i]);
            worldPos.z = -0.1f; // Z pozisyonunu 0 yap
            lineRenderer.SetPosition(i, worldPos);
        }

        lineRenderer.SetPosition(points.Length, lineRenderer.GetPosition(0)); // �izgiyi kapat
    }
}
