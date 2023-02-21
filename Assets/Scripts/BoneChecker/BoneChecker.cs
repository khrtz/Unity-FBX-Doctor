using UnityEngine;

public class BoneChecker : MonoBehaviour
{
    public bool CheckBones(GameObject root)
    {
        // Check the bone hierarchy of the given root game object.
        // Returns true if the hierarchy is correct, false otherwise.

        // Ensure that the root has a SkinnedMeshRenderer component attached.
        var skinnedMeshRenderer = root.GetComponentInChildren<SkinnedMeshRenderer>();
        if (skinnedMeshRenderer == null)
        {
            Debug.LogError("Root game object does not have a SkinnedMeshRenderer component.");
            return false;
        }

        // Check each bone in the hierarchy to ensure that it is part of the SkinnedMeshRenderer hierarchy.
        foreach (Transform bone in skinnedMeshRenderer.bones)
        {
            if (!bone.IsChildOf(skinnedMeshRenderer.rootBone))
            {
                Debug.LogError($"Bone '{bone.name}' is not part of the SkinnedMeshRenderer hierarchy.");
                return false;
            }
        }

        // Check that all bones in the Humanoid bone structure are present.
        var humanoidBones = (HumanBodyBones[])System.Enum.GetValues(typeof(HumanBodyBones));
        foreach (var humanoidBone in humanoidBones)
        {
            // Skip optional bones.
            if (IsOptionalHumanoidBone(humanoidBone)) continue;

            var boneTransform = skinnedMeshRenderer.bones[humanoidBone.GetHashCode()];
            if (boneTransform == null)
            {
                Debug.LogError($"Bone {humanoidBone} is missing from the SkinnedMeshRenderer.");
                return false;
            }

            if (boneTransform.name != humanoidBone.ToString())
            {
                Debug.LogWarning($"Bone {humanoidBone.GetHashCode()} is named '{boneTransform.name}', should be named '{humanoidBone}'.");
            }
        }

        // All checks have passed.
        return true;
    }

    private bool IsOptionalHumanoidBone(HumanBodyBones bone)
    {
        switch (bone)
        {
            case HumanBodyBones.Jaw:
            case HumanBodyBones.LeftEye:
            case HumanBodyBones.RightEye:
            case HumanBodyBones.Neck:
            case HumanBodyBones.UpperChest:
            case HumanBodyBones.LastBone:
                return true;
            default:
                return false;
        }
    }
}
