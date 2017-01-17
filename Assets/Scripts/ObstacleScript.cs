using UnityEngine;
using System.Collections;

public class ObstacleScript : MonoBehaviour {


	Rigidbody2D myRigidbody;
	float dragonXposition;
	bool isScoreAdded;

	GameManagerScript gameManager;


	// Use this for initialization
	void Start () {
		myRigidbody = gameObject.GetComponent<Rigidbody2D> (); //como en el dragón
		myRigidbody.velocity = new Vector2 (-2.5f,0); //velocidad negativa (para mover a la izquierda, pero solo se mueve en el eje x)

		dragonXposition = 
			GameObject.Find("Dragon").transform.position.x; //busca la posición del dragón

		isScoreAdded = false; //evita que se añada la puntuación múltiples veces

		gameManager = GameObject.Find ("GameManager")
			.GetComponent<GameManagerScript> ();
	}

	void Update() { //por cada frame hay que comprobar'si pasa el dragón (comprobar !isScoreAdded)
		if (transform.position.x <= dragonXposition) { //mira si la posición x del dragón es mayor o igual que la del obstáculo (está escrito al revés)
			if (!isScoreAdded) {
				AddScore ();
				isScoreAdded = true;
			}
		}

		if (transform.position.x <= -10f) {
			Destroy (gameObject); //destruye el objeto
		}
	}

	void AddScore(){
		gameManager.GmAddScore();
	}

}
