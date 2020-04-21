using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMain : MonoBehaviour
{

    // AI

    public GameObject AI;

    //used to track when they start the game and end the game.
    public float startTime;
    public float endTime;
    public bool gameRun = false;

    // used to track when they are ready to load into the game.
    public bool player1Ready = false;
    public bool player2Ready = false;
    public float LeverTime;

    //this is used for when both levers are pulled at the same time.
    public bool Lever1Ready = false;
    public bool Lever2Ready = false;
    public bool puzzle3done = false;


    //this is used for when both pressureplates are used at the same time.
    public bool Plate1Ready = false;
    public bool Plate2Ready = false;
    public bool puzzle4done = false;

    /*
    //this is used for puzzle 5 
    public bool Rune1 = false;
    public bool Rune2 = false;
    public bool Rune3 = false;
    public bool Rune4 = false;
    public bool Rune5 = false;
    public bool Rune6 = false; 
    public bool puzzle5Part1done = false;
    public bool puzzle5Part2done = false;
    */


    //used for testing the timer remove when done testing boards and all
    private void Update()
    {
        if (Input.GetKeyDown("s"))
        {
            onGameStart();
        }
        if (Input.GetKeyDown("e"))
        {
            onGameEnd();
        }
        if (player1Ready == true && player2Ready == true)
        {
            onGameStart();
        }
        if (Lever1Ready == true && Lever2Ready == true)
        {
            puzzle3done = true;
            // insert the gameobject here and disable it from this point on/make it slide into a wall.

        }
        if (Plate1Ready == true && Plate2Ready == true)
        {
            puzzle4done = true;
            // insert the gameobject here and disable it from this point on/make it slide into a wall.

        }
        if (gameRun == true)
        {
            GameObject.Find("bed1").GetComponent<Bed1>().Sleeptimemove();
            GameObject.Find("bed2").GetComponent<Bed2>().Sleeptimemove();
        }
    }

    // will launch the game and will 
    void onGameStart()
    {
        startTime = Time.time;
        gameRun = true;
    }

    // will end the game and track end time 
    void onGameEnd()
    {
        endTime = Time.time - startTime;
        gameRun = false;
    }

    public void Leverone()
    {
        Lever1Ready = true;
    }
    public void LeverTwo()
    {
        Lever2Ready = true;
    }
    IEnumerator spawnAI()
    {
        yield return new WaitForSeconds(30);

        spawnAIModel();
    }
    public void spawnAIModel()
        {
         AI = GameObject.Find("AI");
        }

}
