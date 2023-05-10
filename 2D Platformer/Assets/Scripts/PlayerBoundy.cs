using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBoundy : MonoBehaviour
{
    [SerializeField] float leftBoundy;
    [SerializeField] float rightBoundy;


    void Update()
    {
        LeftRightBoundry();
    }

    void LeftRightBoundry()
    {
        if (transform.position.x < leftBoundy)
        {
            transform.position = new Vector3(leftBoundy, transform.position.y, transform.position.z);
        }
        if (transform.position.x > rightBoundy)
        {
            transform.position = new Vector3(rightBoundy, transform.position.y, transform.position.z);
        }
    }
}
