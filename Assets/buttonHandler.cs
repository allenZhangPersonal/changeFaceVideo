using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class buttonHandler : MonoBehaviour
{
    public int counter = 0; // Position of string list
    public string[] videos = {"star", "earth","letter"}; // Video names
    ARFaceManager faceManager; // AR face manager
    public int numFacesTracked = 0; // Reports number of "updated" faces in our session
    private bool startVid = false; // For initial positive edge trigger (we ignore first edge)
    void Start()
    {
        faceManager = FindObjectOfType<ARFaceManager>(); 
        faceManager.facesChanged += handleFacesChanged; // Add event handler
    }
    void handleFacesChanged(ARFacesChangedEventArgs facesChanged){ // Event handler
        if (numFacesTracked < facesChanged.updated.Count){ // If positive edge
            if(startVid){
                incCounter();
            }
            else{
                startVid = true;
            }
        }
        numFacesTracked = facesChanged.updated.Count; // set for new faces
    }
    public void incCounter(){ // Increments video counter
        counter = counter + 1;
        if (counter > videos.Length - 1){
            counter = 0;
        }
        Handheld.Vibrate();
    }
    public void decCounter(){ // Decrements video counter
        counter = counter - 1;
        if (counter < 0){
            counter = videos.Length - 1;
        }
        Handheld.Vibrate();
    }
}
