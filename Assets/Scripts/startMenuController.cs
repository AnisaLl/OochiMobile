using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class startMenuController : MonoBehaviour {

    public GameObject loadingimage;
    AudioSource StartSceneAudio;
	// Use this for initialization
	void Start () {

        StartSceneAudio = GameObject.Find("Main Camera").GetComponent<AudioSource>();

    }
	
	// Update is called once per frame
	void Update () {
	
	}

    public void showCanvasPanel(GameObject CanvasPanel)
    {     
        CanvasPanel.SetActive(!CanvasPanel.activeSelf);
        //panel_main.SetActive(!panel_main.activeSelf);

    }

    public void enableScript(GameObject quad)
    {
        quad.GetComponent<ImageSequenceTextureArray>().enabled = true;

    }

    public void LoadScene(int level)
    {
        loadingimage.SetActive(true);
        Application.LoadLevel(level);
    }

    public void playTransitionAudio(AudioClip transition)
    {
        StartSceneAudio.clip = transition;
        StartSceneAudio.Play();
    }
}
