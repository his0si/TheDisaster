using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SunAndMoon : MonoBehaviour
{
    public RectTransform center;
    public float radius;
    public float speed;

    private float angle = 0;

    // Update is called once per frame
    void Update()
    {
        angle += speed * Time.deltaTime;
        transform.GetComponent<RectTransform>().position = center.position + new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0) * radius;
    }
}
