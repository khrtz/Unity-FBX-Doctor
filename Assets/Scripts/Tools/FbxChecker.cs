using UnityEditor;
using UnityEngine;

public static class FbxMenu
{
    [MenuItem("Assets/FBX Checker/Check Bones")]
    private static void CheckBones()
    {
        var selected = Selection.activeObject;
        if (selected != null && selected is GameObject)
        {
            var go = selected as GameObject;
            var boneChecker = new BoneChecker();
            if (boneChecker.CheckBones(go))
            {
                Debug.Log("Bone hierarchy is correct.");
            }
        }
    }

    // [MenuItem("Assets/FBX Checker/Check Skinning")]
    // private static void CheckSkinning()
    // {
    //     var selected = Selection.activeObject;
    //     if (selected != null && selected is GameObject)
    //     {
    //         var go = selected as GameObject;
    //         var skinningChecker = new SkinningChecker();
    //         if (skinningChecker.CheckSkinning(go))
    //         {
    //             Debug.Log("Skinning is correct.");
    //         }
    //     }
    // }
    //
    // [MenuItem("Assets/FBX Checker/Check Animation")]
    // private static void CheckAnimation()
    // {
    //     var selected = Selection.activeObject;
    //     if (selected != null && selected is AnimationClip)
    //     {
    //         var clip = selected as AnimationClip;
    //         var animationChecker = new AnimationChecker();
    //         if (animationChecker.CheckAnimation(clip))
    //         {
    //             Debug.Log("Animation is correct.");
    //         }
    //     }
    // }
    //
    // [MenuItem("Assets/FBX Checker/Check Model")]
    // private static void CheckModel()
    // {
    //     var selected = Selection.activeObject;
    //     if (selected != null && selected is GameObject)
    //     {
    //         var go = selected as GameObject;
    //         var modelChecker = new ModelChecker();
    //         modelChecker.CheckModel(go);
    //     }
    // }
}