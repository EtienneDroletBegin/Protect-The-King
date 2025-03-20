using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{

    private List<List<GameObject>> grid;
    [SerializeField] private GameObject TilePrefab;
    [SerializeField] private Material BlackColor;
    [SerializeField] private Material WhiteColor;
    [SerializeField] private GameObject CamRing;
    void Start()
    {
        grid = new List<List<GameObject>>();
        MakeGrid();
    }

    private void MakeGrid()
    {
        for(int i = 0; i<= 7; i++)
        {
            grid.Add(new List<GameObject>());
            for (int j = 0; j<= 7; j++)
            {
                GameObject newTile = Instantiate(TilePrefab, transform);
                newTile.transform.Translate(transform.position.x+j, transform.position.y, transform.position.z+i);
                if ((i+j) % 2 == 0) {
                    newTile.GetComponent<MeshRenderer>().material = BlackColor;
                }
                grid[i].Add(newTile);

            }
        }
                CenterCamRing();
    }

    private void CenterCamRing()
    {
        Vector3 sumVector = new Vector3(0f, 0f, 0f);

        foreach (Transform child in transform)
        {
            sumVector += child.position;
        }

        Vector3 groupCenter = sumVector / transform.childCount;

        CamRing.transform.position = groupCenter;
    }
}
