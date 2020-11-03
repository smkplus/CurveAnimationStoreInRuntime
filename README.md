# CurveAnimationStoreInRuntime
![Unity 2019.4+](https://img.shields.io/badge/unity-unity%202019.4%2B-blue)
![License: MIT](https://img.shields.io/badge/License-MIT-brightgreen.svg)

## Installation
first you should install the
[NaughtyAttributes](https://github.com/dbrizov/NaughtyAttributes)

then you can record and play animation

![Record_2020_11_03_10_09_16_774](https://user-images.githubusercontent.com/16706911/97955979-c0c31680-1dbc-11eb-8013-2d80a9f82aa5.gif)


## How it works?

You can create class that has AnimationCurve field and inherits from ScriptableObject with will allow you to save curve as asset file, or you can add [SerializeField] attribute to you AnimationCurve so your changes to curve won't be discarded after script compilation.

![2020-11-03_10-20-39](https://user-images.githubusercontent.com/16706911/97958228-09310300-1dc2-11eb-9721-cc3e5f0f7a47.jpg)

