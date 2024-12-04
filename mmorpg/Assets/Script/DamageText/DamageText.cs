using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    public Vector2 initialVelocity; // Baþlangýç hýzý
    public float gravity = 9.8f;    // Yerçekimi
    public float lifetime = 2f;     // Objenin yok olma süresi

    private Vector2 startPosition;
    private float timeElapsed;
    [SerializeField]
    private TextMeshPro damageText;
    // Start is called before the first frame update
    public virtual void Initialize(string damage)
    {
        damageText.text = damage;
        startPosition = transform.position;
    }
    void Update()
    {
        timeElapsed += Time.deltaTime;

        // Parabolik hareket formülü
        float newX = startPosition.x + initialVelocity.x * timeElapsed;
        float newY = startPosition.y + initialVelocity.y * timeElapsed - 0.5f *  Mathf.Pow(timeElapsed, 2);

        transform.position = new Vector3(newX, newY, transform.position.z);

        // Belirtilen süre sonunda objeyi yok et
        if (timeElapsed >= lifetime/2)
        {
            Destroy(gameObject);
        }
    }
}
