using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : Obstacle{
    public Sprite exit;

    override protected void onHit(Collider2D other)
    {
        Camera cam = Camera.main;
        Vector2 center = cam.ScreenToWorldPoint(new Vector2(cam.pixelWidth,cam.pixelHeight)/2);
        PositionGenerator posGen = new PositionGenerator(ScreenManager.freeZoneRadius[0], ScreenManager.freeZoneRadius[1]);
        Vector2 angle = posGen.randomPosition(center);

        gameObject.GetComponent<Collider2D>().enabled = false;
        transform.position = angle;
        other.transform.position = angle;
        gameObject.GetComponent<SpriteRenderer>().sprite = exit;
        other.GetComponent<PlayerMovement>().changeDirection(angle);

        Swipe.canSwipeAgain();
    }
}