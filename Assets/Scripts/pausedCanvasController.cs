using UnityEngine;
using System.Collections;

public class pausedCanvasController : MonoBehaviour {

    public GameObject pausedPanel;
    // Use this for initialization
    void Start () {
        

    }

    // Update is called once per frame
    void Update () {
	
	}

    public void openPausedPanel()
    {
        Debug.Log("PausedPanel"+ !pausedPanel.active);
        pausedPanel.SetActive(true);
    }

    public void closePausedPanel()
    {
        Debug.Log("PausedPanel" + !pausedPanel.active);
        pausedPanel.SetActive(false);
    }
}
