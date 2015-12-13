using UnityEngine;
using System.Collections;

public class CollisionController2 : MonoBehaviour
{
    public string colliderName;
    public string playerName;
    public triggerController particle_red;
    private GameObject blockCollider;

	private GameObject flowerOpen;

    // Use this for initialization

    void Awake()
    {
        blockCollider = GameObject.FindGameObjectWithTag(colliderName);
        GameObject.FindGameObjectWithTag(colliderName).SetActive(false);

		flowerOpen = GameObject.FindGameObjectWithTag("flowerOpen2");
		flowerOpen.SetActive (false);
    }

    void Start()
    {
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
        
        if (collider.tag == playerName)
        {
            if (blockCollider != null)
            {
                Debug.Log("Entered here");
                blockCollider.SetActive(true);
				gameObject.SetActive(false);
                particle_red.Display();
				flowerOpen.SetActive(true);
            }
        }
    }

}
