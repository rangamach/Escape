using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{

    [SerializeField] Door door;
    public void DoorAnimation()
    {
        door.GetComponent<Animator>().enabled = true;
    }

    public void DestoyKey()
    {
        Destroy(this.gameObject);
    }
}
