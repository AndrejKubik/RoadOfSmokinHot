using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region Singleton
    public static Player instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    [SerializeField] private Transform player;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private GameObject[] clothes;
    void Update()
    {
        player.Translate(Vector3.forward * moveSpeed * Time.deltaTime); //move the player forward by the chosen speed
    }
}
