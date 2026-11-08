using UnityEngine;
using System.Collections;

public class SharkController : MonoBehaviour
{
    public float speed = 5f;

    public Sprite swimRightSprite;
    public Sprite swimLeftSprite;

    public Sprite eatRightSprite;
    public Sprite eatLeftSprite;

    public Sprite hitRightSprite;
    public Sprite hitLeftSprite;

    public Sprite gameOverSprite;

    private SpriteRenderer spriteRenderer;
    private bool facingRight = true;
    private bool isEating = false;
    private bool isHit = false;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isHit)
            return;

        float horizontal = 0f;
        float vertical = 0f;

        if (Input.GetKey(KeyCode.LeftArrow))
            horizontal = -1f;

        if (Input.GetKey(KeyCode.RightArrow))
            horizontal = 1f;

        if (Input.GetKey(KeyCode.UpArrow))
            vertical = 1f;

        if (Input.GetKey(KeyCode.DownArrow))
            vertical = -1f;

        if (!isEating)
        {
            if (horizontal > 0)
            {
                facingRight = true;
                spriteRenderer.sprite = swimRightSprite;
            }
            else if (horizontal < 0)
            {
                facingRight = false;
                spriteRenderer.sprite = swimLeftSprite;
            }
        }

        Vector3 movement =
            new Vector3(horizontal, vertical, 0f);

        transform.position +=
            movement.normalized * speed * Time.deltaTime;

        KeepSharkOnScreen();
    }

    public void PlayEatAnimation()
    {
        if (!isHit)
            StartCoroutine(EatAnimation());
    }

    IEnumerator EatAnimation()
    {
        isEating = true;

        spriteRenderer.sprite =
            facingRight ? eatRightSprite : eatLeftSprite;

        yield return new WaitForSeconds(0.4f);

        isEating = false;

        spriteRenderer.sprite =
            facingRight ? swimRightSprite : swimLeftSprite;
    }

    public void PlayHitAnimation(GameManager gameManager)
    {
        if (!isHit)
            StartCoroutine(HitAnimation(gameManager));
    }

    IEnumerator HitAnimation(GameManager gameManager)
    {
        isHit = true;
        isEating = false;

        gameManager.BeginGameOver();

        spriteRenderer.sprite =
            facingRight ? hitRightSprite : hitLeftSprite;

        yield return new WaitForSeconds(0.4f);

        spriteRenderer.sprite = gameOverSprite;

        gameManager.FinishGameOver();
    }

    void KeepSharkOnScreen()
    {
        Vector3 bottomLeft =
            Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));

        Vector3 topRight =
            Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));

        float halfWidth = spriteRenderer.bounds.extents.x;
        float halfHeight = spriteRenderer.bounds.extents.y;

        float x = Mathf.Clamp(
            transform.position.x,
            bottomLeft.x + halfWidth,
            topRight.x - halfWidth
        );

        float y = Mathf.Clamp(
            transform.position.y,
            bottomLeft.y + halfHeight,
            topRight.y - halfHeight
        );

        transform.position =
            new Vector3(x, y, transform.position.z);
    }
}