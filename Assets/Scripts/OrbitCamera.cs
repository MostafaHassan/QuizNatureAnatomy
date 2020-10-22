using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCamera : MonoBehaviour {
    public GameObject target;

    private Vector3 prevPos;

    private Vector2 prevMousePos;
    private Vector2 deltaMousePos;
    private Vector3 mouseDirection;
    private Vector3 mousePositionDown;
    private float sensitivity = 0.1f;

    private float offset = 5;
    private float timer = 0;
    private float resetTimer = 0.2f;

    private Vector3 originalPosition;
    private Quaternion originalRotation;

    void Start () {
        originalPosition = transform.position;
        originalRotation = transform.rotation;

    }

    void Update()
    {
        if (target == null)
            return;

        deltaMousePos.x = Input.mousePosition.x - prevMousePos.x;
        deltaMousePos.y = Input.mousePosition.y - prevMousePos.y;

        float dist = Vector3.Distance(transform.position, target.transform.position);

        // Create mouse direction
        if (Input.GetMouseButtonDown(1))
        {
            mousePositionDown = Input.mousePosition;
            if (timer < resetTimer)
                ResetView();
            timer = 0;
        }
        mouseDirection = Input.mousePosition - mousePositionDown;
        mouseDirection *= 0.3f;

        if (Input.GetMouseButton(1))
        {
            // Create force from camera to mouse direction
            Vector3 dir = target.transform.position - transform.position;
            Vector3 force = AddForce(dir, mouseDirection);

            force.z = 0;
            force.x = Mathf.Clamp(force.x, -120, 120);
            force.y = Mathf.Clamp(force.y, -120, 120);

            Vector3 fullForce = force * Time.deltaTime * sensitivity;

            // Rotate slowly towards target
            //transform.forward = dir.normalized;
            Quaternion targetRot = Quaternion.LookRotation(dir, transform.up);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, 2);

            // Move on local axis
            transform.Translate(fullForce);
        }

        prevMousePos = Input.mousePosition;
        prevPos = transform.position;


        if (dist < offset * 10 && Input.mouseScrollDelta.y < 0)
        {
            transform.position += transform.forward * Input.mouseScrollDelta.y;
                
                //new Vector3(0, 0, Input.mouseScrollDelta.y);
        }
        else if(dist > offset && Input.mouseScrollDelta.y > 0)
        {
            transform.position += transform.forward * Input.mouseScrollDelta.y;
        }

        timer += Time.deltaTime;
    }

    Vector3 AddForce(Vector3 dir, Vector3 force)
    {
        dir += force;
        return dir;
    }

    void ResetView()
    {
        transform.position = originalPosition;
        transform.rotation = originalRotation;
    }
}
