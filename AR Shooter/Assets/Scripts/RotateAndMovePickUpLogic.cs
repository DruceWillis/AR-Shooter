using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAndMovePickUpLogic : MonoBehaviour
{
    private Vector3 pos1;
    private Vector3 pos2;
    public float speed = 1.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        pos1 = transform.position;
        pos2 = transform.position;

        pos1.y = transform.position.y - 0.05f;
        pos2.y = transform.position.y + 0.05f;

    }

    // Update is called once per frame
    void Update()
    {
        RotatePickUp();
        MovePickUp();
    }

    private void RotatePickUp()
    {
        transform.Rotate(Vector3.up * 50f * Time.deltaTime);
    }

    private void MovePickUp()
    {
        transform.position = Vector3.Lerp (pos1, pos2, (Mathf.Sin(speed * Time.time) + 1.0f) / 2.0f);
    }
}
