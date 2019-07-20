using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carpet : MonoBehaviour {

    private bool _hasSpilled;
    private bool _popcornGone;

	// Use this for initialization
	void Start () {
        _hasSpilled = false;
    }
	
	// Update is called once per frame
	void Update () {

        if (_hasSpilled == false)
        {
            if (Popcorn.HasSpilled()&& !GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().IsShowing())
            {
                this.GetComponent<Item>().ChangeApplicableButton("Bite");
                this.GetComponent<Item>().ChangeApplicableButton("Pee On");
                _hasSpilled = true;
            }
        }else if (GameObject.Find("Popcorn") == null)
        {
            if (!_popcornGone)
            {
                this.GetComponent<Item>().ChangeApplicableButton("Bite");
                this.GetComponent<Item>().ChangeApplicableButton("Pee On");
                _popcornGone = true;
            }
        }
	}
}
