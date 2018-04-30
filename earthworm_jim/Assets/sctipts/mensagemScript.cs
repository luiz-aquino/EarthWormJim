using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mensagemScript : MonoBehaviour
{

	public float intervalo;

	public int vezes;
	// Use this for initialization
	IEnumerator Start ()
	{
		yield return new WaitForSeconds(intervalo);
		var spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.enabled = !spriteRenderer.enabled;
		if (vezes-- > 0)
		{
			StartCoroutine(Start());
		}
		else
		{
			if (gameObject.tag == "Finish")
			{
				SceneManager.LoadScene("start");
			}
			Destroy(gameObject);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}


}
