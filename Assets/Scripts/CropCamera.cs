using UnityEngine;

public class CropCamera : MonoBehaviour
{
    public Camera camera;
    public float cropAmount = 0.2f; // 0.2 = %20 daraltma, 0.5 = %50 daraltma

    void Start()
    {
        // Viewport Rect ile kameran�n yatay geni�li�ini daraltma
        Rect rect = camera.rect;
        rect.width = 1.0f - cropAmount; // Enlemi daraltma
        rect.x = cropAmount / 2.0f; // Ortada tutmak i�in soldan ve sa�dan e�it kesme
        camera.rect = rect;
    }
}