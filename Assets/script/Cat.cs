using System.Collections;
using UnityEngine;

public class Cat : MonoBehaviour
{
    public VariableJoystick variableJoystick;

    private Rigidbody rb;

    public float jumpForce = 5f;

    private Collider lastCubeCollider;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private IEnumerator ReenableCollision()
    {
        yield return new WaitForSeconds(0.2f);

        if (lastCubeCollider)
            Physics.IgnoreCollision(lastCubeCollider, GetComponent<Collider>(), false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Cube"))
        {
            lastCubeCollider = collision.collider;
            Debug.Log("cube collision!!!");
        }
        if (collision.gameObject.CompareTag("Ground"))
        {
            //Debug.Log("ground collision!!!");
        }
    }

    void Jump()
    {
        if(lastCubeCollider != null)
        {
            Physics.IgnoreCollision(lastCubeCollider, GetComponent<Collider>(), true);
        }

        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

        StartCoroutine(ReenableCollision());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }

        float moveX = variableJoystick.Direction.x;
        float moveZ = variableJoystick.Direction.y;

        Vector3 force;
        force.x = -moveX;
        force.y = 0;
        force.z = -moveZ;

        rb.AddForce(force * 0.7f, ForceMode.Impulse);
    }
}
