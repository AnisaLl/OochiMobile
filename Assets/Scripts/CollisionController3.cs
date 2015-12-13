using UnityEngine;
using System.Collections;

public class CollisionController3 : MonoBehaviour {

	public string colliderName;
	public string playerName;
	public triggerController particle_green;
	private GameObject blockCollider;
	//public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void Awake()
	{
		blockCollider = GameObject.FindGameObjectWithTag(colliderName);
		//GameObject.FindGameObjectWithTag(colliderName).SetActive(false);
	}

	void OnTriggerStay(Collider collider)
	{
		
		if (collider.tag == playerName)
		{
            //Debug.Log(collider.tag);
            //Resources.FindObjectsOfTypeAll<Transform?>
            //Debug.Log(GetComponent<Transform>().Find(colliderName).tag);
            particle_green.Display();
            if (blockCollider != null)
			{
				Effect();
				gameObject.SetActive(false);
			}
		}
	}

	void Effect()
	{
		blockCollider.transform.localPosition = new Vector3 (0.07f, 1.53f, 0.72f);
	}

	IEnumerator MyCoroutine()
	{
		//This is a coroutine
		yield return new WaitForSeconds(2.0f);
	//	Effect ();
		yield return new WaitForSeconds(2.0f);
	}

	
}
