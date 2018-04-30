using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TromboneScript : MonoBehaviour {

	public AudioClip impact;
	private AudioSource audioSource;

	private SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
		audioSource = GetComponent<AudioSource>();
		spriteRenderer = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator OnCollisionEnter2D(Collision2D c)
	{
		print("Colidiu");
		if (c.gameObject.tag == "Player")
		{
			print("Tocar som");
			audioSource.PlayOneShot(impact, 1f);
			spriteRenderer.enabled = false;
			yield return new WaitForSeconds(0.5f);
		}
		Destroy(gameObject);

	}
}
