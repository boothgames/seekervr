using UnityEngine;
using UnityEngine.UI;

public class SeekerController : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    public float speed = 1.0f;
    private int TOTAL_PICKUPS;
    public Text countText;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        TOTAL_PICKUPS = GameObject.FindGameObjectsWithTag("pickup").Length;
        countText.text = displayCount();
    }

    private void FixedUpdate()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        var movement = new Vector3(moveHorizontal, 0.0f, moveVertical); // ball doesn't have to move up, so y=0
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("pickup")) return;
        other.gameObject.SetActive(false);
        count += 1;
        countText.text = displayCount();
    }

    private string displayCount()
    {
        return "Count: " + count + "/" + TOTAL_PICKUPS;
    }
}