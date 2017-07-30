using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionGenerator {
    float radius_x;
    float radius_y;

    float minBound;
    float maxBound;

    public PositionGenerator(float minBound, float maxBound){
        Vector2 edgeVector = Camera.main.ScreenToWorldPoint(Vector2.zero);
        radius_x = edgeVector.x;
        radius_y = edgeVector.y;
        this.minBound = minBound;
        this.maxBound = maxBound;
    }

    public List<Vector2> uniformDistance(int n, Vector2 center, float totalRotation = 0){
        List<Vector2> positions = new List<Vector2>();
        float partAngles = (2*Mathf.PI) /n;

        for (int i = 0; i < n; i++){
            float rotation = Random.Range(-20 * Mathf.Deg2Rad, 20 * Mathf.Deg2Rad);
			float angle = partAngles * i;
			float x = Mathf.Cos(angle + rotation + totalRotation)*(radius_x);
			float y = Mathf.Sin(angle + rotation + totalRotation)*(radius_y);
            Vector2 pos = new Vector2(x,y) * Random.Range(minBound,maxBound);
            positions.Add(pos + center);
        }
        return positions;
    }

    public List<Vector2> targetDistance(int n, Vector2 center, List<Vector2> targets){
        List<Vector2> positions = new List<Vector2>();
        return positions;
    }
}