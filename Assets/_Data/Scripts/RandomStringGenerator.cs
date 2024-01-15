using UnityEngine;

public class RandomStringGenerator : MonoBehaviour
{
    public static string Generate(int length)
    {
        const string characters = "abcdefghijklmnopqrstuvwxyz0123456789";
        System.Random random = new System.Random();

        char[] randomString = new char[length];
        for (int i = 0; i < length; i++)
        {
            randomString[i] = characters[random.Next(characters.Length)];
        }

        return new string(randomString);
    }
}