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
            GameObject per = Instantiate(Pedestal, transform.position, Quaternion.identity);
            Instantiate(p, per.transform.parent);
        });
    }
}
