using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public int nbCoin = 0;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "coin") ; //On check si on touche une piece
        {
            nbCoin++; // ADD + 1
            Destroy(other.gameObject);
        }
    }
}
