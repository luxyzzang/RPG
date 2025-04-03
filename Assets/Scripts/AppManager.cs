using UnityEngine;

public class AppManager : MonoBehaviour
{
    public GameObject cube;
    public GameObject gameLight;
    public MeshRenderer ground;

    private void Start()
    {
        Rigidbody cubeRigid = cube.GetComponent<Rigidbody>();
        Light light = gameLight.GetComponent<Light>();

        light.color = Color.cyan;
        ground.material.color = Color.gray;
    }

    public void CubeOn()
    {
        cube.SetActive(true);
    }

    public void CubeOff()
    {
        cube.SetActive(false);
    }
    
    public void ChangeCubeColor()
    {
        MeshRenderer mesh = cube.GetComponent<MeshRenderer>();
        mesh.material.color = new Color(Random.Range(0, 256) / 255f, Random.Range(0, 256) / 255f, Random.Range(0, 256) / 255f);
    }

    public void ChangeGroundColor()
    {
        ground.material.color = new Color(Random.Range(0, 256) / 255f, Random.Range(0, 256) / 255f, Random.Range(0, 256) / 255f);
    }
}