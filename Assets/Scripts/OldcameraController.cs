using UnityEngine;
using System.Collections;

public class cameraController : MonoBehaviour {

    public float rotateTime = 1.0f;
    // camera speed
    public float cameraSpeed = 0.8f;

    private bool _isTweening = false;
    private bool _isRotating = false;
    //private DisablePlayer _disablePlayer;
    private GameObject crystal;
    private Vector3 tCamerPos;
    // trigger altitude
    public float tTriggerAltitude = 30.0f;

    //game over controll
    private GameOver Isgameover;

    private GameObject player1;
    private GameObject player2;
    private GameObject player3;
    private float worldCenterY;

    private GameObject lastPlaying;
   

    // Use this for initialization
    void Start()
    {
        crystal = GameObject.FindGameObjectWithTag("crystal");
        gameObject.transform.position = new Vector3(crystal.transform.position.x, -10, crystal.transform.position.z);
        gameObject.transform.rotation = Quaternion.identity;
        player1 = GameObject.FindGameObjectWithTag("blue");
        player2 = GameObject.FindGameObjectWithTag("red");
        player3 = GameObject.FindGameObjectWithTag("green");
        player1.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = true;
        player2.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = false;
        player3.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = false;
        player1.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = true;
        player2.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;
        player3.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;
        lastPlaying = player1;
        worldCenterY = this.GetComponent<Transform>().eulerAngles.y;
        Isgameover = GameObject.FindGameObjectWithTag("plane").GetComponent<GameOver>();
    }

    // Update is called once per frame
    void Update()
    {
        // camera's local position
        tCamerPos = gameObject.transform.localPosition;

        if (tCamerPos.y < tTriggerAltitude && _isRotating == false && !Isgameover.IsGameOver()) {
            gameObject.transform.Translate(0, Time.deltaTime * cameraSpeed, 0);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            lastPlaying.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;
            _isRotating = true;
            rotateTween(120);
            StartCoroutine(MyCoroutine());
            
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            lastPlaying.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;
            _isRotating = true;
            rotateTween(-120);
            StartCoroutine(MyCoroutine());
        }
    }

    private void rotateTween(float amount)
    {
        if (_isTweening == false)
        {
            _isTweening = true;
            //_disablePlayer.disable();
            Vector3 rot = new Vector3(0, amount, 0);
            iTween.RotateAdd(gameObject, iTween.Hash(iT.RotateAdd.time, rotateTime, iT.RotateAdd.amount, rot, iT.RotateAdd.easetype, iTween.EaseType.easeInOutSine, iT.RotateAdd.oncomplete, "onColorTweenComplete"));
        }
    }

    private void onColorTweenComplete()
    {
        _isTweening = false;
        _isRotating = false;
        //_disablePlayer.enable();
    }

    IEnumerator MyCoroutine()
    {
        //This is a coroutine
        yield return new WaitForSeconds(1);
        jump();
        yield return new WaitForSeconds(1);
    }

    void jump()
    {
         worldCenterY = this.GetComponent<Transform>().eulerAngles.y;
        Debug.Log(worldCenterY);
        if (worldCenterY > -20.0f && worldCenterY < 20.0f)
        {
            player1.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = true;
            player2.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = false;
            player3.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = false;
            player1.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = true;
            player2.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;
            player3.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;
            lastPlaying = player1;
        }
        if (worldCenterY > 340.0f && worldCenterY < 380.0f)
        {
            player1.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = true;
            player2.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = false;
            player3.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = false;
            player1.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = true;
            player2.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;
            player3.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;
            lastPlaying = player1;
        }
        else if (worldCenterY > 100.0f && worldCenterY < 140.0f)
        {
            player1.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = false;
            player2.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = false;
            player3.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = true;
            player1.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;
            player2.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;
            player3.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = true;
            lastPlaying = player3;
        }
        else if (worldCenterY > 220.0f && worldCenterY < 260.0f)
        {
            player1.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = false;
            player2.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = true;
            player3.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = false;
            player1.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;
            player2.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = true;
            player3.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;
            lastPlaying = player2;
        }
    }
}
