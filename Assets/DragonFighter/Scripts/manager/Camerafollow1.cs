// Converted from UnityScript to C# at http://www.M2H.nl/files/js_to_c.php - by Mike Hergaarden
using UnityEngine;
using System.Collections;



    public class Camerafollow1 : MonoBehaviour
    {

        public Transform Target;
        public float Distance;
        public float Height;
        public float HeightDamping;

        void LateUpdate()
        {
        
            float wantedHeight = Target.position.y + Height;
            float currentHeight = transform.position.y;
            currentHeight = Mathf.Lerp(currentHeight, wantedHeight, HeightDamping * Time.deltaTime);
            Vector3 pos = Target.position;
            pos.y = currentHeight;
            pos.z -= Distance;

            transform.position = pos;
        }
    
}