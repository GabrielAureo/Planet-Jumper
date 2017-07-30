using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ElementGenerator<T>{

    public Dictionary<T,List<GameObject>> prefabs;
    
    public List<GameObject> elements;
    public PositionGenerator posGen;

    
    public ElementGenerator(Dictionary<T,List<GameObject>> prefabs, float minBound, float maxBound){
        this.prefabs = prefabs;
        this.posGen = new PositionGenerator(minBound, maxBound);
        this.elements = new List<GameObject>();
    }

    public abstract void Spawn(List<Vector2> positions);

    public abstract void Delete(GameObject hit);
}