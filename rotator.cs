/**This script is attached to the cubes which are to be collected
	 */ 

using UnityEngine;
using System.Collections;

public class rotator : MonoBehaviour {


	/**In this function we give rotating capability to our cubes for animation purpose
	 */
	void Update () {

		transform.Rotate (new Vector3(15,30,45)*Time.deltaTime);
	
	}
}
