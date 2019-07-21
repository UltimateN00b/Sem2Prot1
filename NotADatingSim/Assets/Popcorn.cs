using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popcorn : MonoBehaviour {

    private static bool _spilled;
	// Use this for initialization
	void Start () {
        _spilled = false;
    }
	
	// Update is called once per frame
	void Update () {
        CheckSpilled();
    }

    private void CheckSpilled()
    {
        if (this.gameObject.activeInHierarchy)
        {
            _spilled = true;
        }
    }

    public static bool HasSpilled()
    {
        return _spilled;
    }

    public static void SetSpillFalse()
    {
        _spilled = false;
    }
}
