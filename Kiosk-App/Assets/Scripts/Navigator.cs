using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Navigator : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] NavMeshAgent navMesh;
    [SerializeField] bool pathDrawn;
    [SerializeField] BuildingNameHandler buildingHandler;
    [SerializeField] Transform nextLocation;
    bool goingStairs;
    bool stairsReached;

    [SerializeField] SearchBar searchBar;
    private void Start()
    {
        InitLineRender();
    }

    private void Update()
    {
        DrawTrailPath();
        GoToNextFloor();
    }

    private void InitLineRender()
    {
        //Serialize this later
        lineRenderer.startWidth = 0.15f;
        lineRenderer.endWidth = 0.15f;
        lineRenderer.positionCount = 0;
    }

    void DrawTrailPath()
    {
        if (navMesh.hasPath && !pathDrawn)
        {
            pathDrawn = true;

            lineRenderer.positionCount = navMesh.path.corners.Length;
            lineRenderer.SetPosition(0, navMesh.transform.position);

            if (navMesh.path.corners.Length < 2)
            {
                return;
            }

            for (int i = 0; i < navMesh.path.corners.Length; i++)
            {
                Vector3 pointPos = new Vector3(navMesh.path.corners[i].x, navMesh.path.corners[i].y, navMesh.path.corners[i].z);
                lineRenderer.SetPosition(i, pointPos);
            }
        }
    }

    public void SetNavDestination(Transform targetLocation)
    {
        if (targetLocation.gameObject.tag == "Level1" || stairsReached)
        {
            navMesh.SetDestination(targetLocation.position);
        }
        else
        {
            // going level 1 stars to level 2 stairs location
            goingStairs = true;
            if (!stairsReached)
            {
                navMesh.SetDestination(buildingHandler.stairs[0].transform.position);
                nextLocation = buildingHandler.stairs[1].transform;
            }
            //GoToNextFloor(buildingHandler.stairs[1].transform);
        }
    }

    void GoToNextFloor()
    {
        if (goingStairs)
        {
            print(Vector3.Distance(navMesh.transform.position, navMesh.destination));
            if (Vector3.Distance(navMesh.transform.position, navMesh.destination) <= navMesh.stoppingDistance)
            {
                navMesh.enabled = false;
                navMesh.transform.position = nextLocation.position;
                pathDrawn = false;
                stairsReached = true;
            }
        }
        if (stairsReached)
        {
            StartCoroutine(EnableNavMesh());
        }
    }

    IEnumerator EnableNavMesh()
    {
        yield return new WaitForSeconds(0.1f);
        print(navMesh.destination);
        navMesh.enabled = true;
        SetNavDestination(searchBar.targetLocation);
        DrawTrailPath();
        goingStairs = false;
    }
}
