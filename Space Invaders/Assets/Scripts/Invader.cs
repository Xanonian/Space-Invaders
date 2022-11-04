using UnityEngine;

public class Invader : MonoBehaviour
{
    //Array containing all sprites for invader
    public Sprite[] animationSprites;
    //Num seconds between sprite updates
    public float animationTime = 1.0f;
    public System.Action killed;
    //Dear god what is this
    private SpriteRenderer _spriteRenderer;
    //Which sprite are we currently animating
    private int _animationFrame;


    //Runs before first frame of game 
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }


    //Runs in first frame of game
    private void Start()
    {
        //Repeatedly runs animate sprite after animationTime, and again every animationTime
        InvokeRepeating(nameof(AnimateSprite), this.animationTime, this.animationTime);
    }


    //Code to animate sprites
    private void AnimateSprite()
    {
        //Iterate _animationFrame
        _animationFrame++;

        //If we would be on a higher value than we have sprites, reset to 0
        if (_animationFrame >= this.animationSprites.Length) {
            _animationFrame = 0;
        }

        //Run our sprite renderer on the _animationFrame'th sprite in the animationSprites array
        _spriteRenderer.sprite = this.animationSprites[_animationFrame];
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Laser")) {
            
            this.killed.Invoke();
            this.gameObject.SetActive(false);
        }
    }



}
