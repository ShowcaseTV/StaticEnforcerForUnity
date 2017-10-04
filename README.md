# About

This is a Unity3D component to propagate static flag from root game object to child objects on re-import.
So that, you can safely edit 3D model files and re-import without collapsing conditions to do GI lightmap correctly.

# Why?

I'm using GI lightmapping (enlighten) with SketchUp models and I frequently met the problem that some of the inner game objects doesn't lit correctly, because these objects does't have static flag on, while the root model object have the static flag. It becomes very cumbersome when I edit the model again and again. \
This StaticEnforcer component solves that problem.

Otherwise, you need to ensure static flag almost everytime you edited and re-imported a model. Which is not that a human must do.

# Instruction

## Preparation

1. Assume you have sample-model.skp (SketchUp 2015 format) in your Unity project somewhere under Assets/.
2. Unity will automatically import sample-model.skp and generate "sample-model" prefab.
3. Place that "sample-model" prefab to a scene.
4. Set static flag to the placed "sample-model" to make GI lightmap for that model.

## Add StaticEnforcer

5. add StaticEnforcer scripts to your project
    - by git

      ```git clone https://github.com/showcase-tv/StaticEnforcerForUnity.git```

    - by file copy
      
      place scripts under \
      https://github.com/showcase-tv/StaticEnforcerForUnity/tree/master/Assets/StaticEnforcer/Scripts \
      to your Assets folder. Please keep the folder name "Editor" to work correctly.

6. Add "Static Enforcer" component to the places "sample-model" with "Add Component" button on the inspector.

## Then what happens?

If you modify sample-model.skp with SketchUp and especially add some "group"s, Unity3D will re-import the model, and generate some GameObjects each for the new groups. The generated GameObjects usually doesn't have static flag, but with Static Enforcer component attached, they will have static flag on.

## Condition to work

The game object which the StaticEnforcer attached must be an root instance of a prefab, imported from a 3D model file.

## FAQ

Q. What if the root model doesn't have static flag on?

A. the StaticEnforcer will do nothing on re-import if the root object is not static, and the behavior is the same as Unity3D default.

## in Japanese

SketchUpファイルのような3DモデルファイルをUnityプロジェクトに読み込んでいる場合で、SketchUp側で後から修正してモデル内にグループを追加した場合など、モデル内部のGameObjectにstaticフラグがつかないケースがあり、いつのまにかGIの影がきちんとつかなくなる、という現象を防止するものです。 \
使い方としては、3DモデルファイルをインポートしてSceneに配置したオブジェクトに対して、Add Component で "Static Enforcer" を追加すると利用することができます。3Dモデルファイルを修正して再importしたときに働きます。
