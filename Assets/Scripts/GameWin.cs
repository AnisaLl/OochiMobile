using UnityEngine;
using System.Collections;

public class GameWin : MonoBehaviour {

	private bool _redCollider;
	private bool _blueCollider;
	private bool _greenCollider;

	// Use this for initialization
	void Start () {
		_redCollider = false;
		_blueCollider = false;
		_greenCollider = false;
	}
	
	// Update is called once per frame
	void Update () {
	}

	public bool getRedCollider ()
	{
		return _redCollider;
	}
	public void setRedCollider(bool value)
	{
		_redCollider = value;
	}

	public bool getBlueCollider ()
	{
		return _blueCollider;
	}
	public void setBlueCollider(bool value)
	{
		_blueCollider = value;
	}

	public bool getGreenCollider ()
	{
		return _greenCollider;
	}
	public void setGreenCollider(bool value)
	{
		_greenCollider = value;
	}
	
}
