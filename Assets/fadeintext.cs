using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class fadeintext : MonoBehaviour {

  public float fadetime;
	// Use this for initialization
	void Start () {
	    Text some = this.GetComponent<Text>();
    some.CrossFadeAlpha(0, fadetime, true);
 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
