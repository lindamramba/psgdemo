using Newtonsoft.Json;
using RestSharp;

namespace SmartPhones.Business
{
    public class SmartPhonesService : ISmartPhonesService
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