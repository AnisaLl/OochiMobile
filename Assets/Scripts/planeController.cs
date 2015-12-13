using UnityEngine;
using System.Collections;
using UnitySampleAssets.Characters.ThirdPerson;

public class planeController : MonoBehaviour {
    // camera speed
    public float cameraSpeed = 0.8f;

    private Vector3 tCamerPos;
    // trigger altitude
    public float tTriggerAltitude = 30.0f;

    public GameObject pausedCanvas;

    //game over controll
    //private GameOver Isgameover;
    private bool win;

    private ThirdPersonUserControl ThirdPersonUserControl_blue;
    private ThirdPersonUserControl ThirdPersonUserControl_red;
    private ThirdPersonUserControl ThirdPersonUserControl_green;

    private cameraController_camera cameraController_camera;

    // Use this for initialization
    void Start () {
        //Isgameover = GameObject.FindGameObjectWithTag("plane").GetComponent<GameOver>();
        win = false;
        ThirdPersonUserControl_blue = GameObject.FindGameObjectWithTag("blue").GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>();
        ThirdPersonUserControl_red = GameObject.FindGameObjectWithTag("red").GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>();
        ThirdPersonUserControl_green = GameObject.FindGameObjectWithTag("green").GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>();
        cameraController_camera = GameObject.Find("worldCenter").GetComponent<cameraController_camera>();
    }
	
	// Update is called once per frame
	void Update () {

        // camera's local position
        tCamerPos = gameObject.transform.localPosition;

        if(ThirdPersonUserControl_blue.hasWon == true || ThirdPersonUserControl_red.hasWon == true || ThirdPersonUserControl_green.hasWon == true)
        {
            win = true;
        }

        if (tCamerPos.y < tTriggerAltitude && !win && pausedCanvas.active == false && !cameraController_camera._isRotating)
        {
            gameObject.transform.Translate(0, Time.deltaTime * cameraSpeed, 0);
        }

    }
}
