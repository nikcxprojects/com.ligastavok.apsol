using PathCreation;
using System;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool InRoadMap { get; set; }

    public float travelled;
    private const float speed = 0.25f;

    private PathCreator PathCreator { get; set; }

    public static Action OnEquals { get; set; }

    private void Awake()
    {
        PathCreator = FindObjectOfType<PathCreator>();
    }

    private void Update()
    {
        if(!InRoadMap)
        {
            return;
        }

        travelled += speed * Time.deltaTime;
        transform.position = PathCreator.path.GetPointAtDistance(travelled);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (InRoadMap)
        {
            return;
        }

        var equals = collision.transform.name == transform.name;
        if(equals)
        {
            OnEquals?.Invoke();

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
