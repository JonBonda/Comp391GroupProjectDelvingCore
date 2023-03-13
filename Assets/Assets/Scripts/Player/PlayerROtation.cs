using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerROtation : MonoBehaviour
{

    // Update is called once per frame
    void Update()
    {
        Vector3 MousePosition = Input.mousePosition;
        MousePosition = Camera.main.ScreenToWorldPoint(MousePosition);

        Vector3 PlayerDirection = new Vector2(MousePosition.x - transform.position.x, MousePosition.y - transform.position.y);
        transform.up = PlayerDirection;
    }
}