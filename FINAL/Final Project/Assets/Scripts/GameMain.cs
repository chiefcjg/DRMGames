using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMain : MonoBehaviour
{
    public Text TimeText;
    public string EndTimeText;

    public Text CaughtText;
    public string EndCaughtText;

    public Image img;

    public int TimesCaught;

    // AI
    public GameObject AI;
    public GameObject AISpawnLocation;

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

    private void Start()
    {
        img = GameObject.Find("FadeinScreenPanel").GetComponent<Image>();
        TimeText = GameObject.Find("Time").GetComponent<Text>();
        CaughtText = GameObject.Find("Caught").GetComponent<Text>();
    }


    //used for testing the timer remove when done testing boards and all
    private void Update()
    {
        if (player1Ready == true && player2Ready == true)
        {
            onGameStart();
        }

        if (Lever1Ready == true && Lever2Ready == true)
        {
            puzzle4done = true;
        }
        if (puzzle4done == true)
        {
            puzzle4Walls();
        }
        if (Plate1Ready == true && Plate2Ready == true)
        {
            puzzle3done = true;
        }
        if (puzzle3done == true)
        {
            puzzle3Walls();
        }

        if (gameRun == true)
        {
            GameObject.Find("bed1").GetComponent<Bed1>().Sleeptimemove();
            GameObject.Find("bed2").GetComponent<Bed2>().Sleeptimemove();
        }
    }

    private void puzzle4Walls()
    {
        GameObject wallsPlayer1;
        GameObject wallsPlayer2;

        Vector3 endlocationWall1;
        Vector3 endlocationWall2;

        wallsPlayer1 = GameObject.Find("WallPuzzle4Player1");
        wallsPlayer2 = GameObject.Find("WallsPuzzle4Player2");

        endlocationWall1 = new Vector3(wallsPlayer1.transform.position.x, -5, wallsPlayer1.gameObject.transform.position.z);
        endlocationWall2 = new Vector3(wallsPlayer2.transform.position.x, -5, wallsPlayer1.gameObject.transform.position.z);

        wallsPlayer1.transform.position = endlocationWall1;
        wallsPlayer2.transform.position = endlocationWall2;
    }

    private void puzzle3Walls()
    {
        GameObject wallsPlayer1;
        GameObject wallsPlayer2;

        Vector3 endlocationWall1;
        Vector3 endlocationWall2;

        wallsPlayer1 = GameObject.Find("WallPuzzle3Player1");
        wallsPlayer2 = GameObject.Find("WallsPuzzle3Player2");

        endlocationWall1 = new Vector3(wallsPlayer1.transform.position.x, -5, wallsPlayer1.gameObject.transform.position.z);
        endlocationWall2 = new Vector3(wallsPlayer2.transform.position.x, -5, wallsPlayer1.gameObject.transform.position.z);

        wallsPlayer1.transform.position = endlocationWall1;
        wallsPlayer2.transform.position = endlocationWall2;
    }

    // will launch the game and will trigger audios and spawn in AI
    void onGameStart()
    {
        GetComponent<AudioSource>().Play(0);

        AI = GameObject.Find("AI");
        StartCoroutine(FadeImage(false));
        AI.gameObject.transform.position = new Vector3(0.35f, 1f, -4.5f);
        AI.active = false;
        startTime = Time.time;
        StartCoroutine(DialogWait());
        StartCoroutine(SpawnAI());
    }

    // will end the game and track end time and times caught
    public void onGameEnd()
    {
        endTime = Time.time - startTime;
        gameRun = false;

        EndTimeText += "Your time was: " + endTime + "\n";
        TimeText.text = EndTimeText;

        EndCaughtText += "You were caught: " + TimesCaught + "Times\n";
        CaughtText.text = EndCaughtText;
    }

    public void Leverone()
    {
        Lever1Ready = true;
    }
    public void LeverTwo()
    {
        Lever2Ready = true;
    }

    IEnumerator DialogWait()
    {
        yield return new WaitForSeconds(10);
        gameRun = true;
        StartCoroutine(FadeImage(true));
    }
    IEnumerator SpawnAI()
    {
        //yield on a new YieldInstruction that waits for 30 seconds.
        yield return new WaitForSeconds(45);
        spawnAIModel();
    }

    public void spawnAIModel()
    {
        AI.active = true;
        AI.gameObject.GetComponent<Patrol>().AIGO = true;
    }

    public void killswitch1()
    {
        AI.transform.position = GameObject.Find("AISpawnkillSwitch1").transform.position;
    }
    public void killswitch2()
    {
        AI.transform.position = GameObject.Find("AISpawnkillSwitch2").transform.position;
    }


    //fade in fade out
    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 10; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 10; i += Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(0, 0, 0, i);
                yield return null;
            }
        }
    }

}