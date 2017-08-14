using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionGenerator {
    float radius_x;
    float radius_y;

    float minBound;
    float maxBound;

    public List<float> angles = new List<float>();

    public PositionGenerator(float minBound, float maxBound){
        Vector2 edgeVector = Camera.main.ScreenToWorldPoint(Vector2.zero);
        radius_x = edgeVector.x;
        radius_y = edgeVector.y;
        this.minBound = minBound;
        this.maxBound = maxBound;
    }

    public List<Vector2> uniformDistance(RangeBound range, Vector2 center, float totalRotation = 0){
        angles.Clear();
        List<Vector2> positions = new List<Vector2>();
        int n = Random.Range(range.min, range.max);
        float partAngles = (2*Mathf.PI) /n;

        for (int i = 0; i < n; i++){
            float rotation = Random.Range(-20 * Mathf.Deg2Rad, 20 * Mathf.Deg2Rad);
			float angle = (partAngles * i) + rotation + totalRotation;
            angles.Add(angle);
			float x = Mathf.Cos(angle)*(radius_x);
			float y = Mathf.Sin(angle)*(radius_y);
            Vector2 pos = new Vector2(x,y) * Random.Range(minBound,maxBound);
            positions.Add(pos + center);
        }
        return positions;
    }

    public List<Vector2> targetDistance(int n, Vector2 center, List<Vector2> targets){
        List<Vector2> positions = new List<Vector2>();
        return positions;
    }

    public Vector2 randomPosition(Vector2 center){
        float angle = Random.value * Mathf.PI * 2;
        float x = Mathf.Cos(angle) * radius_x;
        float y = Mathf.Sin(angle) * radius_y;

        Vector2 v = (new Vector2(x,y) * Random.Range(minBound,maxBound)) + center;

        return v;
    }
}