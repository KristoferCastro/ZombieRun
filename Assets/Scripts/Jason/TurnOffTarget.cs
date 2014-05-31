using UnityEngine;
using System.Collections;

public class TurnOffTarget : MonoBehaviour
{
	public GameObject obj;
    void Start ()
    {
        obj.SetActive(false);
    }
}