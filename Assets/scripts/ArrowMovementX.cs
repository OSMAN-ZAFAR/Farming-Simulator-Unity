using UnityEngine;

public class ArrowMovementX : MonoBehaviour
{
    public float moveDistance = 1f;    
    public float moveSpeed = 2f;        

    private Vector3 startPos;

    void Start()
    {
        startPos = transform.localPosition;
    }

    void Update()
    {
     
        float offset = Mathf.Sin(Time.time * moveSpeed) * moveDistance;
        transform.localPosition = startPos + new Vector3(offset,0,0);
    }
}

