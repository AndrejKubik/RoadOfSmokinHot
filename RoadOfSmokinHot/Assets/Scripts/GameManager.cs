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

    private void Start()
    {
        score = 0;
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
    }
}
