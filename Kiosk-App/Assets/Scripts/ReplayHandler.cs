using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class ReplayHandler : MonoBehaviour
{
    [SerializeField] GameObject navigator;
    [SerializeField] Navigator navScript;
    [SerializeField] Vector3 navInitPos;
    [SerializeField] Button replayBtn;
    [SerializeField] SearchBar searchBar;
    [SerializeField] NavMeshAgent navMesh;
    bool resetPos;
    void Start()
    {
        navInitPos = navigator.transform.position;
        replayBtn.onClick.AddListener(ReplayNavigation);
    }

    void ReplayNavigation()
    {
        resetPos = true;
        //searchBar.GetSearchInput("");
    }

    private void Update()
    {
        ResetPath();
    }

    private void ResetPath()
    {
        if (resetPos)
        {
            navigator.transform.position = navInitPos;
            navMesh.enabled = false;
            navScript.stairsReached = false;
            navScript.pathDrawn = false;
            StartCoroutine(BeginReplay());
        }
    }

    IEnumerator BeginReplay()
    {
        yield return new WaitForSeconds(0.5f);
        resetPos = false;
        navMesh.enabled = true;
        searchBar.GetSearchInput("");
        navScript.SetNavDestination(searchBar.targetLocation);
    }
}
