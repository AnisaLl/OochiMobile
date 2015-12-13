using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnitySampleAssets.Characters.ThirdPerson;

public class GameOver : MonoBehaviour {

    //bool seen = false;
    bool gameOver = false;
    
    public Canvas CgameOver;
    public GameObject pausedCanvas;
    public Button tryAgain;
    public Button mainMenu;
    public Image dead_blue;
    public Image dead_red;
    public Image dead_green;
    AudioSource gameSceneAudio;
    public AudioClip endAudio;




    // Use this for initialization
    void Start () {
        CgameOver.enabled = false;
        tryAgain.interactable = false;
        mainMenu.interactable = false;
        dead_blue.enabled = false;
        dead_red.enabled = false;
        dead_green.enabled = false;
        gameSceneAudio = GameObject.Find("Main Camera").GetComponent<AudioSource>();
        

    }
	
	// Update is called once per frame
	void Update () {

       
    }

    void OnTriggerEnter(Collider collider)
    {
        if (gameOver == false)
        {
            if (collider.tag == "blue" || collider.tag == "red" || collider.tag == "green")
            {
                //Debug.Log("Game over");
                if(collider.tag == "blue") { dead_blue.enabled = true; Debug.Log("dead_blue Game over"); }
                if (collider.tag == "red") { dead_red.enabled = true; Debug.Log("dead_red Game over"); }
                if (collider.tag == "green") { dead_green.enabled = true; Debug.Log("dead_green Game over"); }
                gameOver = true;
                FGameOver();
            }
        }
    }

    //public void FtryAgain() {
    //    Application.LoadLevel(Application.loadedLevel);
    //}

    public bool IsGameOver()
    {
        return gameOver;
    }

    void FGameOver()
    {
        pausedCanvas.SetActive(false);
       
        CgameOver.enabled = true;
        tryAgain.interactable = true;
        mainMenu.interactable = true;
        gameSceneAudio.clip = endAudio;
        gameSceneAudio.Play();
    }

   
}
