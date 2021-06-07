# changeFaceVideo
Simple face swapping demo utilizing mp4 videos with Unity, AR Foundation, and echoAR

## Register
Don't have an API key? Make sure to register for FREE at [echoAR](https://console.echoar.xyz/#/auth/register).

## Setup
* Create a new Unity project.
* Clone the current repository sample code.
* Open the 'faceSwap' sample scene under `changeFaceVideo\Assets\Scenes`.
* [Set the API key](https://docs.echoar.xyz/unity/using-the-sdk) in the `echoAR.cs` script inside the `echoAR\echoAR.prefab` using the the Inspector.
* [Add the videos](https://docs.echoar.xyz/quickstart/add-a-3d-model) from the [videos](/Assets/Videos) folder to the console.
* [Add all the metadata](https://docs.echoar.xyz/web-console/manage-pages/data-page/how-to-add-data#adding-metadata) listed in the [metadata](/Assets/metadata) folder.

## Use own videos

Create your own csv file per video and follow the same format as the metadata provided for this demo.

Edit buttonHandler.cs script under echoAR gameobject and make sure to add the 'name' property in your .csv file into the string array 'videos'

## Build & Run
* [Build and run the AR application](https://docs.echoar.xyz/unity/adding-ar-capabilities#4-build-and-run-the-ar-application). Verify that the `Assets\Scenes\faceSwap` scene is ticked in the `Scenes in Build` list and click `Build And Run`.

## Instructions

Switch face mesh video through UI arrow buttons on the bottom of the screen.

Switch face mesh video through leaving the screen and re-entering the screen or covering your face and uncovering your face.

## Learn more
Refer to our [documentation](https://docs.echoar.xyz/unity/) to learn more about how to use Unity and echoAR.

## Support
Feel free to reach out at [support@echoAR.xyz](mailto:support@echoAR.xyz) or join our [support channel on Slack](https://join.slack.com/t/echoar/shared_invite/enQtNTg4NjI5NjM3OTc1LWU1M2M2MTNlNTM3NGY1YTUxYmY3ZDNjNTc3YjA5M2QyNGZiOTgzMjVmZWZmZmFjNGJjYTcxZjhhNzk3YjNhNjE). 

## Screenshots
Demo

![demo](https://user-images.githubusercontent.com/85501187/121060683-f97f0000-c790-11eb-9122-40bb0bf0a014.gif)

Videos
![models](https://user-images.githubusercontent.com/85501187/121057692-8a53dc80-c78d-11eb-8e87-982a5307d2b3.JPG)

Metadata
![metadata](https://user-images.githubusercontent.com/85501187/121057656-7c9e5700-c78d-11eb-8dac-b3bac4d7826f.JPG)

Demo created by [Allen Zhang](https://github.com/allenZhangPersonal)
