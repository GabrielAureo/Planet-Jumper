using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class ElementGenerator{
    
    public List<GameObject> elements;
    public PositionGenerator posGen;

    
    public ElementGenerator(float minBound, float maxBound){
        this.posGen = new PositionGenerator(minBound, maxBound);
        this.elements = new List<GameObject>();
    }

    public abstract List<GameObject> Spawn(List<Vector2> positions);

    public abstract void Delete(GameObject hit);
}