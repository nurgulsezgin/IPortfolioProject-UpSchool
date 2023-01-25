// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Services.Description;

namespace IPortfolioProjects161022
{
    public class HashSHA256
    {
        public static string EncryptPassword(string password)
        {
            using (SHA256 mySHA256 = SHA256.Create())
            {
                try
                {
                    // From string to byte array
                    var arr = Encoding.ASCII.GetBytes(password);
                    // Hash the password with SHA256
                    var hashValue = mySHA256.ComputeHash(arr);
                    // Convert byte array to a string   
                    StringBuilder stringbuilder = new StringBuilder();
                    for (int i = 0; i < hashValue.Length; i++)
                    {
                        stringbuilder.Append(hashValue[i].ToString("x2"));
                    }
                    int l=stringbuilder.ToString().Length;
                    return stringbuilder.ToString();

                    //var result = Convert.ToBase64String(hashValue);
                    //Console.Write(result);

                    //return (result);
                }
                catch (IOException e)
                {
                    Console.WriteLine($"I/O Exception: {e.Message}");
                    return e.Message;
                }
                catch (UnauthorizedAccessException e)
                {
                    Console.WriteLine($"Access Exception: {e.Message}");
                    return e.Message;
                }
            }
        }
    }
}
