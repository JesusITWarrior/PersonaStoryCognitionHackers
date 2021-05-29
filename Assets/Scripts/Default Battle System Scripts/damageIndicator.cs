using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damageIndicator : MonoBehaviour
{
    public float DestroyTime = 3f;
    public Vector3 Offset = new Vector3(2.25f,1.5f,0.4f);
    public Vector3 Scale = new Vector3(0.5f, 0.5f, 0);

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DestroyTime);
        transform.localPosition += Offset;
        transform.localScale -= Scale;
    }
}
