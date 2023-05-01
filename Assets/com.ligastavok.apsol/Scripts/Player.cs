using UnityEngine;

public class Player : MonoBehaviour
{
    private int _activeId;

    private SpriteRenderer Render { get; set; }
    [SerializeField] Sprite[] variants;

    private void Awake()
    {
        Render = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        SetActiveBall();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var end = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if(end.y > 2.5f || UIManager.IsOverlay)
            {
                return;
            }

            var direction = (end - (Vector2)transform.position).normalized;

            var ball = Instantiate(GetBall(), Level.Instance.BallParent).GetComponent<Rigidbody2D>();

            var animation = ball.GetComponent<Animation>();
            animation["spawn"].time = 1;

            ball.transform.position = transform.position;
            ball.velocity = direction * 12.0f;

            SetActiveBall();
        }
    }

    private GameObject GetBall()
    {
        return Resources.Load<GameObject>($"balls/{_activeId}");
    }

    private void SetActiveBall()
    {
        _activeId = Random.Range(0, variants.Length);
        var rdSprite = variants[_activeId];
        Render.sprite = rdSprite;
    }
}
