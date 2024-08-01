using UnityEngine;

public class CropCamera : MonoBehaviour
{
    public Camera camera;
    public float cropAmount = 0.2f; // 0.2 = %20 daraltma, 0.5 = %50 daraltma

    void Start()
    {
        // Viewport Rect ile kameranýn yatay geniþliðini daraltma
        Rect rect = camera.rect;
        rect.width = 1.0f - cropAmount; // Enlemi daraltma
        rect.x = cropAmount / 2.0f; // Ortada tutmak için soldan ve saðdan eþit kesme
        camera.rect = rect;
    }
}