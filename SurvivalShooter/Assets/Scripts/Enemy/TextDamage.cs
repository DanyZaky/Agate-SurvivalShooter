using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextDamage : MonoBehaviour
{
    public float DestroyTime = 3f;
    public Vector3 Offset = new Vector3(0, 2, 0);
    public Vector3 RandomInstensity = new Vector3(0.5f, 0, 0);

    void Start()
    {
        Destroy(gameObject, DestroyTime);

        transform.localPosition += Offset;
        transform.localPosition += new Vector3(Random.Range(-RandomInstensity.x, RandomInstensity.y),
            Random.Range(-RandomInstensity.y, RandomInstensity.y),
            Random.Range(-RandomInstensity.z, RandomInstensity.z));

    }
}
