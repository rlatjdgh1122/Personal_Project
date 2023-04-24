using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public GameObject Pedestal;

    [SerializeField]
    private List<GameObject> obstacles;
    void Start()
    {
        obstacles.ForEach(p =>
        {
            Instantiate(Pedestal, transform.position, Quaternion.identity);
            Instantiate(p, Pedestal.transform.parent);
        });
    }


    // Update is called once per frame
    void Update()
    {

    }
}
