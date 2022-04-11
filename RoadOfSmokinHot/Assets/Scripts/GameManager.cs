using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public int score;

    public int scoreTorso;
    public int scoreLegs;
    public int scoreFeet;

    public TextMeshProUGUI scoreText;

    [SerializeField] private GameObject[] pickups;
    private GameObject randomPickup1;
    private GameObject randomPickup2;
    private GameObject randomPickup3;
    private GameObject randomPickup4;

    [SerializeField] private GameObject placeholder1;
    [SerializeField] private GameObject placeholder2;
    [SerializeField] private GameObject placeholder3;
    [SerializeField] private GameObject placeholder4;

    public bool collectedPickup;
    [SerializeField] private Transform pickupParent;

    private GameObject[] activePickups;

    private void Start()
    {
        score = 0;

        SpawnPickups();
    }

    private void Update()
    {
        if (OutfitManager.instance.currentOutfit[0] != null) scoreTorso = OutfitManager.instance.currentOutfit[0].itemScore; //if there is a torso item worn get it's score value
        else scoreTorso = 0; //otherwise set the score value to 0

        if (OutfitManager.instance.currentOutfit[1] != null) scoreLegs = OutfitManager.instance.currentOutfit[1].itemScore; //if there is a legs item worn get it's score value
        else scoreLegs = 0; //otherwise set the score value to 0

        if (OutfitManager.instance.currentOutfit[2] != null) scoreFeet = OutfitManager.instance.currentOutfit[2].itemScore; //if there is a feet item worn get it's score value
        else scoreFeet = 0; //otherwise set the score value to 0

        score = scoreTorso + scoreLegs + scoreFeet; //calculate total score

        scoreText.text = score.ToString(); //change the text to the score number

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SpawnPickups();
        }

        if(collectedPickup) //when player collects a pickup
        {
            for (int i = 0; i < activePickups.Length; i++)
            {
                Destroy(activePickups[i]); //destroy every pickup in the scene
            }

            pickupParent.position = new Vector3(pickupParent.position.x, pickupParent.position.y, pickupParent.position.z + 5f); //move the pickup parent object away from the player

            SpawnPickups(); //spawn new batch of pickups

            collectedPickup = false; //reset the trigger
        }
    }

    public void SpawnPickups()
    {
        //get random items to spawn 
        randomPickup1 = pickups[Random.Range(0, pickups.Length)];
        randomPickup2 = pickups[Random.Range(0, pickups.Length)];
        randomPickup3 = pickups[Random.Range(0, pickups.Length)];
        randomPickup4 = pickups[Random.Range(0, pickups.Length)];

        //spawn pickups each under the according parent object and it's position
        Instantiate(randomPickup1, placeholder1.transform, false);
        Instantiate(randomPickup2, placeholder2.transform, false);
        Instantiate(randomPickup3, placeholder3.transform, false);
        Instantiate(randomPickup4, placeholder4.transform, false);

        activePickups = GameObject.FindGameObjectsWithTag("Pickups"); //add the spawned pickups to an array
    }
}
