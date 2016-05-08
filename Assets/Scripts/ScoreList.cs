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
	//string path = "HighScores.xml";

	public ScoreList() {
		list = new List<Score>();
	}

	public void AddScore(Score score) {
		list.Add(score);
		list.Sort();
		if (list.Count > 5)
			list.RemoveAt (list.Count);
		ScoreManager.Write();
	}

	public override string ToString() {
		string result = "";
		for (int i=0;i<list.Count;i++) {
			result += list[i].ToString() + "\n";
		}
		return result;
	}

}
