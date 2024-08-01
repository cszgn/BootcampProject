using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC002Dest : MonoBehaviour
{
    public int pivotPoint;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            if (pivotPoint == 5)
            {

                pivotPoint = 0;
            }

            if (pivotPoint == 4)
            {
                this.gameObject.transform.position = new Vector3(12, 1, 20);
                pivotPoint = 5;
            }

            if (pivotPoint == 3)
            {
                this.gameObject.transform.position = new Vector3(2, 1, 15);
                pivotPoint = 4;
            }

            if (pivotPoint == 2)
            {
                this.gameObject.transform.position = new Vector3(5, 1, 7);
                pivotPoint = 3;
            }

            if (pivotPoint == 1)
            {
                this.gameObject.transform.position = new Vector3(10, 1, 15);
                pivotPoint = 2;
            }

            if (pivotPoint == 0)
            {
                this.gameObject.transform.position = new Vector3(7, 1, 13);
                pivotPoint = 1;
            }
        }
    }
}