using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


[RequireComponent(typeof(NavMeshAgent))]

public class AshBehavior : MonoBehaviour
{
    //comme il aura plusieurs couleurs, autant avoir un tableau
    public Material [] materials;
    private NavMeshAgent agent;
    private CubeBehavior cubeDestination;
    
    void Start()
    {
        if(materials == null || materials.Length < 4)
        {
            Debug.LogError("This component need 4 materials", gameObject); 
            // pour prévenir l'utilisateur de ce qu'il faut et de quel objet en question
        }
        else 
        {
            int index = Random.Range(0,3);
            GetComponent<Renderer>().material = materials[index];
        }
        agent = GetComponent<NavMeshAgent>();
    }

    public void SetDestination(CubeBehavior cube)
    {
        agent.SetDestination(cube.transform.position);
        cubeDestination = cube;

    }

    private void ChangeColor()          // transposotion d un algortihme d inversion  
    {
        Material mat = GetComponent<Renderer>().material;
        GetComponent<Renderer>().material = cubeDestination.GetComponent<Renderer>().material;
        cubeDestination.GetComponent<Renderer>().material = mat;
    }

    // Update is called once per frame
    void Update()
    {
        if(cubeDestination != null) 
        {
            if(Vector3.Distance(cubeDestination.transform.position, transform.position) < 0.5f)
            {
                ChangeColor();
                cubeDestination = null;
            }
        }
    }
}
