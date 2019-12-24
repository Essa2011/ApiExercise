using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace anything.DTO.Response
{
    public class AddUpdateItemResponse
    {
        public int ItemId { get; set; }
        public bool Success { get; set; }
        public string ErrorMessage { get; set; }
    }
}