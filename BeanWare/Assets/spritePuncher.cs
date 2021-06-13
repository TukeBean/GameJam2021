using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spritePuncher : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite punchSprite;
    public Sprite idleSprite;
    public Sprite cookSprite;

    public void punch()
    {
        spriteRenderer.sprite = punchSprite;
    }

    public void idle()
    {
        spriteRenderer.sprite = idleSprite;
    }

    public void cook()
    {
        spriteRenderer.sprite = cookSprite;
    }
}
