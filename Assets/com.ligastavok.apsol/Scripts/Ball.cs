using PathCreation;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public bool InRoadMap { get; set; }

    private float travelled;
    private const float speed = 0.25f;

    private PathCreator PathCreator { get; set; }

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
}
