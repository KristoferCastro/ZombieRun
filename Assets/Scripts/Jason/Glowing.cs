using UnityEngine;
using System.Collections;

public class Glowing : MonoBehaviour
{
	float fade = 0.002f;
	
	void Update()
	{
		StartCoroutine(Pulsate());
	}
	
	IEnumerator Pulsate()
	{
		while(true)
		{
			if(light.intensity > 0.0f){
				light.intensity-= fade;
			} else {
				light.intensity = 5;
			}
			yield return new WaitForEndOfFrame();
		}
	}
}