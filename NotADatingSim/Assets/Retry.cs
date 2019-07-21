﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Retry : MonoBehaviour {

    public UnityEvent m_OnRetry;

	// Use this for initialization
	void Start () {
		if (m_OnRetry == null)
        {
            m_OnRetry = new UnityEvent();
        }
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Return))
        {
            RetryRemember.SetRetryTrue();
            m_OnRetry.Invoke();
        }
	}
}
