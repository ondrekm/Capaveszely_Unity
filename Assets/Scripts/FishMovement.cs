using UnityEngine;
using System.Collections;

public class FishMovement : MonoBehaviour
{
    public float speed = 2f;
    public GameManager gameManager;
    public float minX = -7f;
    public float maxX = 7f;

    void Update()
    {
        if (gameManager.gameEnded)
            return;

        transform.position += Vector3.down * speed * Time.deltaTime;

        if (transform.position.y < -5f)
        {
            ResetFish();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(HandleFishCatch(other));
        }
    }

    IEnumerator HandleFishCatch(Collider2D other)
    {
        // Megvárjuk, hogy az adott képkocka összes ütközése lefusson.
        yield return new WaitForEndOfFrame();

        // Ha közben kõnek ütköztünk, a halfogás már nem számít.
        if (gameManager.gameEnded)
            yield break;

        SharkController shark = other.GetComponent<SharkController>();

        if (shark != null)
        {
            shark.PlayEatAnimation();
        }

        gameManager.AddPoint();
        ResetFish();
    }

    void ResetFish()
    {
           float randomX = Random.Range(minX, maxX);

        transform.position = new Vector3(
            randomX,
            5f,
            transform.position.z
        );
    }
}