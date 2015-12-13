using UnityEngine;
using System.Collections;


public class UIMainSceneController : MonoBehaviour {

   

    
	// Use this for initialization
	void Start () {

        
	}
	
	// Update is called once per frame
	void Update () {

       
	
	}

    public void tryAgain()
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void mainMenu()
    {
        Application.LoadLevel(0);
    }

    public void showCanvasPanel(GameObject CanvasPanel)
    {
        CanvasPanel.SetActive(!CanvasPanel.activeSelf);
    }

  

}
