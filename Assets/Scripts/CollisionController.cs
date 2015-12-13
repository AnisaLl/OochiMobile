using UnityEngine;
using System.Collections;

public class CollisionController : MonoBehaviour
{
    public string colliderName;
    public string playerName;
    public triggerController particle_blue;
    private bool triggered = false;

	private GameObject flowerOpen;

    // Use this for initialization
    void Start()
    {
		flowerOpen = GameObject.FindGameObjectWithTag ("flowerOpen");
		flowerOpen.SetActive (false);
     
    }

    // Update is called once per frame
    void Update()
    {
    }


    //REMEMBER
    //Both objects have to have a collider
    //One of them has to be rigidbody. in this case I have made rigidbody the box since the player cannot be both rigidbody and character controller
    //The object with which the object is colliding has to have "Is Trigger" checked. In this case it doesn't act like a collider. Jsyk
    void OnTriggerEnter(Collider collider)
    {
        //Debug.Log(collider.tag);
        if (collider.tag == playerName)
        {
            //Debug.Log("Entered here");
            if (GameObject.FindGameObjectWithTag(colliderName) != null && !triggered)
            {
                StartCoroutine(MyCoroutine());
                particle_blue.Display();
                GameObject.FindGameObjectWithTag(colliderName).GetComponent<ObjectDisappearance>().enabled = true;
				GameObject.FindGameObjectWithTag(colliderName).SetActive(false);
                triggered = true;
				flowerOpen.SetActive(true);
            }
        }
    }


    //I delay the destruction of the object by 1 second so that it can firstly fade out and then it will be destroyed
    IEnumerator MyCoroutine()
    {
        //This is a coroutine
        yield return new WaitForSeconds(1);
        Destroy(GameObject.FindGameObjectWithTag(colliderName));
        yield return new WaitForSeconds(1);
    }
}
