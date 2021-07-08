using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spinner : MonoBehaviour
{
   [SerializeField] float xVal = 0;
   [SerializeField] float yVal = 0;
   [SerializeField] float zVal = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xVal,yVal,zVal);
    }
}
