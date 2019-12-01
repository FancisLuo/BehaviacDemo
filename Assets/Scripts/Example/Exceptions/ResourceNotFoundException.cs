using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Example
{
    public class ResourceNotFoundException : Exception
    {
        private string message;

        public ResourceNotFoundException()
        {
            message = "Specified Resource is Not Found";
        }

        public ResourceNotFoundException(string resourceName, string resourcePath)
        {
            if(string.IsNullOrEmpty(resourceName) && string.IsNullOrEmpty(resourcePath))
            {
                message = "Specified Resource is Not Found";
            }
            else
            {
                if(!string.IsNullOrEmpty(resourceName) && !string.IsNullOrEmpty(resourcePath))
                {
                    message = $"resource: {resourceName} in {resourcePath} is not found";
                }
                else if(string.IsNullOrEmpty(resourcePath))
                {
                    message = $"cannot find specified resource in {resourcePath}";
                }
                else
                {
                    message = $"resource: {resourceName} is missing";
                }
            }
        }

        public override string Message => message;
    }
}
