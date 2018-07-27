using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
	[SerializeField] private Sprite sprite;

	public Sprite Sprite
	{
		get { return sprite; }
	}

  private void OnTriggerEnter(Collider other)
  {
      Destroy(gameObject);
  }

  void Update()
  {
      Spin();
	}

  private void Spin()
  {
      transform.Rotate(new Vector3(0, 5, 0));
  }
}