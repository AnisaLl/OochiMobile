using UnityEngine;
using System.Collections;

public class cameraController_camera : MonoBehaviour {

    public float rotateTime = 1.0f;

    private bool _isTweening = false;
    public bool _isRotating = false;
    private bool CharStarted = false;
    //private DisablePlayer _disablePlayer;
    private GameObject crystal;

    //main camera
    private GameObject mainCamera;

    //game over controll
    private GameOver Isgameover;

    private GameObject player1;
    private GameObject player2;
    private GameObject player3;
    private float worldCenterY;

    private GameObject lastPlaying;

    Vector3 targetPos;

	public float comfortZoneVerticalSwipe = 30; // the vertical swipe will have to be inside a 50 pixels horizontal boundary
	public float comfortZoneHorizontalSwipe = 30; // the horizontal swipe will have to be inside a 50 pixels vertical boundary
	public float minSwipeDistance = 14; // the swipe distance will have to be longer than this for it to be considered a swipe
	//the following 4 variables are used in some cases that I don’t want my character to be allowed to move on the board (it’s a board game)
	public float startTime;
	public Vector2 startPos;
	public float maxSwipeTime;
	private bool isSwipe;
	
	// Use this for initialization
    void Start()
    {
        crystal = GameObject.FindGameObjectWithTag("crystal");
        gameObject.transform.position = new Vector3(crystal.transform.position.x, -10, crystal.transform.position.z);
        gameObject.transform.rotation = Quaternion.identity;
        player1 = GameObject.FindGameObjectWithTag("blue");
        player2 = GameObject.FindGameObjectWithTag("red");
        player3 = GameObject.FindGameObjectWithTag("green");

        StartCoroutine(enablePlayersStart());
        StartCoroutine(disablePlayersStart());
       
        lastPlaying = player1;
        worldCenterY = this.GetComponent<Transform>().eulerAngles.y;
        Isgameover = GameObject.FindGameObjectWithTag("plane").GetComponent<GameOver>();
        mainCamera = GameObject.Find("Main Camera");

		isSwipe = false;
		//lastSwipe = cameraController_camera.SwipeDirection.None;
    }

    // Update is called once per frame
    void Update()
    {
        cameraTrack(lastPlaying);


		if (Input.touchCount >0) {
			Touch touch = Input.touches[0];
			
			switch (touch.phase) { //following are 2 cases
				
			case TouchPhase.Began: //here begins the 1st case
				Debug.Log("Entered begin phase");
				startPos = touch.position;
				startTime = Time.time;
				
				break; //here ends the 1st case
				
			case TouchPhase.Ended: //here begins the 2nd case
				Debug.Log("Entered end phase");
				float swipeTime = Time.time - startTime;
				float swipeDist = (touch.position - startPos).magnitude;
				
				Debug.Log("Comfort zone " + (Mathf.Abs(touch.position.x - startPos.x)<comfortZoneVerticalSwipe));
				Debug.Log("Swipe time " + (swipeTime < maxSwipeTime));
				Debug.Log("Swipe dist " + (swipeDist > minSwipeDistance));
				Debug.Log("Touch position " + (Mathf.Sign(touch.position.y - startPos.y)>0));
				
				if ((Mathf.Abs(touch.position.y - startPos.y))<comfortZoneHorizontalSwipe && (swipeTime < maxSwipeTime) && (swipeDist > minSwipeDistance) && Mathf.Sign(touch.position.x - startPos.x)<0)
				{
					Debug.Log("Entered the second if");
					lastPlaying.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;
					lastPlaying.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = false;
					lastPlaying.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
					freezeRotation();
					_isRotating = true;
					rotateTween(-120);
					StartCoroutine(MyCoroutine());
				}

				if ((Mathf.Abs(touch.position.y - startPos.y))<comfortZoneHorizontalSwipe && (swipeTime < maxSwipeTime) && (swipeDist > minSwipeDistance) && Mathf.Sign(touch.position.x - startPos.x)>0)
				{
					Debug.Log("Entered the first if");
					lastPlaying.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;
					lastPlaying.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = false;
					lastPlaying.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
					freezeRotation();
					_isRotating = true;
					rotateTween(120);
					StartCoroutine(MyCoroutine());

				}
				break;
				//here ends the 2nd case
			}
		}
//		if (isSwipe)
//		{
//			lastPlaying.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;
//			lastPlaying.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = false;
//			lastPlaying.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
//			//lastPlaying.GetComponent<Animator>().enabled = false;
//			_isRotating = true;
//			rotateTween(120);
//			StartCoroutine(MyCoroutine());
//			
//		}
//		
//		if (isSwipe)
//		{
//		    lastPlaying.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;
//            lastPlaying.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = false;
//            lastPlaying.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
//            lastPlaying.GetComponent<Animator>().enabled = false;
//            _isRotating = true;
//            rotateTween(-120);
//            StartCoroutine(MyCoroutine());
//        }
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

    IEnumerator enablePlayersStart()
    {
        //This is a coroutine
        yield return new WaitForSeconds(0.10f);
        enablePlayers();
        yield return new WaitForSeconds(0.10f);
    }

    IEnumerator disablePlayersStart()
    {
        //This is a coroutine
        yield return new WaitForSeconds(0.1f);
        disablePlayers();
        yield return new WaitForSeconds(0.1f);
    }

    void jump()
    {
        worldCenterY = this.GetComponent<Transform>().eulerAngles.y;
        Debug.Log(worldCenterY);
        if ((worldCenterY > -20.0f && worldCenterY < 20.0f) || (worldCenterY > 340.0f && worldCenterY < 380.0f))
        {
            player1.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = true;
            player2.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = false;
            player3.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = false;
            player1.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = true;
            player2.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;
            player3.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;

            player1.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionX;
			freezeRotation();
            //player1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
            //player1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;


            //player1.GetComponent<Rigidbody>().constraints &= (~RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ);

            player1.GetComponent<Animator>().enabled = true;
            player2.GetComponent<Animator>().enabled = false;
            player3.GetComponent<Animator>().enabled = false;
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

            player3.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionX;
            //player3.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionY
            player3.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionZ;

            //player3.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
			freezeRotation();
			//player3.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;

            //player3.GetComponent<Rigidbody>().constraints &= (~RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY | ~RigidbodyConstraints.FreezePositionZ);

            player1.GetComponent<Animator>().enabled = false;
            player2.GetComponent<Animator>().enabled = false;
            player3.GetComponent<Animator>().enabled = true;
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

            player2.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionX;
            //player2.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionY
            player2.GetComponent<Rigidbody>().constraints &= ~RigidbodyConstraints.FreezePositionZ;

            //player2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
			freezeRotation();
			//player2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationZ;

            //player2.GetComponent<Rigidbody>().constraints &= (~RigidbodyConstraints.FreezePositionX | ~RigidbodyConstraints.FreezePositionY | ~RigidbodyConstraints.FreezePositionZ);

            player1.GetComponent<Animator>().enabled = false;
            player2.GetComponent<Animator>().enabled = true;
            player3.GetComponent<Animator>().enabled = false;
            lastPlaying = player2;
           
        }
    }

    void enablePlayers()
    {
        player1.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = true;
        player2.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = true;
        player3.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = true;
        player1.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = true;
        player2.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = true;
        player3.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = true;
    }

    void disablePlayers()
    {
        player1.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = true;
        player2.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = false;
        player3.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonCharacter>().enabled = false;
        player1.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = true;
        player2.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;
        player3.GetComponent<UnitySampleAssets.Characters.ThirdPerson.ThirdPersonUserControl>().enabled = false;
    }

	void freezeRotation()
	{
		player1.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
		player2.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
		player3.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
	}

    void cameraTrack(GameObject player)
    {
        //Vector3 playerPos = 
        mainCamera.transform.position = new Vector3(mainCamera.transform.position.x, player.transform.position.y, mainCamera.transform.position.z);
        /*float wantedHeight = player.transform.position.y;
        float currentHeight = mainCamera.transform.position.y;
        currentHeight = Mathf.Lerp(currentHeight, wantedHeight, heightDamping * Time.deltaTime);*/
        
    }
}
