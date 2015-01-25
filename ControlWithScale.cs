using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {
	/** The x, y and z axes positions */
	float xRot = Quaternion.x; 
	float yRot = Quaternion.y;
	float zRot = Quaternion.z;
	int MAX_TURN = 1;
	int[] commands = new int[3]; 
	void Start () {
		for (int i=0; i<3; i++) {
			commands [i] = 0;
		}
	}
	
	// Update is called once per frame
	int[] Update () { 
		//if less than nullzone, will not actually command
		if (Mathf.Abs (xRot) >= .08) {
			commands [0] = -MAX_TURN * (xRot / 3.14);
		}
		else {
			commands[0]=0;
		}
		if (Mathf.Abs (yRot) >= .14) {
			commands[1]=MAX_TURN*(yRot/3.14);
		}
		else {
			commands[1]=0;
		}
		if (Mathf.Abs (zRot) >= .08) {
			commands[2]=MAX_TURN*(zRot/3.14);
		}
		else {
			commands[2]=0;
		}
		return commands;
	}
}

