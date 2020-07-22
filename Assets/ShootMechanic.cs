using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootMechanic : MonoBehaviour
{
    private bool isPressed;

    private float releaseDelay;

    private Rigidbody2D rb;
    private SpringJoint2D sj;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        sj = GetComponent<SpringJoint2D>();

        releaseDelay = 1 / (sj.frequency * 4);

    }

    // Update is called once per frame
    void Update()
    {
        if (isPressed)
        {
            drag();
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            isPressed = true;
            rb.isKinematic = true;
        }
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            isPressed = false;
            rb.isKinematic = false;
            StartCoroutine(release());
        }
    }

    private void drag()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        rb.position = mousePosition;
    }

    private IEnumerator release()
    {
        yield return new WaitForSeconds(releaseDelay);
        sj.enabled = false;
    }
}



