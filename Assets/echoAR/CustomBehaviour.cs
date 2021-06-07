/**************************************************************************
* Copyright (C) echoAR, Inc. 2018-2020.                                   *
* echoAR, Inc. proprietary and confidential.                              *
*                                                                         *
* Use subject to the terms of the Terms of Service available at           *
* https://www.echoar.xyz/terms, or another agreement                      *
* between echoAR, Inc. and you, your company or other organization.       *
***************************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using TMPro;

public class CustomBehaviour : MonoBehaviour
{
    [HideInInspector]
    public Entry entry;
    private string[] videos; // Video Names
    public TextMeshProUGUI faceCount; // Text for displaying number of faces detected
    public TextMeshProUGUI videoName; // Text for displaying number of faces detected
    public MeshRenderer currRend; // Current mesh renderer
    public GameObject echoAR; // echoAR object
    public buttonHandler btnHandle; // Button handler class (script)
    public int counter = 0; // Counter to determine video
    ARFaceManager faceManager; // Face manager for registering events
    private bool updateVideo = false; // Boolean to control change of video mesh
    /// <summary>
    /// EXAMPLE BEHAVIOUR
    /// Queries the database and names the object based on the result.
    /// </summary>

    // Use this for initialization
    void Start()
    {
        // Add RemoteTransformations script to object and set its entry
        this.gameObject.AddComponent<RemoteTransformations>().entry = entry;

        // Qurey additional data to get the name
        string value = "";
        if (entry.getAdditionalData() != null && entry.getAdditionalData().TryGetValue("name", out value))
        {
            // Set name
            this.gameObject.name = value;
        }
        ///// Add custom stuff below
        // Get echoAR game object and the handler script
        echoAR = GameObject.Find("echoAR");
        btnHandle = echoAR.GetComponent<buttonHandler>();
        videos = btnHandle.videos;
        // Get text mesh to set its value
        faceCount = GameObject.Find("faceCount").GetComponent<TextMeshProUGUI>();
        videoName = GameObject.Find("videoName").GetComponent<TextMeshProUGUI>();

        // Current mesh renderer
        currRend = this.GetComponent<MeshRenderer>();

        // Get AR face mananger and its prefab
        GameObject prefab;
        faceManager = FindObjectOfType<ARFaceManager>();
        prefab = faceManager.facePrefab;

        // Get prefab mesh renderer, material, and texture
        MeshRenderer prefabRenderer = prefab.GetComponent<MeshRenderer>();
        Material prefabMaterial = prefabRenderer.sharedMaterial;
        Texture texture = prefabMaterial.mainTexture;


        // Current video player, initialize all material, texture to null
        var vidPlayer = this.GetComponent<UnityEngine.Video.VideoPlayer>();
        currRend.material = prefabMaterial;
        currRend.material.mainTexture = texture;
        vidPlayer.renderMode = UnityEngine.Video.VideoRenderMode.RenderTexture; // Set render mode
        if (this.gameObject.name == videos[counter]){
            vidPlayer.targetTexture = (UnityEngine.RenderTexture) texture; // Casting from texture to RenderTexture
            vidPlayer.Play();
            videoName.text = "Current video name: " + this.gameObject.name;
        }
        else{
            vidPlayer.Stop(); // All other videos stopped at 0
            vidPlayer.targetTexture = null; 
        }
        // Display information
        faceCount.text = "Current number of faces: " + btnHandle.numFacesTracked.ToString();
    }
// Update is called once per frame
    void Update()
    {
        // Get echoAR game object and the handler script
        echoAR = GameObject.Find("echoAR");
        btnHandle = echoAR.GetComponent<buttonHandler>();
        if(counter != btnHandle.counter){
            updateVideo = true;
        }
        else{
            updateVideo = false;
        }
        // Get AR face mananger and its prefab
        GameObject prefab;
        faceManager = FindObjectOfType<ARFaceManager>();
        prefab = faceManager.facePrefab;

        // Get prefab mesh renderer, material, and texture
        MeshRenderer prefabRenderer = prefab.GetComponent<MeshRenderer>();
        Material prefabMaterial = prefabRenderer.sharedMaterial;
        Texture texture = prefabMaterial.mainTexture;
        var vidPlayer = this.GetComponent<UnityEngine.Video.VideoPlayer>();
        if (updateVideo){ // Only update when counter changed
            if(this.gameObject.name == videos[counter]){ // Old video
                // Other video stop and reset material, texture to null
                vidPlayer.Stop();
                vidPlayer.targetTexture = null; 
            }
            if (this.gameObject.name == videos[btnHandle.counter]){ // New Video
                vidPlayer.targetTexture = (UnityEngine.RenderTexture) texture; // Casting from texture to RenderTexture
                vidPlayer.Play();
                videoName.text = "Current video name: " + this.gameObject.name;
            }
            counter = btnHandle.counter; // Update counter
        }
        // Display information
        faceCount.text = "Current number of faces: " + btnHandle.numFacesTracked.ToString();
    }
}