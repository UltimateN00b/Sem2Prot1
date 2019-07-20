using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Broom : MonoBehaviour {

    private bool _hasSpilled;
    private bool _popcornGone;

    // Use this for initialization
    void Start () {
        _hasSpilled = false;
    }

    void Update()
    {

        if (_hasSpilled == false)
        {
            if (Popcorn.HasSpilled() && !GameObject.Find("DialogueCanvasDecorated").GetComponent<DialogueBox>().IsShowing())
            {
                this.GetComponent<Item>().enabled = true;
                this.GetComponent<BoxCollider>().enabled = true;
                _hasSpilled = true;
            }
        }
        else if (GameObject.Find("Popcorn") == null)
        {
            if (!_popcornGone)
            {
                this.GetComponent<Item>().enabled = false;
                this.GetComponent<BoxCollider>().enabled = false;
                _popcornGone = true;
            }
        }
    }
}
