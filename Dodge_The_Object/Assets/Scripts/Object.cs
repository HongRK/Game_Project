using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public float moveSpeed = 1.3f;

    void Start()
    {

    }
    void Update()
    {
        moveControl();

        if (this.gameObject.transform.position.y <= -6f)
        {
            DestroyImmediate(this.gameObject);
        }

    }
    void moveControl()
    {
        float distanceY = moveSpeed * Time.deltaTime;
        
        this.gameObject.transform.Translate(0, -1 * distanceY, 0);
    }
}
