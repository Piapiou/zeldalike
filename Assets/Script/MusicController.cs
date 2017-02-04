using UnityEngine;
using System.Collections;

public class MusicController : MonoBehaviour {

	public GameObject camera;
	public AudioClip newMusic;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnColliderEnter2D(Collision2D coll)
	{
		AudioSource source = camera.gameObject.GetComponent<AudioSource> ();
		source.clip = newMusic;
		source.Play ();
	}

}
