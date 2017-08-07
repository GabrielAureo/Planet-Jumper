using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum ObstacleEnum1{
	 
	Entropy = 0,
	WormHole = 1,
	BlackHole = 2
}

public enum PlanetEnum{
	Normal= 0,
	Broken = 1
}

public enum EnemyEnum{
	Normal = 0
}

public class PrefabEntry<T>{
	[SerializeField]public GameObject value;
	[SerializeField]public T key;
}

[Serializable]
public class ObstacleEntry : PrefabEntry<ObstacleEnum1>{}
[Serializable]
public class PlanetEntry : PrefabEntry<PlanetEnum>{}
[Serializable]
public class EnemyEntry : PrefabEntry<EnemyEnum>{}



