using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UserList : MonoBehaviour
{
    public int dataMargins = 100;
    public GameObject userDataPrefab, modTag, gymbroTag, laptopTag;
    public List<Material> colors;
    public List<Sprite> happyFaces, angryFaces;
    public List<string> names;

    // Awake is called before Start
    void Awake()
    {
        GameObject[] users = GameObject.FindGameObjectsWithTag("User");

        int i = 0;
        //For each user, set all the faces, and 
        foreach (GameObject user in users)
        {
            //Get the script to set vars easier
            User userScript = user.GetComponent<User>();

            //Set the name, add it to the user list, then remove the name from the list
            int nameIndex = Random.Range(0, names.Count);
            userScript.nametag.text = names[nameIndex];
            
            //Instantiate the userdata in the list and push it down some pixels
            GameObject userData = Instantiate(userDataPrefab, transform);
            userData.transform.position += Vector3.down * i * dataMargins;
            userData.GetComponentInChildren<TextMeshProUGUI>().text = names[nameIndex];
            names.RemoveAt(nameIndex);


            //Add tags to userData
            if (userScript.mod)
            {
                Instantiate(modTag, userData.transform);
            }
            if (userScript.gymbro)
            {
                Instantiate(gymbroTag, userData.transform);
            }
            if (userScript.laptopUser)
            {
                Instantiate(laptopTag, userData.transform);
            }
            i++;


            //Set the color then remove the color from the list
            int colorIndex = Random.Range(0, colors.Count);
            userScript.facebg.material = colors[colorIndex];
            colors.RemoveAt(colorIndex);

            //Set the faces then remove the faces from the list
            int faceIndex = Random.Range(0, happyFaces.Count);
            userScript.happyFace = happyFaces[faceIndex];
            userScript.angryFace = angryFaces[faceIndex];
            happyFaces.RemoveAt(faceIndex);
            angryFaces.RemoveAt(faceIndex);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
