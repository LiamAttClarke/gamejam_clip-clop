using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using System.Linq;
using System.IO;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour {

	public static ScoreList highScores;
	public static ScoreList lowScores;
	public static string highScorePath;
	public static string lowScorePath;


	void Awake() {
		highScorePath = System.IO.Path.Combine(Application.dataPath, "HighScores.xml");
		lowScorePath = System.IO.Path.Combine(Application.dataPath, "LowScores.xml");
		if (!File.Exists(ScoreManager.highScorePath)) {
			using (StreamWriter file = new StreamWriter(File.Create(ScoreManager.highScorePath))) ;
		}
		if (!File.Exists(ScoreManager.lowScorePath)) {
			using (StreamWriter file = new StreamWriter(File.Create(ScoreManager.highScorePath))) ;
		}
		highScores = new ScoreList();
		lowScores = new ScoreList();
		Read();
		Write();
	}

	// Use this for initialization
	void Start () {
		print (highScores.ToString());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public static void AddScore(string name, int distance) {
		Score score = new Score (name, distance);
		highScores.AddScore(score);
		lowScores.AddScore(score);
	}

	void OnDestroy() {
		Write ();
	}


	public static void Write() {
		using (FileStream fs = new FileStream(highScorePath, FileMode.Create)) {
			System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(ScoreList));
			x.Serialize(fs, highScores);
			fs.Close();
		}
		using (FileStream fs = new FileStream(lowScorePath, FileMode.Create)) {
			System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(ScoreList));
			x.Serialize(fs, lowScores);
			fs.Close();
		}
	}

	public void Read() {
		try {
			using (StreamReader reader = new StreamReader(highScorePath)) {
				System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(ScoreList));
				highScores = (ScoreList)x.Deserialize(reader);
			}
			using (StreamReader reader = new StreamReader(lowScorePath)) {
				System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(typeof(ScoreList));
				lowScores = (ScoreList)x.Deserialize(reader);
			}
		}
		catch(System.Xml.XmlException e) {
			highScores.list = new List<Score>();
			Write();
		}
	}
}
