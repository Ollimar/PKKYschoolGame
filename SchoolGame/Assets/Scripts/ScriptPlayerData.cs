using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptPlayerData : MonoBehaviour {

    public int metallialaVisits = 0;
    public int teatteriEsitekVisits = 0;

    public int scoreMetalliMinipeli1 = 0;
    public bool winMetalliMinipeli1 = false;

    public string playerName;
    public int hatNumber = 0;

	// Use this for initialization
	void Start () {
        DontDestroyOnLoad(this.gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
