using UnityEngine;
using System.Collections;

public class TurnOn : MonoBehaviour
{
	public GameObject obj;
    void Start ()
    {
        obj.SetActive(true);
    }
}