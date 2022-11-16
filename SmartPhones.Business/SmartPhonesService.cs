using Newtonsoft.Json;
using RestSharp;
using System.Numerics;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DummySmartPhones.Business
{
    public class SmartPhonesService
    {
        public Product GetBestSmartPhone()
        {
            RestClient client = new("https://dummyjson.com");
            RestRequest request = new("products/category/smartphones", Method.Get);

            var result = client.Execute(request);
            if (result.IsSuccessful)
            {
                if (result.Content != null)
                {
                    var phoneData = JsonConvert.DeserializeObject<SmartPhone>(result.Content);

                    if(phoneData != null)
                    {
                        if(phoneData.Products != null)
                        {
                            var bestSmartphone = phoneData.Products
                            .Where(i => (i.Price - (i.Price * i.DiscountPercentage) / 100) < 500)
                            .OrderBy(i => i.Rating)
                            .LastOrDefault();

                            if (bestSmartphone != null)
                            {
                                return bestSmartphone;
                            }
                            else
                            {
                                return new Product();
                            }
                        }
                    }
                }
            }

            return new Product();
        } 
    }
}