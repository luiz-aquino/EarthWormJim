using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjetilScript : MonoBehaviour
{
	public float velocidade;

	public AudioClip impact;
	private AudioSource audioSource;
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start ()
	{
		spriteRenderer = GetComponent<SpriteRenderer>();
		Destroy(gameObject, 2.5f);
		audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		transform.Translate(Vector2.right * velocidade * Time.deltaTime);
	}

	IEnumerator OnCollisionEnter2D(Collision2D c)
	{
		if (c.gameObject.tag == "bigorna")
		{
			spriteRenderer.enabled = false;
			Destroy(c.gameObject);
			audioSource.PlayOneShot(impact, 1f);

			yield return new WaitForSeconds(0.5f);
			Destroy(gameObject);

		}
		else if(c.gameObject.tag == "inimigo")
		{
			spriteRenderer.enabled = false;
			audioSource.PlayOneShot(impact, 1f);
			yield return new WaitForSeconds(0.5f);
			Destroy(gameObject);
		}
	}
}
