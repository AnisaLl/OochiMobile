using UnityEngine;
using System.Collections;
using UnitySampleAssets.Characters.ThirdPerson;

public class AnimCameraController : MonoBehaviour {

    Animator anim;                          // Reference to the animator component.
    //game over controll
    //private bool hasWon;
    GameObject Animacamera;
    GameObject plane;
    public Canvas pausedCanvas;
    private cameraController_camera cameraController_camera;
	public bool isAnima = true;


    void Awake()
    {
        Animacamera = GameObject.Find("AnimCamera");
        anim = Animacamera.GetComponent<Animator>();
        pausedCanvas.enabled = false;
    }

    // Use this for initialization
    void Start()
    {
        plane = GameObject.FindGameObjectWithTag("plane");
        cameraController_camera = GameObject.Find("worldCenter").GetComponent<cameraController_camera>();

    }

    // Update is called once per frame
    void Update() {

        //
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime > 1|| Animacamera.active ==false)
        {
            disableCamera();
            pausedCanvas.enabled = true;
            plane.GetComponent<planeController>().enabled = true;
			isAnima = false;
            
        }

    }

    public void disableCamera()
    {
        if(Animacamera.active == true)
        {
            Animacamera.SetActive(false);
        }
        
    }

    //void OnMouseDown()
    //{
    //    Animacamera.SetActive(false);
    //}
}
