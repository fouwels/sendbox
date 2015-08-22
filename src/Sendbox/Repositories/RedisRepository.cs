using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using proj.Models;
using StackExchange.Redis;
using Newtonsoft.Json;

namespace proj.Repositories
{
    public class RedisRepository
    {
		private ConnectionMultiplexer redis;

		public RedisRepository()
		{
			redis = ConnectionMultiplexer.Connect("localhost");
		}
		public Mailmodel GetMail(string key)
		{
			RedisValue x;
			try
			{
				x = redis.GetDatabase().StringGet(key);
            }
			catch (Exception)
			{
				return new Mailmodel
				{
					Text = "Could not connect to Redist" //hacky i kno
				};
			}
			if (x.HasValue)
			{
				return JsonConvert.DeserializeObject<Models.Mailmodel>(x);
			}
			else
			{
				return null;
			}

		}
		public async void PutMail(string key, Mailmodel mail)
		{
			await redis.GetDatabase().StringSetAsync(key, JsonConvert.SerializeObject(mail));
		}
    }
}
