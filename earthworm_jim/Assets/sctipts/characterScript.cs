using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterScript : MonoBehaviour
{
	public float forcaPulo;
	public float velocidade;
	public int vidas;
	public GameObject losePrefab;

	public Transform chaoVerificador;
	private bool estaNoChao;
	private bool pulando;
	private SpriteRenderer spriteRenderer;
	private Animator anima;
	private Rigidbody2D rb;
	
	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		anima = GetComponent<Animator>();
	}

	

	// Update is called once per frame
	void Update () {

		if (Input.GetButtonDown("Jump") && estaNoChao)
		{
			rb.velocity = new Vector2(0.0f, forcaPulo);
			anima.SetBool("jumping", true);
			pulando = true;
		}
		else if(!estaNoChao && pulando)
		{
			anima.SetBool("jumping", false);
			pulando = false;
		}


		float mover = Input.GetAxis("Horizontal") * velocidade * Time.deltaTime;
		transform.Translate(mover, 0.0f, 0.0f);

		anima.SetBool("running", Mathf.Abs(Input.GetAxisRaw("Horizontal")) > 0);

		estaNoChao = Physics2D.Linecast(transform.position, chaoVerificador.position, 1 << LayerMask.NameToLayer("Piso"));

		if (mover > 0)
		{
			spriteRenderer.flipX = false;
		}
		else if (mover < 0)
		{
			spriteRenderer.flipX = true;
		}

		//print(estaNoChao);
	}

	void OnCollisionEnter2D(Collision2D c)
	{
		if (c.gameObject.tag == "inimigo" || c.gameObject.tag == "bigorna")
		{
			if (vidas > 0)
			{
				vidas--;
			}
			else
			{
				Instantiate(losePrefab, new Vector3(0.0f, 0.0f, 0.0f), transform.rotation);
				Destroy(gameObject);
			}
		}


	}
}
