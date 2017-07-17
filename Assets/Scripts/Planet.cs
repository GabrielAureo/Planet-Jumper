using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : Platform {
	new void Start()
	{
		base.Start();

		gameObject.tag = "Planet";

	}
}
