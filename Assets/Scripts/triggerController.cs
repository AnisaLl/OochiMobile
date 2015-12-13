using UnityEngine;
using System.Collections;

public class triggerController : MonoBehaviour {


    //public float range = 3f;
    Ray shootRay;                                   // A ray from the trigger forwards.
    ParticleSystem triggerParticles;                    // Reference to the particle system.
    AudioSource triggerAudio;                           // Reference to the audio source.
    Light triggerLight;                                 // Reference to the light component.
    public float effectsDisplayTime = 2.0f;
    private GameObject trigger;
    public GameObject cameraMini;
    public string triggerName;

    // Use this for initialization
    void Awake()
    {
        // Set up the references.
        triggerParticles = GetComponent<ParticleSystem>();
        triggerAudio = GetComponent<AudioSource>();
        triggerLight = GetComponent<Light>();
    }

    void Start () {
        trigger = GameObject.Find(triggerName);
        gameObject.transform.position = new Vector3(trigger.transform.position.x, trigger.transform.position.y, trigger.transform.position.z);
        //camera = GameObject.FindGameObjectWithTag("camera2");
        cameraMini.SetActive(false); 
    }
	
	// Update is called once per frame
	void Update () {

        //timer += Time.deltaTime;

        //if (Input.GetButton("Jump"))
        //{
        //    //trigger.SetActive(false);
        //    Display();
        //}

        //if (timer >= effectsDisplayTime)
        //{
        //    // ... disable the effects.
        //    DisableEffects();
        //}
    }

    public void DisableEffects()
    {
        // Disable the line renderer and the light.
        //triggerLine.enabled = false;
        triggerLight.enabled = false;
        cameraMini.SetActive(false);
        triggerParticles.Stop();
    }

    public void Display()
    {
        Debug.Log("Display");
        trigger.SetActive(false);

        // Play the trigger audioclip.
        triggerAudio.Play();

        // Enable the light.
        triggerLight.enabled = true;

        //  start the particles.
        triggerParticles.Play();

        // Set the shootRay so that it starts at the position of the trigger and points forward.
        shootRay.origin = transform.position;
        shootRay.direction = transform.forward;

        cameraMini.SetActive(true);

        Invoke("DisableEffects", 4.0f);

    }
}
