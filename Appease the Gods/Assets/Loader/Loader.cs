using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject Tree;
    public GameObject Stone;
    public GameObject Metal;
    List<Vector2> PotentialPoints = new List<Vector2>();

    void Start()
    {
        LoadResources();
    }

    void LoadResources()
    {
        //Adds all initial points
        for(int i = 0; i < 500; i++)
        {
            PotentialPoints.Add(Random.insideUnitCircle * 180);
        }

        //Removes points that are too close to eachother
        for(int j = 0; j < PotentialPoints.Count; j++)
        {
            for(int k = 0; k < PotentialPoints.Count; k++)
            {
                if((Vector3.Distance(PotentialPoints[j], PotentialPoints[k]) < 1.0f && j != k) || (Vector3.Distance(Vector3.zero, new Vector3(PotentialPoints[k][0], 0.0f, PotentialPoints[k][1])) < 43.0f))
                {
                    PotentialPoints.RemoveAt(k);
                }
            }
        }

        //Spawns resources and positions them at points in potentialpoints and rotates each resource randomly on the y-axis
        for(int l = 0; l < PotentialPoints.Count; l++)
        {
            int TypeChance = Random.Range(0,3);

            switch(TypeChance)
            {
                case 0:
                    GameObject NewTree = Instantiate(Tree, new Vector3(PotentialPoints[l][0], -11.5f, PotentialPoints[l][1]), Quaternion.identity);
                    NewTree.transform.Rotate(new Vector3(0.0f, Random.Range(0.0f, 360.0f), 0.0f));
                    break;
                case 1:
                    GameObject NewStone = Instantiate(Stone, new Vector3(PotentialPoints[l][0], -11.0f, PotentialPoints[l][1]), Quaternion.identity);
                    NewStone.transform.Rotate(new Vector3(0.0f, Random.Range(0.0f, 360.0f), 0.0f));
                    break;
                case 2:
                    GameObject NewMetal = Instantiate(Metal, new Vector3(PotentialPoints[l][0], -11.0f, PotentialPoints[l][1]), Quaternion.identity);
                    NewMetal.transform.Rotate(new Vector3(0.0f, Random.Range(0.0f, 360.0f), 0.0f));
                    break;
            }
        }
    }
}
