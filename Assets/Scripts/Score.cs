using System;
using UnityEngine;
using System.Collections;
using System.Xml;
using System.Xml.Serialization;

public class Score : IComparable {
	[XmlAttribute("name")]
	public string name;
	[XmlAttribute("distance")]
	public int distance;

	public Score() {}

	public Score(string name, int distance) {
		this.distance = distance;
		this.name = name;
	}

	int IComparable.CompareTo(object obj) {
		Score score2 = (Score)obj;
		Score score1 = (Score)this;
		if (score1.distance < score2.distance) return 1;
		else if (score1.distance > score2.distance) return -1;
		else return 0;
	}
}
