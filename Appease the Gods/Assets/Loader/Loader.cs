using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour
{
    public GameObject Tree;
    public GameObject Stone;
    public GameObject Metal;
    public GameObject Grass;
    List<Vector2> PotentialPoints = new List<Vector2>();
    List<Vector2> GrassPoints = new List<Vector2>();

    void Start()
    {
        LoadResources();
    }

    void LoadResources()
    {
        // Adds all initial points
        for(int i = 0; i < 500; i++)
        {
            PotentialPoints.Add(Random.insideUnitCircle * 180);
        }

        // Removes points that are too close to eachother
        for(int i = 0; i < PotentialPoints.Count; i++)
        {
            for(int j = 0; j < PotentialPoints.Count; j++)
            {
                if((Vector3.Distance(PotentialPoints[i], PotentialPoints[j]) < 1.0f && i != j) || (Vector3.Distance(Vector3.zero, new Vector3(PotentialPoints[j][0], 0.0f, PotentialPoints[j][1])) < 43.0f))
                {
                    PotentialPoints.RemoveAt(j);
                }
            }
        }

        // Spawns resources and positions them at points in potentialpoints and rotates each resource randomly on the y-axis
        for(int i = 0; i < PotentialPoints.Count; i++)
        {
            int TypeChance = Random.Range(0,3);

            switch(TypeChance)
            {
                case 0:
                    GameObject NewTree = Instantiate(Tree, new Vector3(PotentialPoints[i][0], -11.5f, PotentialPoints[i][1]), Quaternion.identity);
                    NewTree.transform.Rotate(new Vector3(0.0f, Random.Range(0.0f, 360.0f), 0.0f));
                    break;
                case 1:
                    GameObject NewStone = Instantiate(Stone, new Vector3(PotentialPoints[i][0], -11.0f, PotentialPoints[i][1]), Quaternion.identity);
                    NewStone.transform.Rotate(new Vector3(0.0f, Random.Range(0.0f, 360.0f), 0.0f));
                    break;
                case 2:
                    GameObject NewMetal = Instantiate(Metal, new Vector3(PotentialPoints[i][0], -11.0f, PotentialPoints[i][1]), Quaternion.identity);
                    NewMetal.transform.Rotate(new Vector3(0.0f, Random.Range(0.0f, 360.0f), 0.0f));
                    break;
            }
        }

        // Creates points for grass

        for(int i = 0; i < 6000; i++)
        {
            GrassPoints.Add(Random.insideUnitCircle * 180);
        }

        // Removes points too close to points in PotentialPoints

        for(int i = 0; i < GrassPoints.Count; i++)
        {
            for(int j = 0; j < PotentialPoints.Count; j++)
            {
                if(Vector3.Distance(GrassPoints[i], PotentialPoints[j]) < 2.0f)
                {
                    GrassPoints.RemoveAt(i);
                }
            }
        }

        // Spawns grass

        for(int i = 0; i < GrassPoints.Count; i++) 
        {
            GameObject NewGrass = Instantiate(Grass, new Vector3(GrassPoints[i][0], -10.87f, GrassPoints[i][1]), Quaternion.identity);
            NewGrass.transform.Rotate(new Vector3(0.0f, Random.Range(0.0f, 360.0f), 0.0f));
        }
    }
}
