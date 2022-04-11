using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupPlaceholder : MonoBehaviour
{
    [SerializeField] private Transform spot;

    private void Update()
    {
        transform.position = spot.position; //move the placeholder to the according spot position
    }
}
