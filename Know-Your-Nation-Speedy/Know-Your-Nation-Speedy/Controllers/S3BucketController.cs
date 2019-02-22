using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Know_Your_Nation_Speedy.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using System.Collections.Specialized;
using System.Configuration;
using System.IO;
using Microsoft.AspNetCore.Http;
using System.Runtime.Serialization.Formatters.Binary;

namespace Know_Your_Nation_Speedy.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class S3BucketController
    {
        //TODO setup web.config file
        const string key = "AKIAJF4XWGB5X62FIZNA";
        const string secret = "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";
        const string bucketName = "fucit";
        
        [HttpPost("CreateContent")]
        public async Task SaveToBucket(IFormCollection form)
        {
            try
            {
                foreach (var file in form.Files)
                {
                    //IFormFile file
                    if (file == null || file.Length == 0)
                        throw new Exception("File is empty!");
                    byte[] fileArray;

                    var filePathKey = $"Characters/{file.FileName}";

                    using (var s3Client = new AmazonS3Client(key,
                        secret, RegionEndpoint.EUWest1))
                    {
                        var request = new PutObjectRequest()
                        {
                            BucketName = bucketName,
                            Key = filePathKey,
                            CannedACL = S3CannedACL.PublicRead,
                        };

                        using (var stream = file.OpenReadStream())
                        using (var memoryStream = new MemoryStream())
                        {
                            stream.CopyTo(memoryStream);
                            fileArray = memoryStream.ToArray();
                        }

                        MemoryStream memStream = new MemoryStream();

                        BinaryFormatter binForm = new BinaryFormatter();
                        memStream.Write(fileArray, 0, fileArray.Length);
                        memStream.Seek(0, SeekOrigin.Begin);

                        request.InputStream = memStream;
                        var result = await s3Client.PutObjectAsync(request);

                    }
                }
            }
            catch (Exception ex)
            {
            }
        }

        [HttpGet]
        [Route("GetContent")]
        public async Task GetContent()
        {
            string key = "";
            string bucketName = "fucit";

            // Prepare key
            //var user = GetUser();
            var filename = $"Speedy_Char_v1.png";
            // Need better way to determine extension
            key = $"Characters/{filename}";

            using (var s3Client = new AmazonS3Client(key,
                secret, RegionEndpoint.EUWest1))
            {
                var result = await s3Client.GetObjectAsync(bucketName, key);

                //TODO GetContent to see file on front end.
                //    S3FileInfo s3FileInfo = new S3FileInfo(s3Client, bucketName, key);
                //    if (s3FileInfo.Exists)
                //    {
                //        // file exists
                //        return Ok(new
                //        {
                //            AvatarUrl = S3Util.CreateObjectUri("s3-eu-west-1", bucketName, key),
                //        });
                //    }
            }
        }
    }
}
