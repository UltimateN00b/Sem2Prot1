using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTracker : MonoBehaviour {

    private int _interactCount;

	// Use this for initialization
	void Start () {
        _interactCount = 0;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeInteract(int change)
    {
        _interactCount += change;
        Debug.Log("CHANGED INTERACT FROM GAME");
    }

    public void ChangeInteractFromScript(int change)
    {
        _interactCount += change;
    }

    public int GetInteractCount()
    {
        return _interactCount;
    }
}
