using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerCube : MonoBehaviour
{
    private int numFrames = 0;
    private int period = 200;
    private float amplitudeScale = 0.05f;
    private Vector3 rotationAxis;
    private float rotationSpeed = 0.8f;

    public Material beforeMaterial;
    public Material afterMaterial;

    // Start is called before the first frame update
    void Start()
    {
        rotationAxis = new Vector3(Random.Range(0f, 2 * Mathf.PI), Random.Range(0f, 2 * Mathf.PI), Random.Range(0f, 2 * Mathf.PI));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        numFrames = (numFrames + 1) % period;
        transform.Translate(0f, amplitudeScale * Mathf.Sin(numFrames * 2 * Mathf.PI / period), 0f, Space.World);
        transform.Rotate(rotationAxis, rotationSpeed);
    }

    public void ChangeMaterial()
    {
        gameObject.GetComponent<Renderer>().material = afterMaterial;
    }
}
