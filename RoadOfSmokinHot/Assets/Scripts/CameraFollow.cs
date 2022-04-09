using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Vector3 offset;
    [SerializeField] private Vector3 rotation;

    void Update()
    {
        transform.position = player.position + offset; //make the camera's position follow along with the player
        transform.rotation = Quaternion.Euler(rotation); //rotate the camera to the chosen rotation
    }
}
