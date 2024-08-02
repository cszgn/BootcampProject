using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCPoint : MonoBehaviour
{
    public Transform[] points; // Noktalar? saklamak için bir dizi
    private int currentPointIndex = 0; // ?u anda gidilen noktan?n indeksi

    public float speed = 2f; // NPC'nin h?z?

    void Start()
    {
        // NPC'yi ba?lang?ç noktas?na yerle?tir
        if (points.Length > 0)
        {
            transform.position = points[0].position;
        }
    }

    void Update()
    {
        if (points.Length == 0) return;

        // Hedef noktaya do?ru hareket et
        Transform targetPoint = points[currentPointIndex];
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, speed * Time.deltaTime);

        // Hedef noktaya ula?t???nda bir sonraki noktaya geç
        if (Vector3.Distance(transform.position, targetPoint.position) < 0.1f)
        {
            currentPointIndex = (currentPointIndex + 1) % points.Length;
        }
    }
}
