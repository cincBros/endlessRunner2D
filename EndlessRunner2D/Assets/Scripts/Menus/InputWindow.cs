using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InputWindow : MonoBehaviour
{
	private TMP_InputField inputField;
	
	void Awake() {
		inputField = transform.Find("InputField").GetComponent<TMP_InputField>();
		gameObject.SetActive(false);
	}
	
	public void Show() {
		inputField.text = null;
		gameObject.SetActive(true);
	}
	
	public void Hide() {
		gameObject.SetActive(false);
	}
	
	
	public void SubmitScore() {
		string nick = inputField.text;
		if (!String.IsNullOrWhiteSpace(nick)) {
			Highscores.AddNewHighscore(nick, score.scoreValue);
			Hide();
		}
    }
}
