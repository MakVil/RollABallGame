using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    private Rigidbody rb;
    private float movX;
    private float movY;
    private int blobsCollected = 0;
    public TextMeshProUGUI countText;
    public GameObject winText;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        SetCountText();
        winText.SetActive(false);
    }


    void OnMove(InputValue movementValue)
    {
        Vector2 movementVec = movementValue.Get<Vector2>();
        movX = movementVec.x;
        movY = movementVec.y;
    }

    private void FixedUpdate()
    {
        rb.AddForce(new Vector3(movX, 0.0f, movY) * speed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("blob"))
        {
            other.gameObject.SetActive(false);
            blobsCollected += 1;
            SetCountText();

            if (blobsCollected == 15)
            {
                winText.SetActive(true);
            }
        }
    }

    private void SetCountText()
    {
        countText.text = "Blobs: " + blobsCollected.ToString();
    }
}
