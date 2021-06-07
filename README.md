# changeFaceVideo
Simple face swapping demo utilizing mp4 videos with Unity, AR Foundation, and echoAR

## Register
Don't have an API key? Make sure to register for FREE at [echoAR](https://console.echoar.xyz/#/auth/register).

## Setup
* Create a new Unity project.
* Clone the current repository sample code.
* Open the 'faceSwap' sample scene under `changeFaceVideo\Assets\Scenes`.
* [Set the API key](https://docs.echoar.xyz/unity/using-the-sdk) in the `echoAR.cs` script inside the `echoAR\echoAR.prefab` using the the Inspector.
* [Add the 3D model](https://docs.echoar.xyz/quickstart/add-a-3d-model) from the [models](https://github.com/echoARxyz/Unity-ARFoundation-echoAR-demo-Face-Tracking/tree/master/models) folder to the console.
* [Add the metadata](https://docs.echoar.xyz/web-console/manage-pages/data-page/how-to-add-data#adding-metadata) listed in the [metadata.csv](https://github.com/echoARxyz/Unity-ARFoundation-echoAR-demo-Face-Tracking/blob/master/metadata.csv) file.
* Overwrite the existing _echoAR/RemoteTransformations.cs_ script with the new [_RemoteTransformations.cs_](https://github.com/echoARxyz/Unity-ARFoundation-echoAR-demo-Face-Tracking/blob/master/RemoteTransformations.cs) file.
