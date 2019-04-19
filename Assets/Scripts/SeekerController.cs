using System;
using System.Timers;
using UnityEngine;
using UnityEngine.UI;

public class SeekerController : MonoBehaviour
{
    public float speed = 20;
    public float gameTime = 60;
    public Text countText;
    public Text finalText;

    private Rigidbody rb;
    private int count;
    private int TOTAL_PICKUPS;
    private float timeLeft;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        TOTAL_PICKUPS = GameObject.FindGameObjectsWithTag("pickup").Length;
        countText.text = displayCount();
        timeLeft = gameTime;
    }

    private void LateUpdate()
    {
        timeLeft -= Time.deltaTime;
        if (timeLeft < 0 && count < TOTAL_PICKUPS)
        {
            finalText.text = "Game Over. Reset to play again";
        }
    }

    private void FixedUpdate()
    {
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");
        if (SystemInfo.deviceType == DeviceType.Handheld)
        {
            moveHorizontal = Input.acceleration.x;
            moveVertical = Input.acceleration.y;
        }

        var movement = new Vector3(moveHorizontal, 0.0f, moveVertical); // ball doesn't have to move up, so y=0
        rb.AddForce(movement * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.CompareTag("pickup")) return;
        other.gameObject.SetActive(false);
        updateCount();
    }

    private void updateCount()
    {
        count += 1;
        countText.text = displayCount();
        if (count == TOTAL_PICKUPS)
        {
            finalText.text = "You Win";
        }
    }

    private string displayCount()
    {
        return "Count: " + count + "/" + TOTAL_PICKUPS;
    }
}