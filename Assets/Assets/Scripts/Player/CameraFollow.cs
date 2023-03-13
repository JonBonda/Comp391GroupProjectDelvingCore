using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CameraFollow : MonoBehaviour
{
    public GameObject PlayerPawn;

    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        offset = transform.position - PlayerPawn.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = PlayerPawn.transform.position + offset;
    }
}
