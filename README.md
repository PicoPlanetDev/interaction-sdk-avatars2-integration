# interaction-sdk-avatars2-integration
Code modified from oculus-samples/Unity-Decomissioned

## Purpose
Provides a system to use the OVRSyntheticHand as a data source for Meta Avatars in order to allow avatar fingers to follow poses and be affected by Poke Interactables.

## Project setup
1. Have an OVRCameraRig set up in a way that already works in your project with the ghost hands. It should have an OVRInteraction prefab on it, preferably with both hand tracking hands and controller hands. Mine looks like this:
![Hierarchy screenshot](screenshots/OVRCameraRigHierarchy.png)
2. Import the Avatars package after downloading it from Meta' website or MQDH.
3. Add an AvatarSdkManagerHorizon and remove the SampleInputManager from it.
4. Add a new empty gameobject (I called mine Avatar) and add a SampleAvatarEntity to it.
5. To the same gameobject, add the Hand Tracking Input Manager from this repo. Make sure that you have the entire Avatars folder from this repo in your project, however.
6. Drop in your HMD, and select the LeftHandSynthetic and RightHandSynthetic for the Left Hand and Right Hand. It should now look like this:
![Hand Tracking Input Manager screenshot](screenshots/HandTrackingInputManager.png)
7. Drag the Hand Tracking Input Manager into the Body Tracking behavior slot in the Sample Avatar Entity Tracking Input section.
8. You could set up Face, Eye Pose, and Lip Sync behaviors yourself later on. However, you should now be able to press play and test your avatar interacting with your game.

**If it all works,** go ahead and disable the visuals for the Synthetic ghost hands so they're not z-fighting with the avatar.

**If a generic avatar appears,** make sure you have complete the Data Use Checkup for Avatars (need User ID, User Profile, and Avatars in a request), then copy your App ID into the *Oculus/Platform/Edit Settings* window. For your avatar to show up in the Unity Editor in addition to on Quest, you'll need to create an app for both Rift and Quest.