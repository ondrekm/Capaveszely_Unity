using UnityEngine;

public class StoneMovement : MonoBehaviour
{
    public float speed = 2f;
    public GameManager gameManager;

    void Update()
    {
        if (gameManager.gameEnded)
            return;

        transform.position += Vector3.right * speed * Time.deltaTime;

        if (transform.position.x > 9.5f)
        {
            ResetStone();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && !gameManager.gameEnded)
        {
            SharkController shark =
                other.GetComponent<SharkController>();

            if (shark != null)
            {
                shark.PlayHitAnimation(gameManager);
            }
        }
    }

    void ResetStone()
    {
        float randomY = Random.Range(-3f, 3f);

        transform.position = new Vector3(
            -9.5f,
            randomY,
            transform.position.z
        );
    }
}