using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeIn : MonoBehaviour
{

  public float fadetime;

  // Use this for initialization
  void Start()
  {
    Image some = this.GetComponent<Image>();
    some.CrossFadeAlpha(0, fadetime, true);
  }

  // Update is called once per frame
  void Update()
  {

  }

}
