﻿
using UnityEngine;

public class KeypadButton : MonoBehaviour {

	private Keypad keypad;

	public int number;

	void Start()
	{
		keypad = transform.parent.GetComponent<Keypad> ();
	}

	public void UseObject()
	{
		if (!keypad.m_accessGranted)
		{
			keypad.InsertCode(number);
		}
	}
}
