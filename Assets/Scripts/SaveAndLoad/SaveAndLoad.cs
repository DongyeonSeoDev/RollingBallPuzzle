using UnityEngine;
using System.IO;
using System.Security.Cryptography;
using System;
using System.Text;

public class GameData
{
    public string version;

    public bool isTutorialPlay;
    public bool[] stagePlay;
    public bool[] addBallStagePlay;
    public bool[] selectBall;

    public static explicit operator GameManager(GameData data)
    {
        GameManager gameManager = GameManager.Instance;

        gameManager.isTutorialPlay = data.isTutorialPlay;
        gameManager.stagePlay = data.stagePlay;
        gameManager.addBallStagePlay = data.addBallStagePlay;
        gameManager.selectBall = data.selectBall;

        return gameManager;
    }

    public static explicit operator GameData(GameManager gameManager)
    {
        return new GameData()
        {
            version = "",
            isTutorialPlay = gameManager.isTutorialPlay,
            stagePlay = gameManager.stagePlay,
            addBallStagePlay = gameManager.addBallStagePlay,
            selectBall = gameManager.selectBall
        };
    }
}

public static class SaveAndLoad
{
    private static Rijndael myRijndael;

    private static string version = "1.0.0";
    private static string key = "key";
    private static string iv = "iv";

    private static bool isInitSaveAndLoad = false;

    private readonly static string fileName = "Save";
    private readonly static string filePath = Path.Combine(Application.persistentDataPath, fileName);

    public static void InitSaveAndLoad()
    {
        try
        {
            if (isInitSaveAndLoad)
            {
                return;
            }

            isInitSaveAndLoad = true;

            myRijndael = Rijndael.Create();

            myRijndael.Mode = CipherMode.CBC;
            myRijndael.Padding = PaddingMode.PKCS7;
            myRijndael.KeySize = 128;
            myRijndael.BlockSize = 128;

            myRijndael.Key = SetKeyOrIV(key);
            myRijndael.IV = SetKeyOrIV(iv);
        }
        catch (Exception e)
        {
            return;
        }
    }

    private static byte[] SetKeyOrIV(string keyOrIv)
    {
        byte[] value = Encoding.UTF8.GetBytes(keyOrIv);
        byte[] bytes = new byte[16];

        int length = value.Length;

        if (length > bytes.Length)
        {
            length = bytes.Length;
        }

        Array.Copy(value, bytes, length);

        return bytes;
    }
    
    public static void Save(GameData data)
    {
        try
        {
            if (!isInitSaveAndLoad)
            {
                return;
            }

            data.version = version;

            string jsonData = JsonUtility.ToJson(data);
            byte[] encryptedSavegame = Encrypt(jsonData, myRijndael.Key, myRijndael.IV);

            File.WriteAllBytes(filePath, encryptedSavegame);
        }
        catch (Exception e)
        {
            return;
        }
    }

    public static GameData Load()
    {
        try
        {
            if (File.Exists(filePath) && isInitSaveAndLoad)
            {
                byte[] decryptedSavegame = File.ReadAllBytes(filePath);
                string jsonString = Decrypt(decryptedSavegame, myRijndael.Key, myRijndael.IV);

                GameData saveData = JsonUtility.FromJson<GameData>(jsonString);

                if (saveData.version == version)
                {
                    return saveData;
                }

                return DefaultValue();
            }

            return DefaultValue();
        }
        catch (Exception e)
        {
            return DefaultValue();
        }
    }

    private static GameData DefaultValue()
    {
        bool[] defaultStagePlay = new bool[12];

        defaultStagePlay[0] = true;

        for (int i = 1; i < 12; i++)
        {
            defaultStagePlay[i] = false;
        }

        bool[] defaultAddBallStagePlay = new bool[5];

        defaultAddBallStagePlay[0] = true;

        for (int i = 1; i < 5; i++)
        {
            defaultAddBallStagePlay[i] = false;
        }

        bool[] defaultSelectBall = new bool[7];

        defaultSelectBall[0] = true;
        defaultSelectBall[1] = true;

        for (int i = 2; i < 7; i++)
        {
            defaultSelectBall[i] = false;
        }

        return new GameData()
        {
            version = SaveAndLoad.version,
            isTutorialPlay = false,
            stagePlay = defaultStagePlay,
            addBallStagePlay = defaultAddBallStagePlay,
            selectBall = defaultSelectBall
        };
    }

    private static byte[] Encrypt(string message, byte[] Key, byte[] IV)
    {
        RijndaelManaged rijndaelCipher = new RijndaelManaged();
        byte[] text = Encoding.UTF8.GetBytes(message);

        rijndaelCipher.Mode = CipherMode.CBC;
        rijndaelCipher.Padding = PaddingMode.PKCS7;
        rijndaelCipher.KeySize = 128;
        rijndaelCipher.BlockSize = 128;

        rijndaelCipher.Key = Key;
        rijndaelCipher.IV = IV;

        ICryptoTransform cryptoTransform = rijndaelCipher.CreateEncryptor();

        return cryptoTransform.TransformFinalBlock(text, 0, text.Length);
    }

    private static string Decrypt(byte[] message, byte[] Key, byte[] IV)
    {
        RijndaelManaged rijndaelCipher = new RijndaelManaged();

        rijndaelCipher.Mode = CipherMode.CBC;
        rijndaelCipher.Padding = PaddingMode.PKCS7;
        rijndaelCipher.KeySize = 128;
        rijndaelCipher.BlockSize = 128;

        rijndaelCipher.Key = Key;
        rijndaelCipher.IV = IV;

        byte[] text = rijndaelCipher.CreateDecryptor().TransformFinalBlock(message, 0, message.Length);

        return Encoding.UTF8.GetString(text);
    }
}