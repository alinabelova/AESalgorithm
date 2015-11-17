using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AES3
{
    class Program
    {
        static void Main(string[] args)
        {
            FileInfo fileKey = new FileInfo(args[0]);
            FileInfo fileMessage = new FileInfo(args[1]);
            BinaryWriter chiperStream = new BinaryWriter(File.Open(args[2], FileMode.Create));
            byte[] messageByte = null;
            byte[] keyByte = null;

            switch (args[3])
            {
                case "0":
                {
                    try
                    {
                        //ЧТЕНИЕ
                        BinaryReader keyStream = new BinaryReader(File.Open(args[0], FileMode.Open));
                        keyByte = new byte[(int)fileKey.Length];
                        keyStream.Read(keyByte, 0, (int)fileKey.Length);

                        BinaryReader messageStream = new BinaryReader(File.Open(args[1], FileMode.Open));
                        messageByte = new byte[(int)fileMessage.Length];
                        messageStream.Read(messageByte, 0, (int)fileMessage.Length);
                    }
                    catch (Exception e)
                    {
                        Console.Clear();
                        Console.WriteLine("Error of reading files\n: {0}", e.Message);
                    }
                    //ШИФРОВАНИЕ
                    if (messageByte != null && keyByte != null)
                    {
                        var chiperByte = MyAES.encrypt(messageByte, keyByte);
                        chiperStream.Write(chiperByte);
                        Console.WriteLine("File was encrypted successfull!");
                    }
                    break;
                }
                case "1":
                {
                    try
                    {
                        //ЧТЕНИЕ
                        BinaryReader keyStream = new BinaryReader(File.Open(args[0], FileMode.Open));
                        keyByte = new byte[(int) fileKey.Length];
                        keyStream.Read(keyByte, 0, (int) fileKey.Length);

                        BinaryReader messageStream = new BinaryReader(File.Open(args[1], FileMode.Open));
                        messageByte = new byte[(int) fileMessage.Length];
                        messageStream.Read(messageByte, 0, (int) fileMessage.Length);
                    }
                    catch (Exception e)
                    {
                        Console.Clear();
                        Console.WriteLine("Error of reading files\n: {0}", e.Message);
                    }
                    //ДЕШИФРОВАНИЕ
                    if (messageByte != null && keyByte != null)
                    {
                        var chiperByte = MyAES.decrypt(messageByte, keyByte);
                        chiperStream.Write(chiperByte);
                        Console.WriteLine("File was decrypted successfull!");
                    }
                    break;
                }
            }
        }
    }
}
