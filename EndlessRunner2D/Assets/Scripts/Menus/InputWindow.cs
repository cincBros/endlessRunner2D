using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputWindow : MonoBehaviour
{
	TMP_InputField inputField;
	//public Button submitButton;
	
	void Awake() {
		inputField = transform.Find("InputField").GetComponent<TMP_InputField>();
		inputField.text = "";
		gameObject.SetActive(false);
		//submitButton.interactable = true;
	}
	
	public void Show() {
		gameObject.SetActive(true);
	}
	
	public void Hide() {
		gameObject.SetActive(false);
	}
	
	
	public void SubmitScore() {
		string nick = inputField.text;
		if (!String.IsNullOrWhiteSpace(nick)) {
			Highscores.AddNewHighscore(nick, score.scoreValue);
			inputField.text = "";
			//submitButton.interactable = false;
			Hide();
		}
    }
}
