using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {

	public void PlayGame(){
		Debug.Log("Playgame was pressed");

		//Move us to the game scene
		SceneManager.LoadScene("Game");

	}
}
