using UnityEngine;
using System.Collections;

public class RocketController : MonoBehaviour
{

    public GameObject bulletPrefab;
	public float speed;

	void Update()
    {
		if (Input.touchCount > 0)
		{
			Touch touch = Input.GetTouch(0);
			if (touch.phase == TouchPhase.Began)
			{
				Instantiate(bulletPrefab, transform.position, Quaternion.identity);
			}
			Vector2 direction = new Vector2(0, 0);

			if (Input.touchCount > 0)
			{
				float x = touch.deltaPosition.x;

				//　移動する向きを求める
				direction = new Vector2(x, 0).normalized;
			}
			Move(direction, speed);
		}
		/*
		if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-0.1f, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(0.1f, 0, 0);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }*/
    }
	void Move(Vector2 direction, float speed)
	{
		// プレイヤーの座標の取得と移動量
		Vector2 pos = transform.position;
		pos += direction * speed * Time.deltaTime;

		// プレイヤーの新規位置とする
		transform.position = pos;
	}

}