using UnityEngine;

public class CircleAroundPlayer : MonoBehaviour
{
    [SerializeField] private Transform legOfPlayer;
    
    public float radius = 5f;
    public int segments = 32;

    private LineRenderer lineRenderer;
    private Vector3[] positions;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        positions = new Vector3[segments + 1];
        lineRenderer.positionCount = segments + 1;
    }

    void Update()
    {
        for (int i = 0; i <= segments; i++)
        {
            float angle = (float)i / (float)segments * Mathf.PI * 2f;
            Vector3 pos = new Vector3(Mathf.Cos(angle), 0f, Mathf.Sin(angle)) * radius;
            pos += legOfPlayer.position;
            positions[i] = pos;
        }

        lineRenderer.SetPositions(positions);
    }
}

