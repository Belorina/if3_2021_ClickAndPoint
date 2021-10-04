using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehavior : MonoBehaviour
{
    public AshBehavior ash;


    // Start is called before the first frame update
    void Start()
    {
        int index = Random.Range(0,4);

        if(ash == null)
        {
            ash = FindObjectOfType<AshBehavior>();
        }

        Material mat = ash.materials[index];
        GetComponent<Renderer>().material = mat;
    }

    private void OnMouseDown()
    {
        ash.SetDestination(this);
    }

}
