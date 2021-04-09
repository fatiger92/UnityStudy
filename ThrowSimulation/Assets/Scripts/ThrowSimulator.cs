using UnityEngine;

using System.Collections;
using UnityEngine.UI;

public class ThrowSimulator : MonoBehaviour
{
    private float tx;
    private float ty;
    private float tz;
    public float g = 9.8f;
    private float elapsed_time;
    public float max_height;
    private float t;

    public Transform endPoint;
    public Transform heightGo;

    public Button btn;

    private float dat;  //도착점 도달 시간 

    private void Start()
    {
        btn.onClick.AddListener(() => Shoot());
    }

    public void Shoot()
    {
        Vector3 startPos =  new Vector3(transform.position.x, transform.position.y, transform.position.z);
        startPos = transform.position;

        var dh = endPoint.position.y - startPos.y;
        var mh = max_height - startPos.y;
        ty = Mathf.Sqrt(2 * this.g * mh);

        float a = this.g;
        float b = -2 * ty;
        float c = 2 * dh;

        dat = (-b + Mathf.Sqrt(b * b - 4 * a * c)) / (2 * a);
        tx = -(startPos.x - endPoint.position.x - 10f) / dat;
        tz = -(startPos.z - endPoint.position.z - 10f) / dat;

        this.elapsed_time = 0;

        StartCoroutine(ShootImpl(startPos));
    }
    IEnumerator ShootImpl(Vector3 start)
    {
        while (true)
        {
            this.elapsed_time += Time.deltaTime;
            var tx = start.x + this.tx * elapsed_time;
            var ty = start.y + this.ty * elapsed_time - 0.5f * g * elapsed_time * elapsed_time;
            var tz = start.z + this.tz * elapsed_time;

            var tpos = new Vector3(tx, ty, tz);
            transform.LookAt(tpos);
            transform.position = tpos;

            if (this.elapsed_time >= this.dat)
                break;

            yield return null;
        }
    }

}