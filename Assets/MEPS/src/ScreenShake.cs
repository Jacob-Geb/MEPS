
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public float intensity;
    public float falloffSpeed;

    private float speed = 20;

    private float _x;
    private float _y;
    private float _z;

    private void Start()
    {
        _z = transform.position.z;
    }

    private void Update()
    {
        intensity = Mathf.Clamp01(intensity - Time.deltaTime * falloffSpeed);

        if (intensity > 0){
            _x += Time.deltaTime * speed;
            _y += Time.deltaTime * speed;
            var x = (Mathf.PerlinNoise(_x, 0) - 0.5f)  * (intensity * intensity);
            var y = (Mathf.PerlinNoise(0, _y) - 0.5f)  * intensity * intensity;
            transform.position = new Vector3(x, y, _z);
        }
        else{
            transform.position = new Vector3(0, 0, _z);
        }
    }

    public void Bump(float val){
        intensity = Mathf.Clamp01(intensity + val);
    }

    public void Reset(){
        intensity = 0;
    }
}
