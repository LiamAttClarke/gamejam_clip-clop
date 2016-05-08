using UnityEngine;
using System.Collections;

public class Backdrop : MonoBehaviour {

    public SpriteRenderer[] parallaxLayers;
    public float[] parallaxLayerSpeeds;

    Transform tran;
    Transform targetCam;
    Vector3 prevPosition;

    void Awake() {
        tran = transform;
        prevPosition = tran.position;
        if (parallaxLayers == null || parallaxLayers.Length == 0)
            Debug.LogWarning("0 background layers");
        if (parallaxLayerSpeeds.Length != parallaxLayers.Length)
            throw new UnityException("Parallax Layer Speeds must be equal to Parallax Layers length");
    }

    void Start() {
        targetCam = Camera.main.transform;
        if (targetCam == null)
            throw new UnityException("Missing main camera");
    }

    void Update() {
        // update position based on main camera
        tran.position = new Vector3(targetCam.position.x, targetCam.position.y, tran.position.z);

        float deltaPosX = (tran.position - prevPosition).x;
        // update parallax layers
        for (int i = 0; i < parallaxLayers.Length; i++) {
            SpriteRenderer layer = parallaxLayers[i];
            float layerSpeed = parallaxLayerSpeeds[i];
            layer.transform.position = new Vector3(tran.position.x + layerSpeed * deltaPosX, layer.transform.position.y, layer.transform.position.z);
        }
    }

}
