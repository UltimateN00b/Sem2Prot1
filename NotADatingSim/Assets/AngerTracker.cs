using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngerTracker : MonoBehaviour {

    private int _anger;

	// Use this for initialization
	void Start () {
        _anger = 0;

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeAnger(int angerChange)
    {
        _anger += angerChange;
        this.GetComponent<InteractionTracker>().ChangeInteractFromScript(1);
    }

    public int GetAnger()
    {
        return _anger;
    }
}
