using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundy : MonoBehaviour
{
    [SerializeField] float leftBoundry;
    [SerializeField] float righBoundry;
    private float xMove;

    void Update()
    {
        LeftRightBoundry();
    }

    void LeftRightBoundry()
    {
        xMove = Mathf.Clamp(transform.position.x, leftBoundry , righBoundry);
        transform.position = new Vector2(xMove, transform.position.y);

        //if (transform.position.x < leftBoundy)
        //{
        //    transform.position = new Vector3(leftBoundy, transform.position.y, transform.position.z);
        //}
        //if (transform.position.x > rightBoundy)
        //{
        //    transform.position = new Vector3(rightBoundy, transform.position.y, transform.position.z);
        //}
    }
}
