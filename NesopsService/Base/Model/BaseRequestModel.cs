using System;
using System.Collections.Generic;
using System.Text;

namespace NesopsService.Base.Model
{
    public interface IBaseRequestModel
    {
        int limit { get; set; }
        int skip { get; set; }
    }
    public class BaseRequestModel : IBaseRequestModel
    {
        public int limit { get; set; } = 10;
        public int skip { get; set; } = 0;
    }
}
