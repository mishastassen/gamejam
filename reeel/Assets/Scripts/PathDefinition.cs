using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PathDefinition : MonoBehaviour {

	//public List<Transform> points = new ArrayList<Transform> ();
	public Transform[] points;


	public IEnumerator<Transform> pathEnumerator() {
		int index = 0;
		int dir = 1;
		while (true) {
			yield return points[index];
			
			if(index<=0)
				dir = 1;
			else if(index+1>=points.Length)
				dir=-1;
			index+=dir;
		}
	}
	
	
	public void OnDrawGizmos() {
		for (int i=0; i+1<points.Length; i++)
			Gizmos.DrawLine (points [i].position, points [i + 1].position);
	}

}
