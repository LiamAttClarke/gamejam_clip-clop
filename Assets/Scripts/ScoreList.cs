using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System;

[Serializable]
public class ScoreList {
	[XmlArray("HighScores")]
	[XmlArrayItem(typeof(Score), ElementName = "ScoreElement")]
	public List<Score> list;
	public bool highScore;
	//string path = "HighScores.xml";

	public ScoreList() {
		list = new List<Score>();
	}

	public void AddScore(Score score) {
		list.Add(score);
		list.Sort();
		if (highScore) {
			if (list.Count > 5)
				list.RemoveAt (list.Count);
		}
		else {
			if (list.Count > 5)
				list.RemoveAt (0);
		}
		ScoreManager.Write();
	}

	public override string ToString() {
		string result = "";
		for (int i=0;i<list.Count;i++) {
			result += list[i].ToString() + "\n";
		}
		return result;
	}

	public void print() {
		for (int i = 0; i < list.Count; i++) {
			Debug.Log(list[i].name + " , " + list[i].distance);
		}
	}

}
