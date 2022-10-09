using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public List<Material> materials;

    public Material GetMaterial(int i)
    {
        return materials[i];
    }

}
