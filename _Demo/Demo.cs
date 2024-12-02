using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    [SerializeField] float speed;
    // Update is called once per frame
    void Update()
    {
        var vAxis = Input.GetAxis("Mouse X");
        print("vAxis ===> " + vAxis);
        transform.Rotate(new Vector3(0, -vAxis, 0) * speed);                                   
    }

}
