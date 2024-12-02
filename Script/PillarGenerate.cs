using System.Collections;
using UnityEngine;

public class PillarGenerate : MonoBehaviour
{
    /*[SerializeField] GameObject pillarPrefab;
    [SerializeField] GameObject lastPillarPrefab;*/
    [SerializeField] GameObject parent;
    [SerializeField] Material RedColor;
    [SerializeField] Material ByDefaultColor;
    [SerializeField] GameObject[] prefabList;
    public GameObject tryAgain;
    int count = 0;
    void Start()
    {
        pillarGenerate();
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0) && tryAgain.active == false)
        {
            var vAxis = Input.GetAxis("Mouse X");
            transform.Rotate(new Vector3(0, -vAxis, 0) * 15);
        }
    }
    void pillarGenerate()
    {
        for (int i = 0; i < 15; i++)
        {
            InfiniteGenerator();
            /* var pos = transform.position;
             var rotate = Random.Range(0, 360);


                 GameObject pillar = Instantiate(pillarPrefab, new Vector3(pos.x, pos.y * i, pos.z), Quaternion.Euler(0, rotate, 0), parent.transform);
                 var cylinder1 = Random.Range(0, 6);
                 var cylinder2 = Random.Range(0, 6);
                 for (int j = 0; j < 7; j++)
                 {
                     if (cylinder1 == j || cylinder2 == j)
                     {
                         pillarPrefab.transform.GetChild(0).GetChild(cylinder1).GetComponent<MeshRenderer>().material = RedColor;
                         pillarPrefab.transform.GetChild(0).GetChild(cylinder2).GetComponent<MeshRenderer>().material = RedColor;
                     }
                     else
                     {
                         pillarPrefab.transform.GetChild(0).GetChild(j).GetComponent<MeshRenderer>().material = ByDefaultColor;
                     }
                 }*/
        }

    }
    public void InfiniteGenerator()
    {
        var pos = transform.position;
        var rotate = Random.Range(0, 360);
        var randomPrefab = Random.Range(0, 5);
        GameObject pillar = Instantiate(prefabList[randomPrefab], new Vector3(pos.x, pos.y * count, pos.z), Quaternion.Euler(0, rotate, 0), parent.transform);
        var childCounter = prefabList[randomPrefab].transform.GetChild(0).childCount;
        int cylinder1 = Random.Range(0, childCounter);
        var cylinder2 = Random.Range(0, childCounter);
        for (int j = 0; j < childCounter; j++)
        {
            if (count !=0 && (cylinder1 == j || cylinder2 == j))
            {
                pillar.transform.GetChild(0).GetChild(cylinder1).GetComponent<MeshRenderer>().material = RedColor;
                pillar.transform.GetChild(0).GetChild(cylinder1).gameObject.tag = "Loose";
                pillar.transform.GetChild(0).GetChild(cylinder2).GetComponent<MeshRenderer>().material = RedColor;
                pillar.transform.GetChild(0).GetChild(cylinder2).gameObject.tag = "Loose";
            }
            else
            {
                pillar.transform.GetChild(0).GetChild(j).GetComponent<MeshRenderer>().material = ByDefaultColor;
                pillar.transform.GetChild(0).GetChild(j).gameObject.tag = "touch";
            }

        }
        count++; 
    }
}
