using UnityEngine;

public class SeekerController : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 1.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        var movement = new Vector3(moveHorizontal, 0.0f, moveVertical); // ball doesn't have to move up, so y=0
        rb.AddForce(movement * speed);
    }
}
