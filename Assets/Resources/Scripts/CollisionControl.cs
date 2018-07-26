using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionControl : MonoBehaviour {

	public BallMovement ballMovement;
	public ScoreController scoreController;

	void BounceFromRacket(Collision2D c){

		Vector3 ballPosition = this.transform.position;
		Vector3 racketPosition = c.gameObject.transform.position;

		float racketHeight = c.collider.bounds.size.y;

		float x;
		if(c.gameObject.name == "RacketPlayer1"){
			x =  1;
		}
		else{
			x = -1;
		}

		float y = (ballPosition.y - racketPosition.y) / racketHeight;

		this.ballMovement.IncreaseHitCounter();
		this.ballMovement.MoveBall(new Vector2(x,y));
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(collision.gameObject.name == "RacketPlayer1" || collision.gameObject.name == "RacketPlayer2"){
			this.BounceFromRacket(collision);
		}
		else if(collision.gameObject.name == "WallLeft"){
			Debug.Log("Collission with WallLeft");
			this.scoreController.GoalPlayer2();
			StartCoroutine(this.ballMovement.StartBall(true));
		}
		else if(collision.gameObject.name == "WallRight"){
			Debug.Log("Collission with WallRight");
			this.scoreController.GoalPlayer1();
			StartCoroutine(this.ballMovement.StartBall(false));
		}
	}
}
