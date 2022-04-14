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
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private GameObject[] clothes;
    [SerializeField] private Animator playerAnimator;
    [SerializeField] private Animator womanAnimator;
    void Update()
    {
        player.Translate(Vector3.forward * moveSpeed * Time.deltaTime); //move the player forward by the chosen speed

        if(GameManager.instance.finishReached) moveSpeed = Mathf.MoveTowards(moveSpeed, walkSpeed, Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("FinishLine")) //when the player reaches the finish line
        {
            GameManager.instance.finishReached = true; //change the game state to run-over
            playerAnimator.SetBool("gameEnded", true); //activate the animation transition
        }
        else if(other.gameObject.CompareTag("Woman")) //when the player reaches the woman
        {
            moveSpeed = 0; //stop the player
            walkSpeed = 0; //set the walk speed to 0 as well to prevent the player from still moving coz of 25. line above

            if(GameManager.instance.score >= 20)
            {
                playerAnimator.SetBool("playerWon", true); //trigger the vicrory animation for player
                womanAnimator.SetBool("playerWon", true); //trigger the vicrory animation for woman
                GameManager.instance.playerWon = true; //change the game state to victory
            }
            else if(GameManager.instance.score < 20)
            {
                playerAnimator.SetBool("playerLost", true); //trigger the loss animation for player
                womanAnimator.SetBool("playerLost", true); //trigger the loss animation for woman
                GameManager.instance.playerLost = true; //change the game state to defeat
            }
        }
    }
}
