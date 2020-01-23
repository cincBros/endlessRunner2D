using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class Highscores : MonoBehaviour {

	const string privateCode = "UzLIjdGUDkSMPgF33S9OfwbxmfNDS3g0OulvA_4-6r1Q";
	const string publicCode = "5e18735ffe224b0478ccf83a";
	const string webURL = "http://dreamlo.com/lb/";

	public static Highscore[] highscoresList = new Highscore[0];
	static Highscores instance;
	DisplayHighscores highscoresDisplay; 

	void Awake() {
		instance = this;
		highscoresDisplay = GetComponent<DisplayHighscores>();
	}

	public static void AddNewHighscore(string username, int score) {
		instance.StartCoroutine(instance.UploadNewHighscore(username,score));
	}

	IEnumerator UploadNewHighscore(string username, int score) {
		UnityWebRequest www = UnityWebRequest.Get(webURL + privateCode + "/add/" + UnityWebRequest.EscapeURL(username) + "/" + score);
        yield return www.SendWebRequest();

		if (www.isNetworkError)
			Debug.LogWarning("Error uploading: " + www.error);
		else {
			DownloadHighscores();
		}
	}

	public void DownloadHighscores() {
		StartCoroutine("DownloadHighscoresFromDatabase");
	}

	IEnumerator DownloadHighscoresFromDatabase() {
		UnityWebRequest www = UnityWebRequest.Get(webURL + publicCode + "/pipe/");
        yield return www.SendWebRequest();
		
		if (www.isNetworkError)
			Debug.LogWarning("Error Downloading: " + www.error);
		else {
			FormatHighscores(www.downloadHandler.text);
			highscoresDisplay.OnHighscoresDownloaded(highscoresList);
		}
	}

	void FormatHighscores(string textStream) {
		string[] entries = textStream.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
		highscoresList = new Highscore[entries.Length];

		for (int i = 0; i <entries.Length; i ++) {
			string[] entryInfo = entries[i].Split(new char[] {'|'});
			string username = entryInfo[0];
			int score = int.Parse(entryInfo[1]);
			highscoresList[i] = new Highscore(username,score);
		}
	}
	
	public static int Highest() {
		if (highscoresList.Length == 0) return 0;
		return highscoresList[0].score;
	}
}

public struct Highscore {
	public string username;
	public int score;

	public Highscore(string _username, int _score) {
		username = _username;
		score = _score;
	}

}
