using UnityEngine;
using System.Collections;

public class DragonScript : MonoBehaviour {
	 
	private Rigidbody2D myRigidBody; //para que vuele
	private Animator myAnimator; //para animar el dragón
	private float jumpForce; //fuerza de salto
	public bool isAlive; //si está vivo

	void Start () {
		isAlive = true; //está vivo el dragon

		myRigidBody = gameObject.GetComponent<Rigidbody2D>();
		myAnimator = gameObject.GetComponent<Animator> ();

		jumpForce = 10f; //fuerza de salto
		myRigidBody.gravityScale = 5f; //escala de gravedad

	}
		

	// Update is called once per frame
	void Update () {
		if (isAlive) {
			if (Input.GetMouseButton (0)) { //está función, propia de Unity, checkea si hay un click del mouse o toque en la pantalla
				Flap (); //llama a la función que pone el trigger
			} 
			CheckIfDragonVisibleOnScreen ();
		} 
	}


	void Flap(){
		myRigidBody.velocity = 
			new Vector2 (0,jumpForce);
		
		myAnimator.SetTrigger ("Flap"); //uso del trigger

	}


	void OnCollisionEnter2D(Collision2D target) { //función de colisión
		if (target.gameObject.tag == "Obstacles") {
			isAlive = false; //mata al dragón
			Time.timeScale = 0f; //poner a cero por el fin de juego
		}
	}

	void CheckIfDragonVisibleOnScreen() {
		if (Mathf.Abs(gameObject.transform.position.y) > 5.3f) {
			isAlive = false;
			Time.timeScale = 0f;
		}
	}




















}















