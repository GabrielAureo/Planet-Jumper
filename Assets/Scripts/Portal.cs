using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : Obstacle{
    public Sprite exit;

    override protected void onHit(Collider2D other)
    {
        Camera cam = Camera.main;
        Vector2 center = cam.ScreenToWorldPoint(new Vector2(cam.pixelWidth,cam.pixelHeight)/2);
        Vector2 angle = new PositionGenerator(0.5f, 0.6f).randomPosition(center);

        gameObject.GetComponent<Collider2D>().enabled = false;
        transform.position = angle;
        other.transform.position = angle;
        gameObject.GetComponent<SpriteRenderer>().sprite = exit;

        Swipe.canSwipeAgain();
    }
}