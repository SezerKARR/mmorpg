using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ImageUnderCursor : MonoBehaviour
{
    public static ImageUnderCursor Instance;
    RectTransform rectTransform;
    private void Awake()
    {
        Instance = this;
        rectTransform = GetComponent<RectTransform>();
        rectTransform.position = Input.mousePosition;
        if(GetComponent<Image>().sprite==null )gameObject.SetActive(false);
    }
    void Update()
    {
        

        rectTransform.position = Input.mousePosition;

    }
}