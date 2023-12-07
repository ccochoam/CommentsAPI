using PraxedesAPI.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PraxedesAPI.Services.Helpers
{
    public class ValidateJsonModel
    {
        public static bool ValidateModel(string json, string type)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                if (type == Constants.CommentTbName)
                {
                    List<CommentModel> modelo = JsonSerializer.Deserialize< List<CommentModel>>(json, options);
                    return modelo != null;
                }
                else if (type == Constants.PostsTbName)
                {
                    List<PostModel> modelo = JsonSerializer.Deserialize<List<PostModel>>(json, options);
                    return modelo != null;
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public static bool ValidateModel<T>(string json)
        {
            try
            {
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };

                T modelo = JsonSerializer.Deserialize<T>(json, options);
                return modelo != null;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
