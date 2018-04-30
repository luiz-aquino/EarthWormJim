using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboScript : MonoBehaviour
{
	public Transform telaDireita;
	public Transform telaEsquerda;
	public Transform personagem;
	public GameObject trombone;
	public GameObject wonPrefab;
	public float velocidade;
	public int vidas;

	private bool initialPosition;
	private bool estaNoChao;
	private SpriteRenderer spriteRenderer;
	private Animator anima;
	private Rigidbody2D rb;
	private Vector3? destination;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		anima = GetComponent<Animator>();
		initialPosition = true;
		destination = null;
		StartCoroutine(SimpleAI());
	}
	
	// Update is called once per frame
	void Update () {
		if (destination != null)
		{
			anima.SetBool("andando", true);
			float step = velocidade * Time.deltaTime;
			transform.position = Vector3.MoveTowards(transform.position, destination.Value, step);

			if (Math.Abs(transform.position.x - destination.Value.x) < 0.5)
			{
				anima.SetBool("andando", false);
				destination = null;
				spriteRenderer.flipX = !spriteRenderer.flipX;
				StartCoroutine(SimpleAI());
			}
		}
	}

	IEnumerator SimpleAI()
	{
		yield return new WaitForSeconds(2);
		anima.SetBool("pisando", true);
		yield return new WaitForSeconds(1);
		Instantiate(trombone, new Vector3(personagem.position.x, personagem.position.y + 10.0f, personagem.position.z),personagem.rotation);
		anima.SetBool("pisando", false);
		yield return new WaitForSeconds(2);
		anima.SetBool("pisando", true);
		yield return new WaitForSeconds(1);
		Instantiate(trombone, new Vector3(personagem.position.x, personagem.position.y + 10.0f, personagem.position.z),personagem.rotation);
		yield return new WaitForSeconds(2);
		if (initialPosition)
		{
			destination = telaEsquerda.position;
			initialPosition = false;
		}
		else
		{
			destination = telaDireita.position;
			initialPosition = true;
		}
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		if (c.gameObject.tag == "tiro")
		{
			if (vidas > 0)
			{
				vidas--;
			}
			else
			{
				Instantiate(wonPrefab, new Vector3(0.0f, 0.0f, 0.0f), transform.rotation);

				Destroy(gameObject);
			}
		}
	}
}
