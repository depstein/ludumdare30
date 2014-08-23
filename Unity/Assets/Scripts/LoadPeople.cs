using UnityEngine;
using System.Collections;

namespace Scripts
{
    public class LoadPeople : MonoBehaviour
    {

        void Start()
        {
            Debug.Log(XmlLoading.ReadFolderOfPeople()[0]);
        }
    }
}