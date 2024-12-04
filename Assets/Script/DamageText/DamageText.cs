using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageText : MonoBehaviour
{
    public Vector2 initialVelocity; // Ba�lang�� h�z�
    public float gravity = 9.8f;    // Yer�ekimi
    public float lifetime = 2f;     // Objenin yok olma s�resi

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

        // Parabolik hareket form�l�
        float newX = startPosition.x + initialVelocity.x * timeElapsed;
        float newY = startPosition.y + initialVelocity.y * timeElapsed - 0.5f *  Mathf.Pow(timeElapsed, 2);

        transform.position = new Vector3(newX, newY, transform.position.z);

        // Belirtilen s�re sonunda objeyi yok et
        if (timeElapsed >= lifetime/2)
        {
            Destroy(gameObject);
        }
    }
}
