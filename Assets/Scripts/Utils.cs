using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CommonUtilities
{
    public static class Utils
    {
        public static Vector3Int ConvertToVector3Int(this Vector3 vector3)
        {
            Vector3Int vector3Int = new Vector3Int();
            vector3Int.x = Mathf.RoundToInt(vector3.x);
            vector3Int.y = Mathf.RoundToInt(vector3.y);
            vector3Int.z = Mathf.RoundToInt(vector3.z);

            return vector3Int;
        }
        
        public static void SetAlpha(this SpriteRenderer spriteRenderer, float alpha)
        {
            Color color = spriteRenderer.color;
            color.a = alpha;
            spriteRenderer.color = color;
        }

        public static void SetAlpha(this UnityEngine.UI.Graphic graphic, float alpha)
        {
            Color color = graphic.color;
            color.a = alpha;
            graphic.color = color;
        }

        public static void ResetTransform(this Transform transform)
        {
            transform.position = Vector3.zero;
            transform.rotation = Quaternion.identity;
            transform.localScale = Vector3.one; ;
        }

        public static void StopPhysicsObject(this Rigidbody rigidbody)
        {
            rigidbody.velocity = Vector3.zero;
            rigidbody.angularVelocity = Vector3.zero;
        }

        public static float Map(float current1, float current2, float target1, float target2, float val)
        {
            //third parameter is the interpolant between the current range which, in turn, is used in the linear interpolation of the target range. 
            return Mathf.LerpUnclamped(target1, target2, Mathf.InverseLerp(current1, current2, val));
        }

        public static Coroutine Execute(this MonoBehaviour monoBehaviour, Action action, float time, bool realtime = false)
        {
            return monoBehaviour.StartCoroutine(DelayedAction(action, time, realtime));
        }

        static IEnumerator DelayedAction(Action action, float time, bool realtime)
        {
            if (realtime)
                yield return new WaitForSecondsRealtime(time);
            else
                yield return new WaitForSeconds(time);

            action();
        }

        #region VECTOR
        public static Vector2 SetX(this Vector2 vector, float x) => new Vector2(x, vector.y);
    
        public static Vector2 SetY(this Vector2 vector, float y) => new Vector2(vector.x, y);
        
        public static Vector2 AddX(this Vector2 vector, float x) => new Vector2(vector.x + x, vector.y);
        
        public static Vector2 AddY(this Vector2 vector, float y) => new Vector2(vector.x, vector.y + y);

        public static Vector3 SetX(this Vector3 vector, float x) => new Vector3(x, vector.y, vector.z);
        
        public static Vector3 SetY(this Vector3 vector, float y) => new Vector3(vector.x, y, vector.z);
        
        public static Vector3 SetZ(this Vector3 vector, float z) => new Vector3(vector.x, vector.y, z);
        
        public static Vector3 AddX(this Vector3 vector, float x) => new Vector3(vector.x + x, vector.y, vector.z);

        public static Vector3 AddY(this Vector3 vector, float y) => new Vector3(vector.x, vector.y + y, vector.z);
        
        public static Vector3 AddZ(this Vector3 vector, float z) => new Vector3(vector.x, vector.y, vector.z + z);
        #endregion

        
    }
}