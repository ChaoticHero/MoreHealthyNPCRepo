using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private Vector3 startPos;
    public Vector3 targetPos;
    public Vector3 newtargetPos;
    public float speed;
    Vector3 newRotation = new Vector3(0, 90, 0);
    Vector3 oldRotation = new Vector3(0, -90, 0);

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        movearound();
    }
    void movearound()
    {

        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        if (transform.position == targetPos)
            targetPos = startPos;

        if (transform.position == startPos)
        {
            targetPos = newtargetPos;
        }
        if (transform.position == newtargetPos)
        {
            transform.eulerAngles = newRotation;
        }
        else if (transform.position == startPos)
        {
            transform.eulerAngles = oldRotation;
        }
    }
}
