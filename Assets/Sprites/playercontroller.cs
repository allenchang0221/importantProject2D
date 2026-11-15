using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    public Sprite[] walkSprites;

    public float animationSpeed = 0.15f;

    private SpriteRenderer spriteRenderer;

    private int frame = 0;

    private float timer = 0f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (walkSprites.Length > 0)
        {
            spriteRenderer.sprite = walkSprites[0];
        }
    }

    void Update()
    {
        float x = 0;
        float y = 0;

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            x = -1;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            x = 1;
        }

        if (Input.GetKey(KeyCode.UpArrow))
        {
            y = 1;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            y = -1;
        }

        Vector3 move = new Vector3(x, y, 0);

        if (move.magnitude > 0)
        {
            move = move.normalized;

            transform.position += move * speed * Time.deltaTime;

            PlayWalkAnimation();
        }
        else
        {
            timer = 0;
            frame = 0;

            if (walkSprites.Length > 0)
            {
                spriteRenderer.sprite = walkSprites[0];
            }
        }
    }

    void PlayWalkAnimation()
    {
        if (walkSprites.Length == 0)
        {
            return;
        }

        timer += Time.deltaTime;

        if (timer >= animationSpeed)
        {
            timer = 0;

            frame++;

            if (frame >= walkSprites.Length)
            {
                frame = 0;
            }

            spriteRenderer.sprite = walkSprites[frame];
        }
    }
}