using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Obtenemos el Tag del padre y este objeto se lo asigna
public class ParentTag : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        this.tag = transform.parent.tag;
    }
}
