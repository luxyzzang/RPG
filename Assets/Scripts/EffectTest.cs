using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTest : MonoBehaviour
{
    public GameObject cube;
    public GameObject hitNormalEffect;
    public GameObject hitExplodeEffect;

    private void Start()
    {
        Instantiate(hitNormalEffect, cube.transform.position + Vector3.back, hitNormalEffect.transform.rotation);
        
        GameObject effect = Resources.Load<GameObject>("Particles/Hit Explode Effect");
        Instantiate(effect, cube.transform.position + Vector3.back, effect.transform.rotation);
    }
}
