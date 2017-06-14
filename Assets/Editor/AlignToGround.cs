using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class AlignToGround : MonoBehaviour 
{
	[MenuItem("Tools/Transform Tools/Align %t")]
	static void AlingObjectToGround()
	{
		Transform[] transforms = Selection.transforms;
		foreach (Transform myTransform in transforms)
		{
			RaycastHit hit;
			if(Physics.Raycast(myTransform.position, -Vector3.up, out hit))
			{
				Vector3 targetPos = hit.point;
				if(myTransform.GetComponent<MeshFilter>() != null)
				{
					Bounds bounds = myTransform.GetComponent<MeshFilter>().sharedMesh.bounds;
					targetPos.y += bounds.extents.y;
				}
				myTransform.position = targetPos;
				Vector3 targetRot = new Vector3(hit.normal.x, myTransform.eulerAngles.y, hit.normal.z);
				myTransform.eulerAngles = targetRot;
			}
		}
	}


	
}
