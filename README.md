# Augmented Reality with Unity3D and Vuforia

This report documents the implementation of an academic Augmented Reality (AR)
application developed in Unity3D using the Vuforia Engine. The main goal is to
build an application capable of detecting two different image targets through
the device camera and rendering a different 3D object on top of each one in
real time.

## Objective

The practice requires demonstrating a working AR application in which **two
tracking targets** are registered, each of them associated with a **different
3D object**. When the tracking algorithm detects a target in the camera feed,
the corresponding 3D model is rendered anchored to it. When the target is lost,
the model is hidden.

The specific goals are:

- Integrate the Vuforia Engine into a Unity3D project.
- Replace the default camera with the Vuforia `ARCamera` and configure the
  application license.
- Create and import a target database from the Vuforia Target Manager.
- Configure two `Image Target` objects and attach a distinct 3D model to each.
- Validate the behavior at runtime using a webcam and the target images
  displayed on a mobile device.

**Prerequisites**

- A free Vuforia developer account at
  [developer.vuforia.com](https://developer.vuforia.com/).
- A generated **License Key**.
- Vuforia Engine support enabled in the Unity installation or imported as a
  package.

## Project Setup

### 1. Project creation and Vuforia integration

1. A new Unity project was created.
2. The Vuforia Engine was added to the project.
3. The default `Main Camera` was **deleted** and replaced by the Vuforia
   `ARCamera` prefab.

### 2. License Key

A license key for the application was generated in the Vuforia web and pasted 
into the **License Key** field of the `Vuforia Behaviour` component attached to 
the `ARCamera`.

![screenshot-1.png](./screenshots/screenshot-1.png)

*Figure 1: License Manager in the Vuforia developer portal showing the license
created for this project.*

> **Security note:** the license key is a credential. It is **not** published in
> this repository and must be supplied locally in the Inspector before running
> the project.

### 3. Target database

The tracking targets were created in the Vuforia
[Target Manager](https://developer.vuforia.com/targetmanager):

1. A new **Device Database** was created.
2. Two images were uploaded as `Single Image` targets with their real width
   defined.
3. The augmentability rating of each target was reviewed in order to guarantee
   stable tracking.
4. The database was downloaded as a Unity package (`.unitypackage`) and
   imported into the project.

![screenshot-2.png](./screenshots/screenshot-2.png)

*Figure 2: Target Manager showing the database with the two registered image
targets.*

## System Architecture and Component Configuration

### Scene Hierarchy Overview

The scene is organized around the Vuforia camera and one `ImageTarget` per
tracked image. Each 3D object is a **child** of its target, so that it inherits
the target's position, rotation and scale as tracked by the algorithm.

```text
Scene
├── ARCamera                (Vuforia Behaviour, Database Load Behaviour)
├── Directional Light
├── ImageTarget1            (Image Target Behaviour)
│   └── Soldier1            (3D Asset Store object)
├── ImageTarget2            (Image Target Behaviour)
│   └── Soldier2            (3D Asset Store object)
└── Plane
```

### ARCamera

- Replaces the default `Main Camera`.
- `Vuforia Behaviour` holds the license key.
- `Database Load Behaviour` loads and activates the target database.

### Image Targets

Each `ImageTarget` instance contains an `Image Target Behaviour` component
configured as follows:

- **Type:** Predefined (from the imported database).
- **Database:** `Unity-p06`.
- **Image Target:** the specific target of the database assigned to that
  instance.

## System Testing

The application was tested in Play Mode using a webcam`.
The two target images were displayed on a mobile phone screen and shown to the
camera. The following behaviors were verified:

- [x] Target 1 is detected and its 3D object is rendered over it.
- [x] Target 2 is detected and its 3D object is rendered over it.
- [x] Each target renders **only its own** object.
- [x] The objects follow the target when it is moved or rotated.
- [x] The objects disappear when the target leaves the camera view.

## Demo Video

A video showing the final result of the application is available here:

> **![gif-1.gif](./gifs/gif-1.gif)**

## Other Information

This code was developed by
* [Cristhian Adoney Cruz Delgado](https://github.com/CristhianCruzDelgado)

Contact emails
* <alu0101648293@ull.edu.es>

This code was designed for Intelligent Interfaces, \
signature of the Computer Engineering degree, \
that is studied at the Universidad de La Laguna.

_13 November 2026_
