using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private float startPosX;
    [SerializeField]
    private float endPosX;

    private Vector3 defaultPosition;

    void Start()
    {
        defaultPosition = new Vector3(startPosX, transform.localPosition.y, transform.localPosition.z);
    }

    void Update()
    {
        CheckPosition();
        MovePosition();
    }

    private void CheckPosition()
    {
        if (transform.localPosition.x > endPosX)
        {
            ResetPosition();
        }
    }

    private void ResetPosition()
    {
        transform.localPosition = defaultPosition;
    }

    private void MovePosition()
    {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
}
