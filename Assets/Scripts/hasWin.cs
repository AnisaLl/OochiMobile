using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnitySampleAssets.Characters.ThirdPerson;

public class hasWin : MonoBehaviour {

    public Canvas winCanvas;
    public Button win_mainmenu;
    public GameObject pausedCanvas;
    Animator anim;
    GameObject Animacamera;
    private ThirdPersonUserControl ThirdPersonUserControl_blue;
    private ThirdPersonUserControl ThirdPersonUserControl_red;
    private ThirdPersonUserControl ThirdPersonUserControl_green;

    // Use this for initialization
    void Start () {
        winCanvas.enabled = false;
        win_mainmenu.enabled = false;
        Animacamera = GameObject.Find("AnimCamera_over");
        Debug.Log(Animacamera);
        anim = Animacamera.GetComponent<Animator>();
        ThirdPersonUserControl_blue = GameObject.FindGameObjectWithTag("blue").GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>();
        ThirdPersonUserControl_red = GameObject.FindGameObjectWithTag("red").GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>();
        ThirdPersonUserControl_green = GameObject.FindGameObjectWithTag("green").GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>();
        Animacamera.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        if (ThirdPersonUserControl_blue.hasWon == true || ThirdPersonUserControl_red.hasWon == true|| ThirdPersonUserControl_green.hasWon == true)
        {
            pausedCanvas.SetActive(false);
            Debug.Log("hasWon_anime");
            Animacamera.SetActive(true);
            //anim.SetTrigger("gamewin");
            Invoke("showwinCanvas", 4.5f);
        }

    }

    void showwinCanvas()
    {
        winCanvas.enabled = true;
        win_mainmenu.enabled = true;
    }
}
