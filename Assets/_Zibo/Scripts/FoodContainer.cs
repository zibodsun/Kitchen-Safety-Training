using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodContainer : MonoBehaviour
{
    public enum Type
    {
        Raw,
        Cooked,
        Dried
    }

    public Type foodType;

    Vector3 _spawnPos;
    Quaternion _spawnRot;

    private void Awake()
    {
        _spawnPos = transform.position;
        _spawnRot = transform.rotation;
    }

    public void Respawn() {
        transform.position = _spawnPos;
        transform.rotation = _spawnRot;
    }
}
