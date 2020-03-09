using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestDecel : MonoBehaviour
{
    public int x;
    public float k;
    public float m;
    Vector3 Vx = Vector3.one;
    // Start is called before the first frame update
    void Start()
    {
        Vx = Vx.normalized * x;
        Debug.Log(Vx.magnitude);
    }

    // Update is called once per frame
    void Update()
    {
        Vx = Vx.normalized * (Vx.magnitude - ((k * Vx.magnitude) / m) * Time.deltaTime);

        Debug.Log(Vx.magnitude);
    }
}
