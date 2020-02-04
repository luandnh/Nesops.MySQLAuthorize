using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NesopsService.Base.Model
{
    public class BaseResponseModel<TData> where TData : class
    {
        public string name { get; set; }
        public string message { get; set; }
        public int code { get; set; }
        public string className { get; set; }
        public TData data { get; set; }
        public IDictionary<string, string> errors { get; set; } = new Dictionary<string, string>();
        public void SetError(string name, string value)
        {
            errors[name] = value;
        }
    }
    public class GetResponseModel<TReadModel, TRequestModel>
        where TReadModel : class
        where TRequestModel : class, IBaseRequestModel
    {
        public int total { get; private set; } = 0;
        public int limit { get; private set; } = 0;
        public int skip { get; private set; } = 0;
        public List<TReadModel> data { get; set; }
        private TRequestModel request { get; set; }
        public GetResponseModel(TReadModel model)
        {
            data = new List<TReadModel>();
            data.Add(model);
            CountTotal();
            skip = 0;
            limit = 1;
        }
        public GetResponseModel(List<TReadModel> model, TRequestModel requestModel)
        {
            request = requestModel;
            data = model;
            CountTotal();
            SetLimitAndSkip();
            HandlePaging();

        }
        private void CountTotal()
        {
            this.total = this.data.Count;
        }
        private void SetLimitAndSkip()
        {
            this.limit = this.request.limit;
            this.skip = this.request.skip;
        }
        public void HandlePaging()
        {
            this.data = this.data.Skip(this.limit * this.skip).Take(this.limit).ToList();
        }
    }
}
