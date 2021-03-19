﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Script.Serialization;

namespace CRUD_Operations
{
    /// <summary>
    /// Summary description for ImageUploader
    /// </summary>
    public class ImageUploader : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            try
            {
                //Check if Request is to Upload the File.
                if (context.Request.Files.Count > 0)
                {
                    //Fetch the Uploaded File.
                    HttpPostedFile postedFile = context.Request.Files[0];
                    string ext = postedFile.FileName.Substring(postedFile.FileName.LastIndexOf('.'),postedFile.FileName.Length- postedFile.FileName.LastIndexOf('.'));

                    //Set the Folder Path.
                    string folderPath = context.Server.MapPath("~/Images/");

<<<<<<< HEAD
                    var allowedFileType = new[] { ".jpg", ".jpeg", ".png", ".svg" };
                    if (!allowedFileType.Contains(ext))
                        return;

=======
>>>>>>> 96e2014b8f507590f83957c7bec7940ceb4ac00c
                    //Setting file name
                    Guid fileName = Guid.NewGuid();

                    //Save the File in Folder.
                    postedFile.SaveAs(folderPath + fileName.ToString()+ext);

                    //Send File details in a JSON Response.
                    string json = new JavaScriptSerializer().Serialize(
                        new
                        {
                            name = fileName.ToString()+ext
                        });
                    context.Response.StatusCode = (int)HttpStatusCode.OK;
                    context.Response.ContentType = "text/json";
                    context.Response.Write(json);
                    context.Response.End();
                }
            }catch (Exception ex)
            {
                ex.ToString();
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}