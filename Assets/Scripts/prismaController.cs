using UnityEngine;
using System.Collections;

public class prismaController : MonoBehaviour {

    private GameObject crystal;

	// Use this for initialization
	void Start () {
        crystal = GameObject.FindGameObjectWithTag("crystal");
	}
	
	// Update is called once per frame
	void Update () {
        lookAtCamera();
    }

    void lookAtCamera()
    {

    }
}
