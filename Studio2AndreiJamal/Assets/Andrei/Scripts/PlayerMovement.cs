using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] float sensitivity;
    [SerializeField] float speed;

    public bool hasGun = false;

    float mouseX;
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        mouseX = Input.GetAxis("Mouse X");
    }

    // Update is called once per frame
    void Update()
    {
        MoveOnPlane();
        Rotate();

    }

    void MoveOnPlane()
    {
        Vector3 forwardMovement = Input.GetAxis("Vertical") * transform.forward;
        Vector3 sideMovement = Input.GetAxis("Horizontal") * transform.right;

        //rb.velocity = new Vector3((forwardMovement + sideMovement).normalized.x, rb.velocity.y, (forwardMovement + sideMovement).normalized.z) * speed;
        rb.velocity = (forwardMovement + sideMovement).normalized * speed;
    }

    void Rotate()
    {

        mouseX += Input.GetAxis("Mouse X");
        //mouseY += Input.GetAxis("Mouse Y") * sensitivity;

        //mouseY = Mathf.Clamp(mouseY, -20, 30);

        transform.rotation = Quaternion.Euler(new Vector3(0, mouseX * sensitivity, 0));
    }
}
