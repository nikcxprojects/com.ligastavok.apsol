using UnityEngine;

public class Level : MonoBehaviour
{
    public static Level Instance
    {
        get => FindObjectOfType<Level>();
    }
    public Transform BallParent { get; set; }

    private void Start()
    {
        BallParent = GameObject.Find("balls").transform;

        transform.position = Vector2.left * 13.0f;
        InvokeRepeating(nameof(SpawnBall), 0.0f, 3.0f);
    }

    private void OnDestroy()
    {
        CancelInvoke(nameof(SpawnBall));
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, Vector2.zero, 45.0f * Time.deltaTime);
    }

    private void SpawnBall()
    {
        var ballPrefabs = Resources.LoadAll<GameObject>("balls");
        var rdBalPrefab = ballPrefabs[Random.Range(0, ballPrefabs.Length)];

        var ball = Instantiate(rdBalPrefab, transform).GetComponent<Ball>();
        ball.InRoadMap = true;
    }
}
