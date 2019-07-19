using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoreInfoPuppyLove : MonoBehaviour {

    private static string _myName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static void EnterName(string name)
    {
        _myName = name;
    }

    public static string GetName()
    {
        return _myName;
    }
}
