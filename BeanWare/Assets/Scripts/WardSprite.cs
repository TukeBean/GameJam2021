using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WardSprite : MonoBehaviour
{
    Vector2 floatY;
    float originalY;

    public SpriteRenderer spriteRenderer;
    public Sprite newSprite;

    public float floatStrength;

    void Start()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        this.originalY = this.transform.position.y;
    }

    void Update()
    {
        floatY = transform.position;
        floatY.y = (Mathf.Sin(Time.time) * floatStrength);
        transform.position = floatY;

        if (GameManager.instance.player.getPlayerHealth() < 3)
        {
            swapSprite();
        }
    }

    void swapSprite()
    {
        spriteRenderer.sprite = newSprite;

    }

}
