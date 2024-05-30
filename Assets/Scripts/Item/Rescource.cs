using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rescource : MonoBehaviour
{
    public ItemDate itemToGive;
    public int quantityPerHit = 1;
    public int capacy;
    
    public void Gather(Vector3 hitPoint, Vector3 hitNormal)
    {
        for(int i = 0; i < quantityPerHit; i++)
        {
            if (capacy <= 0) break;
            capacy -= 1;
            Instantiate(itemToGive.dropPrefabs, hitPoint + Vector3.up, Quaternion.LookRotation(hitNormal, Vector3.up));
        }
    }
}
